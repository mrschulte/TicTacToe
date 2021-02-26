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
        

        private ServerCommunication serverComm;

        public Form_Lobby(ServerCommunication serverComm)
        {
            InitializeComponent();
            this.serverComm = serverComm;
            serverComm.lobby = this;
        }

        public void setState1(string text)
        {
            label_state1.Text = text;
        }

        public void setState2(string text)
        {
            label_state2.Text = text;
        }

        private void Form_Lobby_Load(object sender, EventArgs e)
        {
            serverComm.listeningSetup();
        }

       
    }
}
