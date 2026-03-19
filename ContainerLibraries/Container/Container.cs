using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Container.Interfaces;

namespace Container
{
	public class Container : IContainer
	{
		public event EventHandler Connected
		{
			add { _inner.Connected += value; }
			remove { _inner.Connected -= value; }
		}

		public IWindowClient WindowClient => _inner.WindowClient;
		public IFDC3Client FDC3Client => _inner.FDC3Client;

		private readonly IContainer _inner;

		/// <param name="args">Command prompt arguments</param>
		/// <param name="input">The object to access your application window. It could be:
		/// 1. System.Windows.Forms.Form - for Winforms app.
		/// 2. System.Windows.Window - for WPF app.
		/// 3. System.IntPtr - for apps registered by windows handler.
		/// 4. null - for windowless (service) apps.
		/// </param>
		public Container(string[] args, object input)
		{
			var dllPath = ParseContainerImplPath(args);

			if (dllPath == null)
			{
				var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				dllPath = Path.Combine(localAppData, "ContainerLibs", "Container.Impl.dll");
			}

			var assembly = Assembly.LoadFrom(dllPath);
			var type = assembly.GetType("Container.Impl.Container");
			_inner = (IContainer)Activator.CreateInstance(type, new object[] { args, input });
		}

		public void Initialize()
		{
			_inner.Initialize();
		}

		// Parses containerImplPath=<full dll path> from args.
		private static string ParseContainerImplPath(string[] args)
		{
			const string key = "containerImplPath=";
			if (args == null) return null;

			foreach (var arg in args)
			{
				if (arg.StartsWith(key, StringComparison.OrdinalIgnoreCase))
					return arg.Substring(key.Length).Trim('\'', '"');
			}

			return null;
		}
	}
}
