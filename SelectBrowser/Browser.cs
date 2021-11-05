using System.Windows.Media;
using Microsoft.Win32;
using System;
using System.Configuration;

namespace SelectBrowser {
	internal class Browser {

		protected string path;
		protected System.Drawing.Icon icon;
		protected string name;
		protected bool hide;
		protected string key;


		public string Path {
			get { return path; }
			set { path = value; }
		}
		public System.Drawing.Icon Icon {
			get { return icon; }
			set { icon = value; }
		}
		public string Name {
			get { return name; }
			set { name = value; }
		}
		
		public bool Hide {
			get { return hide; }
			set { hide = value; }
		}
		
		public string Key {
			get { return key.ToString(); }
			set { key = value; }
		}

		public static Browser Load(RegistryKey browserKey, string key) {
			Browser browser = new Browser();
			browser.Name = browserKey.GetValue("").ToString() ;
			browser.Path = (string)browserKey.OpenSubKey(@"shell\open\command").GetValue("");
			try{
				browser.Icon = System.Drawing.Icon.ExtractAssociatedIcon(((string)browserKey.OpenSubKey("DefaultIcon").GetValue("")).Split(new char[] { ',' })[0]);
			}catch(Exception){}
			browser.Key = key;
			return browser;
		}
	}
}
