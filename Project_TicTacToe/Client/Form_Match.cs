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

        public bool allowed { get; set; }

        public Form_Match(int player_id, ServerCommunication serverComm)
        {
            InitializeComponent();
            clickedBoxes = new List<int>();
            this.serverCom = serverComm;
            this.player_id = player_id;

            serverCom.lobby.Invoke((MethodInvoker)delegate { serverCom.lobby.Close(); });

            if (player_id == 1)
            {
                showMessage("Du bist dran!");
                allowed = true;
            }
            else
            {
                showMessage("Spieler 1 ist dran");
                allowed = false;
            }
        }

        public void showMessage(string message)
        {
            label_message.Text = message;
        }

        public void setWinMessage()
        {
            label_end.Text = "Du hast gewonnen!";
        }

        public void setLooseMessage()
        {
            label_end.Text = "Du hast verloren!";
        }

        public void setNoWinMessage()
        {
            label_end.Text = "Keiner hat gewonnen!";
        }

        public void showButton()
        {
            btn_rejoin.Visible = true;
        }

        public void changeBox(Color color, int box)
        {
            Control[] con = Controls.Find("feld" + box, false);
            PictureBox picbox = (PictureBox) con[0];
            picbox.BackColor = color;
        }

        public void newGame()
        {
            for(int i = 1; i < 10; i++)
            {
                Control[] con = Controls.Find("feld" + i, false);
                PictureBox picbox = (PictureBox)con[0];
                picbox.BackColor = Color.Gray;
            }
            clickedBoxes.Clear();
            btn_rejoin.Visible = false;
            label_end.Text = "";
            if (player_id == 1)
            {
                showMessage("Du bist dran!");
                allowed = true;
            }
            else
            {
                showMessage("Spieler 1 ist dran");
                allowed = false;
            }
        }

        public void changeState()
        {
            if(allowed)
            {
                allowed = false;
                if(player_id == 1)
                {
                    showMessage("Spieler 2 ist dran");
                }
                else
                {
                    showMessage("Spieler 1 ist dran");
                }
            }
            else
            {
                allowed = true;
                showMessage("Du bist dran");
            }
        }

        private void feld1_Click(object sender, EventArgs e)
        {
            if (allowed)
            {
                if (!clickedBoxes.Contains(1))
                {
                    try
                    {
                        serverCom.playerSocket.Send(Encoding.ASCII.GetBytes("1;" + player_id + ";[MOVE]"));
                        System.Diagnostics.Debug.WriteLine("Sent");
                        clickedBoxes.Add(1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                } 
            }
        }

        private void feld2_Click(object sender, EventArgs e)
        {
            if (allowed)
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
        }

        private void feld3_Click(object sender, EventArgs e)
        {
            if (allowed)
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
        }

        private void feld4_Click(object sender, EventArgs e)
        {
            if (allowed)
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
        }

        private void feld5_Click(object sender, EventArgs e)
        {
            if (allowed)
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
        }

        private void feld6_Click(object sender, EventArgs e)
        {
            if (allowed)
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
        }

        private void feld7_Click(object sender, EventArgs e)
        {
            if (allowed)
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
        }

        private void feld8_Click(object sender, EventArgs e)
        {
            if (allowed)
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
        }

        private void feld9_Click(object sender, EventArgs e)
        {
            if (allowed)
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

        private void btn_rejoin_Click(object sender, EventArgs e)
        {
            serverCom.restart();
        }
    }
}
