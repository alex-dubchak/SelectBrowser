using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SelectBrowser {
	/// <summary>
	/// Interaction logic for Options.xaml
	/// </summary>
	public partial class Options : Window {
		public Options() {
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e) {
			ColumnDefinition colLabel = new ColumnDefinition();
			ColumnDefinition colImage = new ColumnDefinition();
			ColumnDefinition colCheckBox = new ColumnDefinition();
			colLabel.Width = GridLength.Auto;
			content.ColumnDefinitions.Add(colLabel);
			
			Label label = new Label();
			

		}
	}
}
