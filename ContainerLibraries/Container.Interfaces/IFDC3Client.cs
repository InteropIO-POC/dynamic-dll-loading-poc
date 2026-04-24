using Container.Interfaces.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Container.Interfaces
{
	public interface IFDC3Client
	{
		Listener AddIntentListener<T, K>(string intent, Func<T, K> callback) where T : ContextMetadata where K : ContextMetadata;
		void FindIntent(string intent, ContextMetadata context = null, Action<FindIntentResponse> callback = null);
		Task<FindIntentResponse> FindIntentAsync(string intent, ContextMetadata context = null, CancellationToken cancellationToken = default);
		void Open(string appName, ContextMetadata context = null, ContextMetadata paramsValue = null);
		void RaiseIntent<T>(RaiseIntentRequest request, Action<RaiseIntentResponse<T>> callback = null) where T : ContextMetadata;
		Task<RaiseIntentResponse<T>> RaiseIntentAsync<T>(RaiseIntentRequest parameter, CancellationToken cancellationToken = default) where T : ContextMetadata;
		void Transmit<T>(string topic, T context) where T : ContextMetadata;
	}
}
