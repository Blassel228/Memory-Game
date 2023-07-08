using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Memory_Game
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            GameFunctionalities.creatingTextBoxes(this, Convert.ToInt32(GameSettings.boardSize));
            foreach (Control control in Controls)
            {
                if (control is Button && control.BackColor == Color.SkyBlue)
                {
                    control.Enabled = true;
                    control.Click += Button_Click;
                }
            }
        }

        private void check2()
        {
            if (!timer2.Enabled)
            {
                foreach (Control control in Controls)
                {
                    if (control is Button && control.Name != "button1" && control.Name != "button2")
                    {
                        control.Enabled = false;
                        control.ForeColor = Color.Black;
                    }
                }
            }
        }

        void check1()
        {
            if (!timer1.Enabled)
            {
                foreach (Control control in Controls)
                {
                    if (control is Button && control.Name != "button1" && control.Name != "button2")
                    {
                        control.Enabled = true;
                        control.ForeColor = Color.SkyBlue;
                        control.BackColor = Color.SkyBlue;
                    }
                }
            }
        }
        static bool gameJustStarted = true;
        static int leftTiles = GameSettings.tilesNumber;
        static int leftLives = GameSettings.livesNumber;
        static int buttonCheck = GameSettings.clickOnButtonCheck;
        private void label4_Click(object sender, EventArgs e)
        {

        }

        void Button_Click(object sender, EventArgs e)
        {

            Button clickedButton = (Button)sender;
            if (clickedButton.Text == Convert.ToString(buttonCheck))
            {
                buttonCheck++;
                clickedButton.BackColor = Color.Green;
                clickedButton.ForeColor = Color.White;
                leftTiles--;
                tilesLeftLabel.Text = Convert.ToString(leftTiles);
            }

            else
            {
                clickedButton.BackColor = Color.Red;
                clickedButton.ForeColor = Color.Red;
                leftLives--;
                livesLeftLabel.Text = Convert.ToString(leftLives);
            }

            if (livesLeftLabel.Text == "-1")
            {
                livesLeftLabel.Text = "0";
                timer2.Stop();
                check2();
                MessageBox.Show("Your lives over and You lost, Try agin", "Ok");
            }

            if (tilesLeftLabel.Text == "0")
            {
                timer2.Stop();
                check2();
                MessageBox.Show($"You won in {timeLabel.Text}!", "Congratulations!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GameSettings.textboxesNames.Clear();
            gameJustStarted = true;
            leftTiles = GameSettings.tilesNumber;
            leftLives = GameSettings.livesNumber;
            buttonCheck = GameSettings.clickOnButtonCheck;
            livesLeftLabel.Text = Convert.ToString(GameSettings.livesNumber);
            tilesLeftLabel.Text = Convert.ToString(GameSettings.tilesNumber);
            palyerNameLabel.Text = GameSettings.playerName;
            timeLabel.Text = GameSettings.showingTime;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gameJustStarted = true;
            var time = Convert.ToDouble(timeLabel.Text) - 0.1;
            timeLabel.Text = Convert.ToString(Math.Round(time,2));
            if (gameJustStarted)
            {
                foreach (Control control in Controls)
                {
                    if (control is Button && control.Name != "button1" && control.Name != "button2")
                    {
                        control.Enabled = false;
                    }
                }
            }
            if (timeLabel.Text == "0")
            {
                timer1.Stop();
                gameJustStarted = false;
                check1();
                timer2.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start Playing")
            {
                GameFunctionalities.makingTiles(this);
                button1.Text = "Try again";
                timer1.Start();
            }
            else if (button1.Text == "Try again")
            {
                timer2.Stop();
                check2();
                foreach (Control control in Controls)
                {
                    if (control is Button && control.Name != "button1" && control.Name != "button2")
                    {
                        control.Text = "";
                        control.ForeColor = Color.SkyBlue;
                        control.BackColor = Color.SkyBlue;
                    }
                }
                
                livesLeftLabel.Text = Convert.ToString(GameSettings.livesNumber);
                tilesLeftLabel.Text = Convert.ToString(GameSettings.tilesNumber);
                timeLabel.Text = timeLabel.Text = GameSettings.showingTime;
                leftTiles = GameSettings.tilesNumber;
                leftLives = GameSettings.livesNumber;
                buttonCheck = GameSettings.clickOnButtonCheck;
                GameFunctionalities.makingTiles(this);
                timer1.Start(); //the start of timer2 is in timer1
                //when timer1 is off the buttons are on
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            var time = Convert.ToDouble(timeLabel.Text) + 0.1;
            timeLabel.Text = Convert.ToString(Math.Round(time, 2));
        }
    }
}
