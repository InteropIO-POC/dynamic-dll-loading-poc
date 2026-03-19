using Container.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
			var info = _container.WindowClient.GetRuntimeInfo();
			Dispatcher.Invoke(() =>
			{
				StatusText.Text = "Connected";
				PlatformText.Text = $"Platform: {info.Platform}";
				VersionText.Text = $"Container.Impl version: {info.ContainerImplVersion}";
				OpenButton.IsEnabled = true;
			});
		}

		private async void OpenButton_Click(object sender, RoutedEventArgs e)
		{
			OpenButton.IsEnabled = false;
			await _container.FDC3Client.Open(AppNameInput.Text);
			OpenButton.IsEnabled = true;
		}
	}
}
