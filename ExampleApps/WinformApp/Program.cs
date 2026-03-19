using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformApp
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
#if DEBUG
			System.IO.File.Delete("Finsemble.log");
			TextWriterTraceListener logger = new TextWriterTraceListener("Finsemble.log");
			logger.TraceOutputOptions = TraceOptions.DateTime;

			Trace.Listeners.Add(logger);
			Trace.AutoFlush = true;
			Trace.TraceInformation("Logging started");
#endif

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1(args));
		}
	}
}
