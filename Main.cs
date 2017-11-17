using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BabyMonitor {
    public partial class Main : Form {
        private Dota2UpdateListener m_listener = null;

        List<PlayerRow> m_currentRows = new List<PlayerRow>();

        public Main() {
            InitializeComponent();

            this.Icon = BabyMonitor.Properties.Resources.baby_rage1;
        }

        private void Main_Load( object sender, EventArgs e ) {
            m_listener = new Dota2UpdateListener();

            m_listener.NewGameState += NewGameStateReceived;

            m_listener.Start();

            this.FormClosing += Main_FormClosing;
        }

        private void Main_FormClosing( object sender, FormClosingEventArgs e ) {
            if ( m_listener != null ) {
                m_listener.Stop();
            }
        }

        private void NewGameStateReceived( SpectatorGameState gs ) {
            SpectatorPlayerNode playerData      = gs.Player;
            PlayerData[]        possiblePlayers = playerData.Players;

            while ( m_currentRows.Count < possiblePlayers.Length ) {
                PlayerRow row = new PlayerRow();
                m_currentRows.Add( row );
                pnlPlayers.Controls.Add( row );

                if ( m_currentRows.Count > 1 ) {
                    row.Location = new Point( row.Location.X, m_currentRows[ m_currentRows.Count - 2 ].Bottom );
                }
            }

            for ( int i = 0; i < possiblePlayers.Length; ++i ) {
                m_currentRows[ i ].ToDisplay = possiblePlayers[i];
            }

            UpdateFile();
        }

        private void UpdateFile() {
            List<string> toWrite = new List<string>();

            foreach ( PlayerRow row in m_currentRows ) {
                if ( row.IsActive ) {
                    toWrite.Add( string.Format( "{0} deaths: {1}", row.PlayerName, row.Deaths ) );
                }
            }

            if ( toWrite.Count > 0 ) {
                System.IO.File.WriteAllLines( "idc.txt", toWrite );
            }
        }
    }
}
