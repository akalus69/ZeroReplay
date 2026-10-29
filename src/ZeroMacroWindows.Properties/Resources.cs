using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ZeroMacroWindows.Properties;

[DebuggerNonUserCode]
[CompilerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (object.ReferenceEquals(resourceMan, null))
			{
				ResourceManager resourceManager = new ResourceManager("ZeroMacroWindows.Properties.Resources", typeof(Resources).Assembly);
				resourceMan = resourceManager;
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static Bitmap cestino
	{
		get
		{
			object obj = ResourceManager.GetObject("cestino", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap images
	{
		get
		{
			object obj = ResourceManager.GetObject("images", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap imagesCALVTU5O
	{
		get
		{
			object obj = ResourceManager.GetObject("imagesCALVTU5O", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap imagessu
	{
		get
		{
			object obj = ResourceManager.GetObject("imagessu", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal Resources()
	{
	}
}
