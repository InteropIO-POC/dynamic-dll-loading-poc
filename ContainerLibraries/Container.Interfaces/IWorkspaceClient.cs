using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Container.Interfaces
{
	public interface IWorkspaceClient
	{
		Task<JToken> GetActiveWorkspace();
		Task<string[]> GetWorkspaces();
	}
}
