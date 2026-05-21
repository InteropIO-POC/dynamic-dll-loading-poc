using FinsembleContainer.Interfaces.Clients;
using System;

namespace FinsembleContainer.Interfaces
{
    public interface IFinsembleContainer : IDisposable
	{
		event EventHandler Connected;
		event EventHandler Disconnected;
		event EventHandler<UnhandledExceptionEventArgs> Error;
		void Connect();
		IRouterClient RouterClient { get; }
		ILogger Logger { get; }
	}
}
