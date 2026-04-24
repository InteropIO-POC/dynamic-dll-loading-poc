using Container.Interfaces;
using DOT.AGM.Client;
using InteropIO;
using System;
using System.Diagnostics;

namespace Container.Impl
{
	public class Container : IContainer
	{
		public event EventHandler Connected;
		public IClientsManager Clients => _clients;

		private readonly Finsemble _fsbl;
		private ClientsManager _clients = new ClientsManager();

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
			_fsbl.Connected += async (_, e) =>
			{
				Trace.TraceInformation("Finsemble is connected.");

				await _clients.Initialize(_fsbl);
				Trace.TraceInformation("Clients are initialized.");

				Connected?.Invoke(this, EventArgs.Empty);
			};
			_fsbl.Connect();
		}

		public void Dispose()
		{
			_fsbl?.Dispose();
		}
	}
}
