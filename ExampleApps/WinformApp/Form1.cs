using Container.Interfaces;
using Container.Interfaces.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinformApp
{
	public partial class Form1 : Form
	{
		private IContainer _container;

		public Form1(string[] args)
		{
			InitializeComponent();
			_container = new Container.Container(args, this);
			_container.Connected += OnContainerConnected;
			_container.Initialize();
		}

		private void OnContainerConnected(object sender, EventArgs e)
		{
			Invoke((Action)(() =>
			{
				labelStatusValue.Text = "Connected";
				buttonOpen.Enabled = true;
				buttonFindIntent.Enabled = true;
				buttonRaiseIntent.Enabled = true;
				buttonGetActiveWorkspace.Enabled = true;
			}));

			_container.Clients.FDC3Client.AddIntentListener<ContextMetadata, ContextMetadata>("TestNative", (context) =>
			{
				if (context.Type != null && context.Type.Equals("fdc3.instrument"))
				{
					Thread.Sleep(2500);
					return new ContextMetadata
					{
						Type = "fdc3.chart",
						AdditionalData = { ["chart"] = "some-chart-link" }
					};
				}
				return null;
			});
		}

		private void buttonOpen_Click(object sender, EventArgs e)
		{
			_container.Clients.FDC3Client.Open(textBoxAppName.Text);
		}

		private async void buttonFindIntent_Click(object sender, EventArgs e)
		{
			buttonFindIntent.Enabled = false;
			try
			{
				var response = await _container.Clients.FDC3Client.FindIntentAsync(textBoxFindIntent.Text);
				var sb = new StringBuilder();
				sb.AppendLine($"Intent: {response.Intent}");
				foreach (var app in response.Apps ?? Enumerable.Empty<AppMetadata>())
					sb.AppendLine($"  - {app.Name} ({app.AppId})");
				labelFindIntentResult.Text = sb.ToString().TrimEnd();
			}
			catch (Exception ex)
			{
				labelFindIntentResult.Text = $"Error: {ex.Message}";
			}
			finally
			{
				buttonFindIntent.Enabled = true;
			}
		}

		private async void buttonRaiseIntent_Click(object sender, EventArgs e)
		{
			buttonRaiseIntent.Enabled = false;
			try
			{
				var request = new RaiseIntentRequest
				{
					Intent = textBoxRaiseIntent.Text,
					Context = new ContextMetadata { Type = textBoxRaiseIntentContext.Text }
				};
				var response = await _container.Clients.FDC3Client.RaiseIntentAsync<ContextMetadata>(request);
				labelRaiseIntentResult.Text = $"Source: {response.Source}, Intent: {response.Intent}, Result type: {response.Result?.Type}";
			}
			catch (Exception ex)
			{
				labelRaiseIntentResult.Text = $"Error: {ex.Message}";
			}
			finally
			{
				buttonRaiseIntent.Enabled = true;
			}
		}

		private async void buttonGetActiveWorkspace_Click(object sender, EventArgs e)
		{
			buttonGetActiveWorkspace.Enabled = false;
			try
			{
				var result = await _container.Clients.WorkspaceClient.GetActiveWorkspace();
				labelActiveWorkspaceResult.Text = $"Active workspace: {result}";
			}
			catch (Exception ex)
			{
				labelActiveWorkspaceResult.Text = $"Error: {ex.Message}";
			}
			finally
			{
				buttonGetActiveWorkspace.Enabled = true;
			}
		}
	}
}
