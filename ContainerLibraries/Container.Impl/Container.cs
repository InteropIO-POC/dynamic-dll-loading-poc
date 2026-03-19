using Container.Interfaces;
using DOT.ConfigManager.Common.Config;
using InteropIO;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Container.Impl
{
	public class Container : IContainer
	{
		public event EventHandler Connected;

		public IWindowClient WindowClient { get; private set; }
		public IFDC3Client FDC3Client { get; private set; }

		private readonly Finsemble _fsbl;

		/// <param name="args">Command prompt arguments</param>
		/// <param name="input">The object to access your application window. It could be:
		/// 1. System.Windows.Forms.Form - for Winforms app.
		/// 2. System.Windows.Window - for WPF app.
		/// 3. System.IntPtr - for apps registered by windows handler.
		/// 4. null - for windowless (service) apps.
		/// </param>
		public Container(string[] args, object input)
		{
			_fsbl = new Finsemble(args, input);
		}

		public void Initialize()
		{
			if (_fsbl.connected)
			{
				Trace.TraceWarning("Container is already connected.");
				return;
			}
			_fsbl.Connected += (_, e) =>
			{
				Trace.TraceInformation("Container is connected.");

				InitializeClients();
				Connected?.Invoke(this, EventArgs.Empty);
			};
			_fsbl.Connect();
		}

		private void InitializeClients()
		{
			WindowClient = new Clients.WindowClient(_fsbl);
			FDC3Client = new Clients.FDC3Client(_fsbl);
		}
	}
}
