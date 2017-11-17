using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BabyMonitor {
    public delegate void NewGameStateHandler( SpectatorGameState gamestate );

    class Dota2UpdateListener {
        private HttpListener        m_httpListener      = null;
        private bool                m_isRunning         = false;
        private AutoResetEvent      m_waitForConn       = new AutoResetEvent(false);

        private SpectatorGameState  m_currentGameState  = null;
        
        public SpectatorGameState CurrentGameState {
            get {
                return m_currentGameState;
            }
            private set {
                m_currentGameState = value;
                RaiseOnNewGameState();
            }
        }

        public event NewGameStateHandler NewGameState = delegate { };

        public Dota2UpdateListener() {
            m_httpListener = new HttpListener();
            m_httpListener.Prefixes.Add( "http://localhost:3000/" );
        }

        public bool Start() {
            if ( !m_isRunning ) {
                Thread listenerThread = new Thread( new ThreadStart( Run ) );

                try {
                    m_httpListener.Start();
                } catch ( HttpListenerException ) {
                    return false;
                }

                m_isRunning = true;

                listenerThread.IsBackground = true;
                listenerThread.Start();

                return true;
            }

            return false;
        }

        private void Run() {
            while ( m_isRunning ) {
                m_httpListener.BeginGetContext( ReceiveGameState, m_httpListener );
                m_waitForConn.WaitOne();
                m_waitForConn.Reset();
            }

            m_httpListener.Stop();
        }

        public void Stop() {
            m_isRunning = false;
        }

        private void ReceiveGameState( IAsyncResult result ) {
            try {
                HttpListenerContext context = m_httpListener.EndGetContext( result );
                HttpListenerRequest request = context.Request;

                string gameStateJSON = "";

                m_waitForConn.Set();

                using ( Stream inputStream = request.InputStream ) {
                    using ( StreamReader sr = new StreamReader(inputStream) ) {
                        gameStateJSON = sr.ReadToEnd();
                    }
                }

                using ( HttpListenerResponse response = context.Response ) {
                    response.StatusCode         = ( int )HttpStatusCode.OK;
                    response.StatusDescription  = "OK";
                    response.Close();
                }

                CurrentGameState = new SpectatorGameState( gameStateJSON );
            } catch ( ObjectDisposedException ) {
                // Intentionally left blank, when the Listener is closed.
            }
        }

        private void RaiseOnNewGameState() {
            foreach ( Delegate d in NewGameState.GetInvocationList() ) {
                if ( d.Target is ISynchronizeInvoke )
                    ( d.Target as ISynchronizeInvoke ).BeginInvoke( d, new object[] { CurrentGameState } );
                else
                    d.DynamicInvoke( CurrentGameState );
            }
        }
    }
}
