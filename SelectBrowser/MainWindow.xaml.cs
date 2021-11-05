using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Brush = System.Windows.Media.Brush;
using Image = System.Windows.Controls.Image;

namespace SelectBrowser {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}
		
		
		private ContextMenu menu;
		private Browsers browsers;
		
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			
			Button button;
			browsers = new Browsers();
			browsers.Load();

			foreach (Browser browser in browsers.items) {
				button = new Button {
					Name = browser.Key.Replace(".", "").Replace(" ", ""),
					Tag = browser,
					Width = 150,
					Height = 50,
					ToolTip = browser.Name
				};
				

				if (browser.Icon != null) {
					button.Content = new Image() { Source = IconUtilities.ToImageSource(browser.Icon) };
				} else {
					button.Content = browser.Name;
				}
				button.Click += button_Click;
				
				
				stackPanel1.Children.Add(button);
			}
			
			
			
			button = new Button {Content = "Cancel"};
			button.Click += button_ClickCancel;
			stackPanel1.Children.Add(button);

		}
		
		private void CreateMenu()
		{
			menu = new ContextMenu();
			MenuItem menuItem = new MenuItem();

			menu.Items.Add(new MenuItem() {});
		}

		
		void button_ClickCancel(object sender, RoutedEventArgs e) {
			App.Current.Shutdown();
		}

		void button_Click(object sender, RoutedEventArgs e) {
			
			Browser brawser = ((Button)sender).Tag as Browser;
			Process browserApp = new Process();
			browserApp.StartInfo.FileName = brawser.Path;
			browserApp.StartInfo.Arguments = App.Url;
			browserApp.Start();
			App.Current.Shutdown();
		}
	}
}
