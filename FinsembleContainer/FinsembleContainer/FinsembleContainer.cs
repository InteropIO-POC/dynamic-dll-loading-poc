using FinsembleContainer.Interfaces;
using FinsembleContainer.Interfaces.Clients;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace FinsembleContainer
{
	public class FinsembleContainer : IFinsembleContainer
	{
		public ILogger Logger => _instance.Logger;
		public IRouterClient RouterClient => _instance.RouterClient;

		public event EventHandler Connected;
		public event EventHandler Disconnected;
		public event EventHandler<UnhandledExceptionEventArgs> Error;

		private readonly IFinsembleContainer _instance;

		public FinsembleContainer(string[] args, object input)
		{
			var version = IsV7Host(args) ? "V7" : "Latest";
			Trace.TraceInformation($"Creating container instance {version}");
			_instance = CreateContainerInstance(version, args, input);
			Trace.TraceInformation($"Created container instance");
			_instance.Connected += (s, e) => Connected?.Invoke(this, e);
			_instance.Disconnected += (s, e) => Disconnected?.Invoke(this, e);
			_instance.Error += (s, e) => Error?.Invoke(this, e);
		}

		public void Connect() => _instance.Connect();

		public void Dispose() => _instance.Dispose();

		private static IFinsembleContainer CreateContainerInstance(string version, string[] args, object input)
		{
			var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, version);

			AppDomain.CurrentDomain.AssemblyResolve += (sender, resolveArgs) =>
			{
				var fileName = new AssemblyName(resolveArgs.Name).Name + ".dll";
				var path = Path.Combine(dir, fileName);
				return File.Exists(path) ? Assembly.LoadFrom(path) : null;
			};
			var dllPath = Path.Combine(dir, $"FinsembleContainer.{version}.dll");
			Trace.TraceInformation($"Loading assembly from {dllPath}");
			var assembly = Assembly.LoadFrom(dllPath);
			Trace.TraceInformation($"Loaded assembly");
			var type = assembly.GetType($"FinsembleContainer.{version}.FinsembleContainer");
			return (IFinsembleContainer)Activator.CreateInstance(type, new object[] { args, input });
		}

		private static bool IsV7Host(string[] args)
		{
			foreach (var arg in args)
			{
				var parts = arg.Split(new[] { '=' }, 2);
				if (parts.Length != 2) continue;
				if (!string.Equals(parts[0].Trim(), "hostType", StringComparison.OrdinalIgnoreCase)) continue;

				var value = parts[1].Trim().Trim('"');
				if (string.Equals(value, "iocd", StringComparison.OrdinalIgnoreCase) ||
					string.Equals(value, "finsemble", StringComparison.OrdinalIgnoreCase))
					return false;
			}
			return true;
		}
	}
}
