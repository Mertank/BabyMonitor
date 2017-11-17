using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyMonitor {
    public class PlayerData {
        private string  m_json          = "";
        private JObject m_parsedData    = null;

        public string SteamName {
            get {
                return m_parsedData.Value<string>( "name" );
            }
        }

        public string ProName {
            get {
                return m_parsedData.Value<string>( "pro_name" );
            }
        }

        public int Deaths {
            get {
                return m_parsedData.Value<int>( "deaths" );
            }
        }

        public PlayerData(string json) {
            if ( string.IsNullOrEmpty(json) ) {
                json = "{}";
            }

            m_json          = json;
            m_parsedData    = JObject.Parse( m_json );
        }
    }
}
