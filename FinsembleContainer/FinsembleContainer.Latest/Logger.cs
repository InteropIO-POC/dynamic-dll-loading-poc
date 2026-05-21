using FinsembleContainer.Interfaces.Clients;

namespace FinsembleContainer.Latest
{
	internal sealed class Logger : ILogger
	{
		private readonly InteropIO.Interfaces.ILoggerClient _logger;

		internal Logger(InteropIO.Interfaces.ILoggerClient logger) => _logger = logger;

		public void Error(string message)
		{
			_logger.Error(message);
		}

		public void Info(string message)
		{
			_logger.Info(message);
		}

		public void Log(string message)
		{
			_logger.Log(message);
		}

		public void Warn(string message)
		{
			_logger.Warn(message);
		}
	}
}
