using Container.Interfaces;
using InteropIO;
using System.Threading.Tasks;

namespace Container.Impl
{
	internal class ClientsManager : IClientsManager
	{
		public IFDC3Client FDC3Client { get; private set; }
		public IWorkspaceClient WorkspaceClient { get; private set; }

		public async Task Initialize(Finsemble fsbl)
		{
			FDC3Client = new Clients.FDC3Client(fsbl);
			WorkspaceClient = new Clients.WorkspaceClient(fsbl);
		}
	}
}
