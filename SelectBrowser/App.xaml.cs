using System.Windows;

namespace SelectBrowser {
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private static string url;

		public static string Url
		{
			get { return url; }
			set { url = value; }
		}

		protected void Application_Startup(object sender, StartupEventArgs e)
		{
			//System.Threading.Thread.Sleep(10*1000);
			if (e.Args.Length == 0)
			{
				
				//Current.Shutdown(); 
				return;
			}
			
			Url = e.Args[0];
		}
	}
}
