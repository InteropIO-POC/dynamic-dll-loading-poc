namespace FinsembleContainer.Interfaces.Clients
{
	public interface ILogger
	{
		void Error(string message);
		void Info(string message);
		void Log(string message);
		void Warn(string message);
	}
}
