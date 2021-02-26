using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

//  Author: Schulte Marc-Rafael
//  Created: 25.02.2021
//  Last Change: 25.02.2021
//  Description: Menu, connect to game-server

namespace Client
{
    public partial class Form_Menu : Form
    {
        //private IPHostEntry host;
        private IPAddress ipAdress;
        private IPEndPoint endPoint;
        private Socket playerSocket;
        

        private delegate void ListeningThread();
        private ListeningThread listeningThreadPtr;

        private string ipAdress_string { get; set; }
        private int port { get; set; }

        public Form_Menu()
        {
            InitializeComponent();
        }

        private bool checkConnectionSettings()
        {
            if(txtBx_ip.Text.Length != 0)
            {
                ipAdress_string = txtBx_ip.Text;
            }
            else
            {
                return false;
            }

            if(txtBx_port.Text.Length != 0)
            {
                try
                {
                    port = Convert.ToInt32(txtBx_port.Text);
                    return true;
                    
                }catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void startLobby()
        {
            try
            {
                Form_Lobby lobby = new Form_Lobby(playerSocket, endPoint);
                this.Hide();
                lobby.ShowDialog();
                this.Close();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setup()
        {
            if (checkConnectionSettings())
            {
                ipAdress = IPAddress.Parse(ipAdress_string);
                endPoint = new IPEndPoint(ipAdress, port);
                playerSocket = new Socket(ipAdress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            }
            else
            {
                MessageBox.Show("Bitte überprüfe deine Eingabe");
                return;
            }            
        }

        private void startListening()
        {
            
        }

        private void btn_join_Click(object sender, EventArgs e)
        {
            setup();
            startLobby();
        }
    }
}
