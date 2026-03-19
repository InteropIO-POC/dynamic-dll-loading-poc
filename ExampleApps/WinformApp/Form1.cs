using Container.Interfaces;
using System;
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
			var info = _container.WindowClient.GetRuntimeInfo();
			Invoke((Action)(() =>
			{
				labelStatusValue.Text = "Connected";
				labelPlatform.Text = $"Platform: {info.Platform}";
				labelVersion.Text = $"Container.Impl version: {info.ContainerImplVersion}";
				buttonOpen.Enabled = true;
			}));
		}

		private async void buttonOpen_Click(object sender, EventArgs e)
		{
			buttonOpen.Enabled = false;
			await _container.FDC3Client.Open(textBoxAppName.Text);
			buttonOpen.Enabled = true;
		}
	}
}
