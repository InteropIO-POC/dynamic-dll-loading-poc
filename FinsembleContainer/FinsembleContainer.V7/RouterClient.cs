using ChartIQ.Finsemble;
using FinsembleContainer.Interfaces.Clients;
using FinsembleContainer.Interfaces.Models;
using Newtonsoft.Json.Linq;
using System;

namespace FinsembleContainer.V7
{
	internal sealed class RouterClient : IRouterClient
	{
		private readonly ChartIQ.Finsemble.Router.RouterClient _router;

		internal RouterClient(ChartIQ.Finsemble.Router.RouterClient router) => _router = router;

		public void AddListener(string channel, EventHandler<ContainerEventArgs> callback)
			=> _router.AddListener(channel, (s, e) => callback(s, e.ToContainerEventArgs()));

		public void Transmit(string channel, JToken data, JToken options = null)
			=> _router.Transmit(channel, data);
	}
}
