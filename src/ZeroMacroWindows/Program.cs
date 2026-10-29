using System;
using System.IO;
using System.Windows.Forms;

namespace ZeroMacroWindows;

internal static class Program
{
	public static string StartupMacroPath;

	public static bool AutoRun;

	[STAThread]
	private static void Main(string[] args)
	{
		if (args.Length > 0 && !args[0].StartsWith("-"))
		{
			StartupMacroPath = RisoltoPercorsoMacro(args[0]);
			if (StartupMacroPath == null)
			{
				MessageBox.Show("Macro '" + args[0] + "' non trovata.\nCerco nei percorsi: cartella exe, cartella exe\\configs, Variabile d'ambiente ZEROREPLAY_CONFIGS.");
				return;
			}
			foreach (string a in args)
			{
				if (a.Equals("--go", StringComparison.OrdinalIgnoreCase) || a.Equals("-go", StringComparison.OrdinalIgnoreCase))
				{
					AutoRun = true;
				}
			}
		}
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.Run(new Form1());
	}

	private static string RisoltoPercorsoMacro(string nome)
	{
		try
		{
			if (File.Exists(nome))
			{
				return Path.GetFullPath(nome);
			}
			string exeDir = AppDomain.CurrentDomain.BaseDirectory;
			string[] candidates =
			{
				Path.Combine(exeDir, nome),
				Path.Combine(exeDir, "configs", nome),
				Path.Combine(exeDir, "configs", nome + ".zmw"),
				Path.Combine(exeDir, nome + ".zmw")
			};
			string envDir = Environment.GetEnvironmentVariable("ZEROREPLAY_CONFIGS");
			if (!string.IsNullOrEmpty(envDir))
			{
				Array.Resize(ref candidates, candidates.Length + 2);
				candidates[candidates.Length - 2] = Path.Combine(envDir, nome);
				candidates[candidates.Length - 1] = Path.Combine(envDir, nome + ".zmw");
			}
			foreach (string c in candidates)
			{
				if (File.Exists(c))
				{
					return c;
				}
			}
		}
		catch
		{
		}
		return null;
	}
}
