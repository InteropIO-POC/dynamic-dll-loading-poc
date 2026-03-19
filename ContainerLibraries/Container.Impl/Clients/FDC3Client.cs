using Container.Interfaces;
using InteropIO;
using System.Threading.Tasks;

namespace Container.Impl.Clients
{
	internal class FDC3Client : IFDC3Client
	{
		private readonly Finsemble _fsbl;

		public FDC3Client(Finsemble fsbl)
		{
			_fsbl = fsbl;
		}

		public Task Open(string appName)
		{
			return _fsbl.Clients.FDC3Client.DesktopAgentClient.Open(appName, null);
		}
	}
}
