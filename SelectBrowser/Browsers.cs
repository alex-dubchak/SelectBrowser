using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Configuration;

namespace SelectBrowser {
	internal class Browsers  {
		public List<Browser> items;
		
		public Browsers() {
			items = new List<Browser>();
		}

		public void Load() {
			LoadFromRegistry();
		}

		public Browser this [int i]{
			get { return items[i]; }
		}

		

		private void LoadFromRegistry() {
			RegistryKey startMenuInternet = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
			foreach (string key in startMenuInternet.GetSubKeyNames()) {
				RegistryKey browserKey = startMenuInternet.OpenSubKey(key);
				items.Add(Browser.Load(browserKey, key));
			}
		}

	}
}
