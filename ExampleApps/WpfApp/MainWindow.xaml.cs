using Container.Interfaces;
using Container.Interfaces.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private IContainer _container;

		public MainWindow(string[] args)
		{
			InitializeComponent();
			_container = new Container.Container(args, this);
			_container.Connected += OnContainerConnected;
			_container.Initialize();
		}

		private void OnContainerConnected(object sender, EventArgs e)
		{
			Dispatcher.Invoke(() =>
			{
				StatusText.Text = "Connected";
				OpenButton.IsEnabled = true;
				FindIntentButton.IsEnabled = true;
				RaiseIntentButton.IsEnabled = true;
				GetActiveWorkspaceButton.IsEnabled = true;
			});

			_container.Clients.FDC3Client.AddIntentListener<ContextMetadata, ContextMetadata>("TestNative", (context) =>
			{
				ContextMetadata result = null;

				if (context.Type != null && context.Type.Equals("fdc3.instrument"))
				{
					result = new ContextMetadata
					{
						Type = "fdc3.chart",
						AdditionalData = { ["chart"] = "some-chart-link" }
					};
				}
				return result;
			});
		}

		private void OpenButton_Click(object sender, RoutedEventArgs e)
		{
			_container.Clients.FDC3Client.Open(AppNameInput.Text);
		}

		private async void FindIntentButton_Click(object sender, RoutedEventArgs e)
		{
			FindIntentButton.IsEnabled = false;
			try
			{
				var response = await _container.Clients.FDC3Client.FindIntentAsync(FindIntentInput.Text);
				var sb = new StringBuilder();
				sb.AppendLine($"Intent: {response.Intent}");
				foreach (var app in response.Apps ?? Enumerable.Empty<AppMetadata>())
					sb.AppendLine($"  - {app.Name} ({app.AppId})");
				FindIntentResult.Text = sb.ToString();
			}
			catch (Exception ex)
			{
				FindIntentResult.Text = $"Error: {ex.Message}";
			}
			finally
			{
				FindIntentButton.IsEnabled = true;
			}
		}

		private async void RaiseIntentButton_Click(object sender, RoutedEventArgs e)
		{
			RaiseIntentButton.IsEnabled = false;
			try
			{
				var request = new RaiseIntentRequest
				{
					Intent = RaiseIntentInput.Text,
					Context = new ContextMetadata { Type = RaiseIntentContextInput.Text }
				};
				var response = await _container.Clients.FDC3Client.RaiseIntentAsync<ContextMetadata>(request);
				RaiseIntentResult.Text = $"Source: {response.Source}, Intent: {response.Intent}, Result type: {response.Result?.Type}";
			}
			catch (Exception ex)
			{
				RaiseIntentResult.Text = $"Error: {ex.Message}";
			}
			finally
			{
				RaiseIntentButton.IsEnabled = true;
			}
		}

		private async void GetActiveWorkspaceButton_Click(object sender, RoutedEventArgs e)
		{
			GetActiveWorkspaceButton.IsEnabled = false;
			try
			{
				var result = await _container.Clients.WorkspaceClient.GetActiveWorkspace();
				GetActiveWorkspaceResult.Text = $"\"{result}\"";
			}
			catch (Exception ex)
			{
				GetActiveWorkspaceResult.Text = $"Error: {ex.Message}";
			}
			finally
			{
				GetActiveWorkspaceButton.IsEnabled = true;
			}
		}
	}
}
