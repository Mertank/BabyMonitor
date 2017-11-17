using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyMonitor {
    public class SpectatorGameState {
        private JObject m_parsedData = null;
        private string  m_jsonObject = "";

        public SpectatorGameState(string json) {
            if ( string.IsNullOrEmpty(json) ) {
                json = "{}";
            }

            m_jsonObject = json;
            m_parsedData = JObject.Parse( json );
        }

        private SpectatorPlayerNode m_parsedPlayer = null;
        public SpectatorPlayerNode Player {
            get {
                if ( m_parsedPlayer == null ) {
                    m_parsedPlayer = new SpectatorPlayerNode( GetNode( "player" ) );
                }

                return m_parsedPlayer;
            }
        }

        private string GetNode( string name ) {
            JToken value;

            if ( m_parsedData.TryGetValue( name, out value ) ) {
                return value.ToString();
            } else {
                return "";
            }
        }
    }
}
