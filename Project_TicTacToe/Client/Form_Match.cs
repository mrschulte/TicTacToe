using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_Match : Form
    {
        private int player_id { get; set; }
        public List<int> clickedBoxes;
        private ServerCommunication serverCom;

        public Form_Match(int player_id, ServerCommunication serverComm)
        {
            InitializeComponent();
            clickedBoxes = new List<int>();
            this.serverCom = serverComm;
            this.player_id = player_id;
            
            if(player_id == 1)
            {
                showMessage("Du bist dran!");
            }
            else
            {
                showMessage("Spieler 1 ist dran");
            }
        }

        public void showMessage(string message)
        {
            label_message.Text = message;
        }

        public void changeBox(Color color, int box)
        {
            Control[] con = Controls.Find("feld" + box, false);
            PictureBox picbox = (PictureBox)con[0];
            picbox.BackColor = color;

        }

        private void feld1_Click(object sender, EventArgs e)
        {
            if(!clickedBoxes.Contains(1))
            {
                try
                {
                    serverCom.playerSocket.Send(Encoding.ASCII.GetBytes("1;" + player_id + ";[MOVE]"));
                    clickedBoxes.Add(1);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void feld2_Click(object sender, EventArgs e)
        {
            if (!clickedBoxes.Contains(2))
            {
                try
                {
                    serverCom.playerSocket.Send(Encoding.ASCII.GetBytes("2;" + player_id + ";[MOVE]"));
                    clickedBoxes.Add(2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void feld3_Click(object sender, EventArgs e)
        {
            if (!clickedBoxes.Contains(3))
            {
                try
                {
                    serverCom.playerSocket.Send(Encoding.ASCII.GetBytes("3;" + player_id + ";[MOVE]"));
                    clickedBoxes.Add(3);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void feld4_Click(object sender, EventArgs e)
        {
            if (!clickedBoxes.Contains(4))
            {
                try
                {
                    serverCom.playerSocket.Send(Encoding.ASCII.GetBytes("4;" + player_id + ";[MOVE]"));
                    clickedBoxes.Add(4);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void feld5_Click(object sender, EventArgs e)
        {
            if (!clickedBoxes.Contains(5))
            {
                try
                {
                    serverCom.playerSocket.Send(Encoding.ASCII.GetBytes("5;" + player_id + ";[MOVE]"));
                    clickedBoxes.Add(5);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void feld6_Click(object sender, EventArgs e)
        {
            if (!clickedBoxes.Contains(6))
            {
                try
                {
                    serverCom.playerSocket.Send(Encoding.ASCII.GetBytes("6;" + player_id + ";[MOVE]"));
                    clickedBoxes.Add(6);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void feld7_Click(object sender, EventArgs e)
        {
            if (!clickedBoxes.Contains(7))
            {
                try
                {
                    serverCom.playerSocket.Send(Encoding.ASCII.GetBytes("7;" + player_id + ";[MOVE]"));
                    clickedBoxes.Add(7);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void feld8_Click(object sender, EventArgs e)
        {
            if (!clickedBoxes.Contains(8))
            {
                try
                {
                    serverCom.playerSocket.Send(Encoding.ASCII.GetBytes("8;" + player_id + ";[MOVE]"));
                    clickedBoxes.Add(8);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void feld9_Click(object sender, EventArgs e)
        {
            if (!clickedBoxes.Contains(9))
            {
                try
                {
                    serverCom.playerSocket.Send(Encoding.ASCII.GetBytes("9;" + player_id + ";[MOVE]"));
                    clickedBoxes.Add(9);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
