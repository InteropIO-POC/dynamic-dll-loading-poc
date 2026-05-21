using FinsembleContainer.Interfaces;
using FinsembleContainer.Interfaces.Clients;
using InteropIO;
using System;
using System.Diagnostics;

namespace FinsembleContainer.Latest
{
	public class FinsembleContainer : IFinsembleContainer
	{
		private readonly Finsemble _fsbl;
		private ILogger _logger;
		private IRouterClient _routerClient;

		public ILogger Logger => _logger;
		public IRouterClient RouterClient => _routerClient;

		public event EventHandler Connected;
		public event EventHandler Disconnected;
		public event EventHandler<UnhandledExceptionEventArgs> Error;

		public FinsembleContainer(string[] args, object input)
		{
			_fsbl = new Finsemble(args, input);
			_fsbl.Connected += (s, e) =>
			{
				Trace.WriteLine("Finsemble is connected");
				_logger = new Logger(_fsbl.Clients.Logger);
				_routerClient = new RouterClient(_fsbl.Clients.RouterClient);
				Connected?.Invoke(this, e);
			};
			_fsbl.Disconnected += (s, e) => Disconnected?.Invoke(this, e);
			_fsbl.Error += (s, e) => Error?.Invoke(this, e);
		}

		public void Connect() => _fsbl.Connect();

		public void Dispose() => _fsbl.Dispose();
	}
}
