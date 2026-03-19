using Container.Interfaces;
using InteropIO;

namespace Container.Impl.Clients
{
	internal class WindowClient : IWindowClient
	{
		private readonly Finsemble _fsbl;

		public WindowClient(Finsemble fsbl)
		{
			_fsbl = fsbl;
		}

		public RuntimeInfo GetRuntimeInfo()
		{
			var platform = _fsbl.connected
				? (_fsbl.IsIOCDConnected ? "io.CD" : "Finsemble")
				: "unknown";

			var version = typeof(WindowClient).Assembly.GetName().Version?.ToString();

			return new RuntimeInfo(platform, version);
		}
	}
}
