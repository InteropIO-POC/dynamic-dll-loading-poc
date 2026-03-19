namespace Container.Interfaces
{
	public class RuntimeInfo
	{
		public string Platform { get; }
		public string ContainerImplVersion { get; }

		public RuntimeInfo(string platform, string containerImplVersion)
		{
			Platform = platform;
			ContainerImplVersion = containerImplVersion;
		}
	}
}
