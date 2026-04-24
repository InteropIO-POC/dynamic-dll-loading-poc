namespace Container.Interfaces
{
	public interface IClientsManager
	{
		IFDC3Client FDC3Client { get; }
		IWorkspaceClient WorkspaceClient { get; }
	}
}
