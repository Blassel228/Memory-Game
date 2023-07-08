using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Memory_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void check(Control name)
        {
            
        }
        private void readOnly(bool boolean)
        {
            BoardSizeBox.ReadOnly = boolean;
            LivesNumberBox.ReadOnly = boolean;
            ShowingTimeBox.ReadOnly = boolean;
            TilesNumberBox.ReadOnly = boolean;
        }
        private void assigningGameSettings()
        {
            GameSettings.boardSize= Convert.ToInt32(BoardSizeBox.Text);
            GameSettings.livesNumber = Convert.ToInt32(LivesNumberBox.Text);
            GameSettings.showingTime = ShowingTimeBox.Text;
            GameSettings.tilesNumber = Convert.ToInt32(TilesNumberBox.Text);
            GameSettings.playerName = playerNameBox.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedItem)
            {
                case "Easius":
                    BoardSizeBox.Text = "4";
                    LivesNumberBox.Text = "3";
                    ShowingTimeBox.Text = "2";
                    TilesNumberBox.Text = "4";
                    readOnly(true);
                    break;
                case "Medius":
                    BoardSizeBox.Text = "5";
                    LivesNumberBox.Text = "2";
                    ShowingTimeBox.Text = "2";
                    TilesNumberBox.Text = "5";
                    readOnly(true);
                    break;
                case "Hardius":
                    BoardSizeBox.Text = "7";
                    LivesNumberBox.Text = "1";
                    ShowingTimeBox.Text = "1,5";
                    TilesNumberBox.Text = "8";
                    readOnly(true);
                    break;
                case "Custom":
                    readOnly(false);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //checks wether any textbox is empty
            if (playerNameBox.Text == string.Empty)
            {
                MessageBox.Show("Enter player name", "Error");
                return;
            }
            if ((BoardSizeBox.Text == string.Empty) || (Convert.ToInt32(BoardSizeBox.Text) <= 1))
            {
                MessageBox.Show("Enter valid size", "Error");
                return;
            }
            if ((ShowingTimeBox.Text == string.Empty) || (Convert.ToDouble(ShowingTimeBox.Text) <= 0))
            {
                MessageBox.Show("Enter valid time", "Error");
                return;
            }
            if ((LivesNumberBox.Text == string.Empty) || (Convert.ToInt32(LivesNumberBox.Text) <= 0))
            {
                MessageBox.Show("Enter valid number of lives", "Error");
                return;
            }
            if ((TilesNumberBox.Text == string.Empty)  || (Convert.ToInt32(TilesNumberBox.Text) <= 0))
            {
                MessageBox.Show("Enter valid number of lives", "Error");
                return;
            }

            try
            {
                var size = Convert.ToInt32(BoardSizeBox.Text)*Convert.ToInt32(BoardSizeBox.Text);
                if (Convert.ToInt32(TilesNumberBox.Text) > size)
                {
                    MessageBox.Show("There are to many tiles", "Error");
                }
                else
                {
                    assigningGameSettings();
                    Form2 fm2 = new Form2();
                    fm2.Show();
                    this.Hide();
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("You can enter only digits", "Error");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GameSettings.textboxesNames.Clear();
        }

        private void LivesNumberBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ShowingTimeBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TilesNumberBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
