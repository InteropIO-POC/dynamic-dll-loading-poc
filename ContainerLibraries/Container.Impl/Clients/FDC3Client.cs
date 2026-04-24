using Container.Interfaces;
using InteropIO;
using InteropIO.FDC3.Interfaces;
using InteropIO.FDC3.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Container.Interfaces.Models;

using ContextMetadata = Container.Interfaces.Models.ContextMetadata;
using FindIntentResponse = Container.Interfaces.Models.FindIntentResponse;
using Listener = Container.Interfaces.Models.Listener;

namespace Container.Impl.Clients
{
	internal class FDC3Client : IFDC3Client
	{
		private readonly Finsemble _fsbl;
		private ConcurrentDictionary<string, IListener> _listenerDict = new ConcurrentDictionary<string, IListener>();

		public FDC3Client(Finsemble fsbl)
		{
			_fsbl = fsbl;
		}

		public Listener AddIntentListener<T, K>(string intent, Func<T, K> callback)
			where T : ContextMetadata
			where K : ContextMetadata
		{
			Trace.TraceInformation($"AddIntentListener: intent {intent}");

			if (string.IsNullOrWhiteSpace(intent)) return new Listener();

			string listenerId = CreateIntermediateListener(out Listener listener);
			Task<IListener> addFinListenerTask = null;

			try
			{
				addFinListenerTask = _fsbl.Clients.FDC3Client.DesktopAgentClient.AddIntentListener(intent, async (ctx, _) =>
				{
					Trace.TraceInformation($"AddIntentListener: {intent} listener received context with type {ctx?.Type}");
					var result = callback?.Invoke(ctx.ToContextValue().ToObject<T>()) ?? Activator.CreateInstance<K>();
					var resultCtx = new Context(JToken.FromObject(result));
					Trace.TraceInformation($"AddIntentListener: {intent} listener returned context with type {resultCtx.Type}");
					return new ContextIntentResult { Context = resultCtx };
				});
			}
			catch (Exception ex) { Trace.TraceError(ex.ToString()); }

			Task.Run(async () =>
			{
				var finListener = await (addFinListenerTask ?? Task.FromResult<IListener>(null));
				if (finListener != null)
				{
					bool success = _listenerDict.TryAdd(listenerId, finListener);
					Trace.TraceInformation($"AddIntentListener: {intent} listener {listenerId} success: {success}");
				}
			});
			return listener;
		}

		public void FindIntent(string intent, ContextMetadata context = null, Action<FindIntentResponse> callback = null)
		{
			Trace.TraceInformation($"FindIntent: intent={intent}");

			if (string.IsNullOrWhiteSpace(intent))
			{
				callback?.Invoke(null);
				return;
			}

			Task.Run(async () =>
			{
				try
				{
					var res = await _fsbl.Clients.FDC3Client.DesktopAgentClient.FindIntent(intent);
					callback?.Invoke(res.ToLegacyIntent());
				}
				catch (Exception ex) { Trace.TraceError(ex.ToString()); }
			});
		}

		public async Task<FindIntentResponse> FindIntentAsync(string intent, ContextMetadata context = null, CancellationToken cancellationToken = default)
		{
			var tcs = new TaskCompletionSource<FindIntentResponse>();
			using (cancellationToken.Register(() => tcs.TrySetCanceled()))
			{
				FindIntent(intent, context, res => tcs.TrySetResult(res));
				return await tcs.Task;
			}
		}

		public void Open(string appName, ContextMetadata context = null, ContextMetadata paramsValue = null)
		{
			Task.Run(async () =>
			{
				try
				{
					await _fsbl.Clients.FDC3Client.DesktopAgentClient.Open(appName, context.ToContext());
				}
				catch (Exception ex) { Trace.TraceError(ex.ToString()); }
			});
		}

		public void RaiseIntent<T>(RaiseIntentRequest request, Action<RaiseIntentResponse<T>> callback = null) where T : ContextMetadata
		{
			if (request == null || string.IsNullOrWhiteSpace(request.Intent))
			{
				callback?.Invoke(new RaiseIntentResponse<T>());
				return;
			}
			Trace.TraceInformation($"RaiseIntent: parameter={JsonConvert.SerializeObject(request, Formatting.Indented)}");

			Task.Run(async () =>
			{
				try
				{
					var resolution = await _fsbl.Clients.FDC3Client.DesktopAgentClient.RaiseIntent(request.Intent, request.Context.ToContext(), request.Target);
					var res = await resolution.ToLegacyIntentResolution<T>();
					callback?.Invoke(res);
				}
				catch (Exception ex) { Trace.TraceError(ex.ToString()); }
			});
		}

		public async Task<RaiseIntentResponse<T>> RaiseIntentAsync<T>(RaiseIntentRequest parameter, CancellationToken cancellationToken = default) where T : ContextMetadata
		{
			var tcs = new TaskCompletionSource<RaiseIntentResponse<T>>();
			using (cancellationToken.Register(() => tcs.TrySetCanceled()))
			{
				RaiseIntent<T>(parameter, res => tcs.TrySetResult(res));
				return await tcs.Task;
			}
		}

		public void Transmit<T>(string topic, T context) where T : ContextMetadata
		{
			if (string.IsNullOrWhiteSpace(topic)) return;

			try
			{
				Trace.TraceInformation($"Transmit to {topic}, {JsonConvert.SerializeObject(context, Formatting.Indented)}");
				_fsbl.Clients.RouterClient.Transmit(topic, JToken.FromObject(context));
			}
			catch (Exception ex) { Trace.TraceError(ex.ToString()); }
		}

		private string CreateIntermediateListener(out Listener listener)
		{
			string listenerId = Guid.NewGuid().ToString();
			listener = new Listener(() =>
			{
				if (_listenerDict.TryGetValue(listenerId, out IListener finListener))
				{
					finListener?.Unsubscribe();
					bool success = _listenerDict.TryRemove(listenerId, out _);
					Trace.TraceInformation($"Unsubscribe listener {listenerId} success: {success}");
				}
			});
			return listenerId;
		}
	}
}
