using FinsembleContainer.Interfaces;
using FinsembleContainer.Interfaces.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Threading;
using Container = FinsembleContainer.FinsembleContainer;

namespace ConsoleApp
{
	internal class Program
	{
		private static readonly AutoResetEvent _exitEvent = new AutoResetEvent(false);
		private static IFinsembleContainer _container;

		static void Main(string[] args)
		{
#if DEBUG
			System.IO.File.Delete("FinsembleContainer.log");
			var logger = new TextWriterTraceListener("FinsembleContainer.log");
			logger.TraceOutputOptions = TraceOptions.DateTime;
			Trace.Listeners.Add(logger);
			Trace.AutoFlush = true;
			Trace.TraceInformation("Logging started");
#endif

			_container = new Container(args, null);
			_container.Connected += OnConnected;
			_container.Disconnected += OnDisconnected;
			_container.Error += OnError;
			_container.Connect();

			_exitEvent.WaitOne();
		}

		private static void OnConnected(object sender, EventArgs e)
		{
			_container.Logger.Log("ConsoleExampleApp is connected.");
			_container.RouterClient.Transmit("fsbl.testTransmit", new JObject { ["data"] = "hello from ConsoleApp" });
			_container.RouterClient.AddListener("fsbl.testAddListener", OnRouterMessage);
		}

		private static void OnRouterMessage(object sender, ContainerEventArgs e)
		{
			var data = e.Response?["data"];
			Trace.TraceInformation($"Received Router message: {data}");
		}

		private static void OnDisconnected(object sender, EventArgs e)
		{
			Trace.TraceInformation($"Finsemble disconnected");
			_exitEvent.Set();
		}

		private static void OnError(object sender, UnhandledExceptionEventArgs e)
		{
			Trace.TraceError($"Finsemble error: {e.ExceptionObject}");
			_exitEvent.Set();
		}
	}
}
