using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ZeroMacroWindows;

// Gestisce le hotkey globali: una combinazione di tasti per ogni configurazione (file macro).
// Le associazioni vivono in hotkeys.ini accanto all'exe: <combo>=<percorso file macro>
public class HotkeyManager
{
	private const int HOTKEY_ID_BASE = 9000;

	private readonly Form1 mio;

	public bool Attiva;

	// id hotkey -> (combo, percorso macro) per tutte le hotkey registrate ora
	private readonly Dictionary<int, KeyValuePair<string, string>> registered = new Dictionary<int, KeyValuePair<string, string>>();

	// combo corrente della configurazione caricata (null = nessuna)
	public Keys Modifiers;

	public Keys Key;

	public string ComboCorrente;

	// macro avviate via hotkey in attesa che il thread attuale finisca (null = nessuna)
	public string PendingHotkeyMacro;

	private string currentMacroPath;

	public HotkeyManager(Form1 owner)
	{
		mio = owner;
	}

	public static string IniPath()
	{
		return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hotkeys.ini");
	}

	public static string RegistryPath()
	{
		return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "macroz.ini");
	}

	public void SetCurrentMacro(string path)
	{
		currentMacroPath = path;
		ComboCorrente = null;
		if (path != null)
		{
			RegisterMacroKnown(path);
			ComboCorrente = HotkeyPer(path);
		}
		if (Attiva)
		{
			RegisterAll();
		}
	}

	public string CurrentMacroPath => currentMacroPath;

	public static bool TryParseCombo(string combo, out Keys mods, out Keys key)
	{
		mods = Keys.None;
		key = Keys.None;
		if (string.IsNullOrEmpty(combo))
		{
			return false;
		}
		string[] parts = combo.ToUpperInvariant().Split('+');
		foreach (string p in parts)
		{
			switch (p.Trim())
			{
			case "CTRL":
				mods |= Keys.Control;
				break;
			case "ALT":
				mods |= Keys.Alt;
				break;
			case "SHIFT":
				mods |= Keys.Shift;
				break;
			case "WIN":
				mods |= Keys.LWin;
				break;
			default:
			{
				try
				{
					key = (Keys)Enum.Parse(typeof(Keys), p.Trim(), true);
				}
				catch
				{
					return false;
				}
				break;
			}
			}
		}
		return key != Keys.None && mods != Keys.None;
	}

	public static string ModifiersToWin(uint mods)
	{
		uint w = 0u;
		if ((mods & (uint)Keys.Alt) != 0)
		{
			w |= 1u;
		}
		if ((mods & (uint)Keys.Control) != 0)
		{
			w |= 2u;
		}
		if ((mods & (uint)Keys.Shift) != 0)
		{
			w |= 4u;
		}
		if ((mods & (uint)Keys.LWin) != 0)
		{
			w |= 8u;
		}
		return w.ToString();
	}

	// registra TUTTE le associazioni presenti in hotkeys.ini (una hotkey per configurazione).
	// Ritorna la lista delle combo non registrate perche' gia' usate da altri programmi.
	public List<string> RegisterAll()
	{
		UnregisterAll();
		List<string> fallite = new List<string>();
		if (!Attiva)
		{
			return fallite;
		}
		int i = 0;
		foreach (KeyValuePair<string, string> kvp in ReadIni())
		{
			if (!TryParseCombo(kvp.Key, out Keys mods, out Keys key))
			{
				continue;
			}
			uint wmods = 0u;
			if ((mods & Keys.Alt) != Keys.None)
			{
				wmods |= 1u;
			}
			if ((mods & Keys.Control) != Keys.None)
			{
				wmods |= 2u;
			}
			if ((mods & Keys.Shift) != Keys.None)
			{
				wmods |= 4u;
			}
			if ((mods & Keys.LWin) != Keys.None)
			{
				wmods |= 8u;
			}
			int id = HOTKEY_ID_BASE + i;
			if (Win32.RegisterHotKey(mio.Handle, id, wmods, (uint)key))
			{
				registered[id] = kvp;
				i++;
			}
			else
			{
				fallite.Add(kvp.Key);
			}
		}
		return fallite;
	}

	public void UnregisterAll()
	{
		foreach (int id in new List<int>(registered.Keys))
		{
			try
			{
				Win32.UnregisterHotKey(mio.Handle, id);
			}
			catch
			{
			}
		}
		registered.Clear();
	}

	// percorso della macro associata all'id di una WM_HOTKEY ricevuta
	public string PathPerId(int id)
	{
		if (registered.TryGetValue(id, out var kvp))
		{
			return kvp.Value;
		}
		return null;
	}

	// Associa la combo alla macro corrente e la salva su ini
	public bool Associa(string combo)
	{
		return AssociaSpecifica(combo, currentMacroPath);
	}

	// Associa la combo a una macro specifica e salva su ini
	public bool AssociaSpecifica(string combo, string macroPath)
	{
		if (macroPath == null)
		{
			return false;
		}
		if (!TryParseCombo(combo, out Keys _, out Keys _))
		{
			return false;
		}
		Dictionary<string, string> ini = ReadIni();
		// una combo = una macro: rimuovi la combo da altre macro e questa macro da altre combo
		List<string> toRemove = new List<string>();
		foreach (KeyValuePair<string, string> kvp in ini)
		{
			if (string.Equals(kvp.Key, combo, StringComparison.OrdinalIgnoreCase)
			    || string.Equals(kvp.Value, macroPath, StringComparison.OrdinalIgnoreCase))
			{
				toRemove.Add(kvp.Key);
			}
		}
		foreach (string k in toRemove)
		{
			ini.Remove(k);
		}
		ini[combo] = macroPath;
		if (string.Equals(macroPath, currentMacroPath, StringComparison.OrdinalIgnoreCase))
		{
			ComboCorrente = combo;
		}
		WriteIni(ini);
		RegisterMacroKnown(macroPath);
		if (Attiva)
		{
			RegisterAll();
		}
		return true;
	}

	public void RimuoviAssociazione()
	{
		RimuoviPerPath(currentMacroPath);
	}

	public void RimuoviPerPath(string macroPath)
	{
		if (macroPath == null)
		{
			return;
		}
		Dictionary<string, string> ini = ReadIni();
		string toRemove = null;
		foreach (KeyValuePair<string, string> kvp in ini)
		{
			if (string.Equals(kvp.Value, macroPath, StringComparison.OrdinalIgnoreCase))
			{
				toRemove = kvp.Key;
			}
		}
		if (toRemove != null)
		{
			ini.Remove(toRemove);
			WriteIni(ini);
		}
		if (string.Equals(macroPath, currentMacroPath, StringComparison.OrdinalIgnoreCase))
		{
			ComboCorrente = null;
		}
		if (Attiva)
		{
			RegisterAll();
		}
	}

	// ---- registro configurazioni conosciute ----

	public static List<string> PercorsiNoti()
	{
		List<string> result = new List<string>();
		try
		{
			if (File.Exists(RegistryPath()))
			{
				foreach (string line in File.ReadAllLines(RegistryPath()))
				{
					string p = line.Trim();
					if (p.Length > 0 && File.Exists(p) && !result.Contains(p))
					{
						result.Add(p);
					}
				}
			}
			// cartella configs accanto all'exe
			string cfgDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "configs");
			if (Directory.Exists(cfgDir))
			{
				foreach (string f in Directory.GetFiles(cfgDir))
				{
					if (!result.Contains(f))
					{
						result.Add(f);
					}
				}
			}
			// macro con hotkey che non sono nel registro
			foreach (KeyValuePair<string, string> kvp in ReadIni())
			{
				if (File.Exists(kvp.Value) && !result.Contains(kvp.Value))
				{
					result.Add(kvp.Value);
				}
			}
		}
		catch
		{
		}
		return result;
	}

	public static void RegisterMacroKnown(string path)
	{
		try
		{
			if (path == null || !File.Exists(path))
			{
				return;
			}
			List<string> existing = new List<string>();
			if (File.Exists(RegistryPath()))
			{
				foreach (string line in File.ReadAllLines(RegistryPath()))
				{
					string p = line.Trim();
					if (p.Length > 0 && !Contiene(existing, p))
					{
						existing.Add(p);
					}
				}
			}
			if (!Contiene(existing, path))
			{
				existing.Add(path);
				File.WriteAllLines(RegistryPath(), existing.ToArray());
			}
		}
		catch
		{
		}
	}

	private static bool Contiene(List<string> lista, string p)
	{
		foreach (string x in lista)
		{
			if (string.Equals(x, p, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	// hotkey associata a un percorso (null se nessuna)
	public static string HotkeyPer(string path)
	{
		if (path == null)
		{
			return null;
		}
		foreach (KeyValuePair<string, string> kvp in ReadIni())
		{
			if (string.Equals(kvp.Value, path, StringComparison.OrdinalIgnoreCase))
			{
				return kvp.Key;
			}
		}
		return null;
	}

	public static Dictionary<string, string> ReadIni()
	{
		Dictionary<string, string> result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		try
		{
			if (!File.Exists(IniPath()))
			{
				return result;
			}
			string[] lines = File.ReadAllLines(IniPath());
			foreach (string line in lines)
			{
				int idx = line.IndexOf('=');
				if (idx > 0)
				{
					string k = line.Substring(0, idx).Trim();
					string v = line.Substring(idx + 1).Trim();
					if (!string.IsNullOrEmpty(k) && !string.IsNullOrEmpty(v))
					{
						result[k] = v;
					}
				}
			}
		}
		catch
		{
		}
		return result;
	}

	public static void WriteIni(Dictionary<string, string> ini)
	{
		try
		{
			using StreamWriter w = new StreamWriter(IniPath());
			foreach (KeyValuePair<string, string> kvp in ini)
			{
				w.WriteLine(kvp.Key + "=" + kvp.Value);
			}
		}
		catch
		{
		}
	}
}