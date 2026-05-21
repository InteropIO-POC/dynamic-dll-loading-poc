using FinsembleContainer.Interfaces.Models;
using Newtonsoft.Json.Linq;
using System;

namespace FinsembleContainer.Interfaces.Clients
{
	public interface IRouterClient
	{
		void AddListener(string channel, EventHandler<ContainerEventArgs> callback);
		void Transmit(string channel, JToken data, JToken options = null);
	}
}
