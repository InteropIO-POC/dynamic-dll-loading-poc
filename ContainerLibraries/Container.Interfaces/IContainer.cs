using System;
using System.Threading.Tasks;

namespace Container.Interfaces
{
	/// <summary>
	/// Represents the Container loaded dynamically from Container.Internal.dll.
	/// Implementations must provide a constructor: Container(string[] args, string windowHandle)
	/// </summary>
	public interface IContainer
    {
		event EventHandler Connected;
		void Initialize();
        IWindowClient WindowClient { get; }
        IFDC3Client FDC3Client { get; }
    }
}
