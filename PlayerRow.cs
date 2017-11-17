using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BabyMonitor {
    public partial class PlayerRow : UserControl {
        public PlayerData ToDisplay {
            set {
                m_toDisplay = value;

                if ( m_toDisplay != null ) {
                    lblPlayerName.Text = m_toDisplay.SteamName;
                    if ( !string.IsNullOrEmpty(m_toDisplay.ProName) ) {
                        lblPlayerName.Text += string.Format( "({0})", m_toDisplay.ProName );
                    }
                }
            }
        }
        private PlayerData m_toDisplay = null;

        public bool IsActive {
            get {
                return chkActive.Checked;
            }
        }

        public int Deaths {
            get {
                int handicap = 0;

                int.TryParse( txtHandicap.Text, out handicap );

                return m_toDisplay.Deaths + handicap;
            }
        }

        public string PlayerName {
            get {
                return string.IsNullOrEmpty( txtOverrideName.Text ) ? m_toDisplay.SteamName : txtOverrideName.Text;
            }
        }

        public PlayerRow() {
            InitializeComponent();
        }
    }
}
