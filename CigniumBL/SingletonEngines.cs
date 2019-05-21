using CigniumBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CigniumBL
{
    public class SingletonEngines
    {
        private static SingletonEngines instance = null;
        public List<SearchEngines> searchEngines = null;

        protected SingletonEngines() {
            //here we can call to a database
            searchEngines = new List<SearchEngines>();
            searchEngines.Add(new SearchEngines { id = 1, name = "google", url = "http://wwww.google.com" });
            searchEngines.Add(new SearchEngines { id = 2, name = "bing", url = "http://wwww.bing.com" });
            searchEngines.Add(new SearchEngines { id = 3, name = "yahoo", url = "http://wwww.yahoo.com" });
        }

        public static SingletonEngines Instance
        {
            get
            {
                if (instance == null)
                    instance = new SingletonEngines();

                return instance;
            }
        }
    }
}
