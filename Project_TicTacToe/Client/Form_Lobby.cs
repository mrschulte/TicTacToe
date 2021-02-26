using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

//  Author: Schulte Marc-Rafael
//  Created: 26.02.2021
//  Last Change: 26.02.2021
//  Description: Lobby, waiting until 2 players are ready

namespace Client
{
    public partial class Form_Lobby : Form
    {

        private Thread listeningThread;
        private Socket playerSocket;
        private IPEndPoint endPoint;

        private delegate void ListeningThread();
        private ListeningThread listeningThreadPtr;

        public Form_Lobby(Socket playerSocket, IPEndPoint endPoint)
        {
            InitializeComponent();
            this.playerSocket = playerSocket;
            this.endPoint = endPoint;
            listeningSetup();
        }

        private void listening()
        {
            System.Diagnostics.Debug.WriteLine("Im now listening...");
            playerSocket.Connect(endPoint);

            try
            {
                byte[] bytes = new byte[1024];
                string data = "";
                while (true)
                {

                    while(true)
                    {
                        int bytesRecieved = playerSocket.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRecieved);
                        System.Diagnostics.Debug.WriteLine(data);

                        if(data.Contains("[SETUP]"))
                        {
                            int player_id = Convert.ToInt32(data[0].ToString());
                            System.Diagnostics.Debug.WriteLine("This is Player " + player_id);
                            if(player_id == 1)
                            {
                                label_state1.Invoke((MethodInvoker)delegate { label_state1.Text = "Bereit";  });
                            }
                            else
                            {
                                label_state1.Invoke((MethodInvoker)delegate { label_state1.Text = "Bereit"; });
                                label_state2.Invoke((MethodInvoker)delegate { label_state2.Text = "Bereit"; });
                                playerSocket.Send(Encoding.ASCII.GetBytes("[READY]"));
                            }
                            break;
                        }
                        else
                        if(data.Contains("[START]"))
                        {
                            System.Diagnostics.Debug.WriteLine("Game starting...");
                            Form_Match match = new Form_Match();
                            this.Invoke((MethodInvoker)delegate { this.Hide(); });
                            match.ShowDialog();
                            this.Invoke((MethodInvoker)delegate { this.Close(); });
                            break;
                        }
                    }
                    data = "";
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void listeningSetup()
        {
            listeningThreadPtr = new ListeningThread(listening);
            listeningThread = new Thread(listeningThreadPtr.Invoke);
            listeningThread.Start();
        }
    }
}
