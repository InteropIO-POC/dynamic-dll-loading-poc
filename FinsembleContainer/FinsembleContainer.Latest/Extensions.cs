using FinsembleContainer.Interfaces.Models;
using InteropIO.Router;

namespace FinsembleContainer.Latest
{
	internal static class Extensions
	{
		public static ContainerEventArgs ToContainerEventArgs(this FinsembleEventArgs args)
		{
			return new ContainerEventArgs(args.error, args.response);
		}
	}
}
