using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp
{
	public partial class App : Application
	{
		private MainWindow _mainWindow = null;

		private void OnStartup(object sender, StartupEventArgs e)
		{
#if DEBUG
			System.IO.File.Delete("Finsemble.log");
			TextWriterTraceListener logger = new TextWriterTraceListener("Finsemble.log");
			logger.TraceOutputOptions = TraceOptions.DateTime;

			Trace.Listeners.Add(logger);
			Trace.AutoFlush = true;
			Trace.TraceInformation("Logging started");
#endif

			try
			{
				_mainWindow = new MainWindow(e.Args);
			_mainWindow.Show();
			}
			catch (Exception ex)
			{
				Trace.TraceError(ex.ToString());
				Trace.TraceInformation("Shutting down");
				this.Shutdown();
			}
		}
	}
}
