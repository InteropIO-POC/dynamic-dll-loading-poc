using FinsembleContainer.Interfaces.Clients;
using FinsembleContainer.Interfaces.Models;
using Newtonsoft.Json.Linq;
using System;

namespace FinsembleContainer.Latest
{
	internal sealed class RouterClient : IRouterClient
	{
		private readonly InteropIO.Interfaces.IRouterClient _router;

		internal RouterClient(InteropIO.Interfaces.IRouterClient router) => _router = router;

		public void AddListener(string channel, EventHandler<ContainerEventArgs> callback)
			=> _router.AddListener(channel, (s, e) => callback(s, e.ToContainerEventArgs()));

		public void Transmit(string channel, JToken data, JToken options = null)
			=> _router.Transmit(channel, data);
	}
}
