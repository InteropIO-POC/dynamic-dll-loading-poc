using System;
using System.Threading.Tasks;

namespace Container.Interfaces
{
	/// <summary>
	/// Represents the Container loaded dynamically from Container.Internal.dll.
	/// Implementations must provide a constructor: Container(string[] args, string windowHandle)
	/// </summary>
	public interface IContainer : IDisposable
	{
		event EventHandler Connected;
		void Initialize();
		IClientsManager Clients { get; }
	}
}
