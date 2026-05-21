using ChartIQ.Finsemble.Router;
using FinsembleContainer.Interfaces.Models;

namespace FinsembleContainer.V7
{
	internal static class Extensions
	{
		public static ContainerEventArgs ToContainerEventArgs(this FinsembleEventArgs args)
		{
			return new ContainerEventArgs(args.error, args.response);
		}
	}
}
