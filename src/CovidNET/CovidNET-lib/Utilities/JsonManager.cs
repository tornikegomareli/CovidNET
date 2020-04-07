using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CovidNET_lib.Utilities
{
    internal class JsonManager
    {
        private JsonManager()
        {
        }

        private static JsonManager _instance;
        private static object _lockRoot = new object();
        private JObject CovidJObj { get; set; }


        internal string JsonSource { get; set; }
        internal static JsonManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instance)
                    {
                        if (_instance == null)
                        {
                            _instance = new JsonManager();
                        }
                    }
                }
                return _instance;
            }
        }

        internal string FindElementFromkey(string key)
        {
            CovidJObj = (JObject)JsonConvert.DeserializeObject(JsonSource);

            var element = CovidJObj[key].Value<string>();

            return element;
		}
    }
}
