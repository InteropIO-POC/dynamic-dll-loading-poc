using FinsembleContainer.Interfaces.Clients;

namespace FinsembleContainer.V7
{
	internal sealed class Logger : ILogger
	{
		private readonly ChartIQ.Finsemble.Logger.Logger _logger;

		internal Logger(ChartIQ.Finsemble.Logger.Logger logger) => _logger = logger;

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
