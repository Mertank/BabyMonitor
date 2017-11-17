using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyMonitor {
    public class SpectatorPlayerNode {
        private PlayerData[] m_players = null;
        public PlayerData[] Players {
            get {
                if ( m_players == null ) {
                    ParsePlayers();
                }

                return m_players;
            }
        }

        private string  m_json       = "";
        private JObject m_parsedData = null;

        public SpectatorPlayerNode( string data ) {
            if ( string.IsNullOrEmpty(data) ) {
                data = "{}";
            }

            m_json          = data;
            m_parsedData    = JObject.Parse( m_json );
        }

        private void ParsePlayers() {
            List<PlayerData> players = new List<PlayerData>();

            foreach ( KeyValuePair<string, JToken> teamNodes in m_parsedData ) {
                JObject team = ( JObject )teamNodes.Value;

                
                foreach ( KeyValuePair<string, JToken> playerNode in team ) {
                    JObject player = ( JObject )playerNode.Value;

                    players.Add( new PlayerData( player.ToString() ) );
                }
            }

            m_players = players.ToArray();
        }
    }
}
