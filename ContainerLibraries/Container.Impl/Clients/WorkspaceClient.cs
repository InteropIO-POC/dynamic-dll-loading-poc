using Container.Interfaces;
using InteropIO;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Container.Impl.Clients
{
	internal class WorkspaceClient : IWorkspaceClient
	{
		private readonly Finsemble _fsbl;

		public WorkspaceClient(Finsemble fsbl)
		{
			_fsbl = fsbl;
		}

		public async Task<JToken> GetActiveWorkspace()
		{
			var response = await _fsbl.Clients.WorkspaceClient.GetActiveWorkspace();
			return response["name"];
		}

		public async Task<string[]> GetWorkspaces()
		{
			return await _fsbl.Clients.WorkspaceClient.GetWorkspaceNames();
		}
	}
}
