using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

//  Author: Schulte Marc-Rafael
//  Created: 26.02.2021
//  Last Change: 26.02.2021
//  Description: Class for the communication between server and client


namespace Client
{
    public class ServerCommunication
    {

        public string ipAdresse_string { get; set; }
        public int port { get; set; }

        public IPAddress ipAdress { get; set; }
        public IPEndPoint endPoint { get; set; }
        public Socket playerSocket { get; set; }

        private delegate void ListeningThread();
        private ListeningThread listeningThreadPtr;
        private Thread listeningThread;

        public Form_Lobby lobby = null;
        public Form_Match match = null;

        public ServerCommunication()
        {

        }

        public void setup()
        {
            ipAdress = IPAddress.Parse(ipAdresse_string);
            endPoint = new IPEndPoint(ipAdress, port);
            playerSocket = new Socket(ipAdress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public void listening()
        {
            System.Diagnostics.Debug.WriteLine("Im now listening...");
            playerSocket.Connect(endPoint);

            try
            {
                byte[] bytes = new byte[1024];
                string data = "";
                int player_id = 0;
                while (true)
                {

                    while (true)
                    {
                        int bytesRecieved = playerSocket.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRecieved);
                        System.Diagnostics.Debug.WriteLine(data);

                        if (data.Contains("[SETUP]"))
                        {
                            player_id = Convert.ToInt32(data[0].ToString());
                            System.Diagnostics.Debug.WriteLine("This is Player " + player_id);
                            if (player_id == 1)
                            {
                                lobby.Invoke((System.Windows.Forms.MethodInvoker)delegate { lobby.setState1("Bereit"); });
                            }
                            else
                            {
                                lobby.Invoke((System.Windows.Forms.MethodInvoker)delegate { lobby.setState1("Bereit"); });
                                lobby.Invoke((System.Windows.Forms.MethodInvoker)delegate { lobby.setState2("Bereit"); });
                                playerSocket.Send(Encoding.ASCII.GetBytes("[READY]"));
                            }
                            break;
                        }
                        else
                        if (data.Contains("[START]"))
                        {
                            System.Diagnostics.Debug.WriteLine("Game starting...");
                            match = new Form_Match(player_id, this);
                            lobby.Invoke((MethodInvoker)delegate { lobby.Hide(); });
                            match.ShowDialog();
                            lobby.Invoke((MethodInvoker)delegate { lobby.Close(); });
                            break;
                        }
                        else
                        if(data.Contains("[MOVE]"))
                        {
                            
                            if(data.Contains("[WIN]"))
                            {
                                int player = Convert.ToInt32(data[5].ToString());
                                int box = Convert.ToInt32(data[7].ToString());
                                updateBoxes(player, box);
                            }
                            else
                            {
                                int player = Convert.ToInt32(data[0].ToString());
                                int box = Convert.ToInt32(data[2].ToString());
                                updateBoxes(player, box);
                            }
                        }
                    }
                    data = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void updateBoxes(int player, int box)
        {
            if(player == 1)
            {
                if(!match.clickedBoxes.Contains(box))
                {
                    match.clickedBoxes.Add(box);
                }

                match.Invoke((MethodInvoker)delegate { match.changeBox(System.Drawing.Color.Red, box); });

            }
            else
            {
                if (!match.clickedBoxes.Contains(box))
                {
                    match.clickedBoxes.Add(box);
                }

                match.Invoke((MethodInvoker)delegate { match.changeBox(System.Drawing.Color.Blue, box); });
            }
        }

        public void listeningSetup()
        {
            listeningThreadPtr = new ListeningThread(listening);
            listeningThread = new Thread(listeningThreadPtr.Invoke);
            listeningThread.Start();
        }

    }
}
