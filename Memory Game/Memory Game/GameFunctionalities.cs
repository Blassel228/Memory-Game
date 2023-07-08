using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Game
{

    internal class GameFunctionalities
    {
        private static Random random = new Random();
        public static void makingTiles(Form form) //generates numbers in buttons
        {
            for(int i = 1; i < GameSettings.tilesNumber+1; i++)
            {
                while (true)
                {
                    int randInt = random.Next(0, form.Controls.Count);
                    Control randControl = form.Controls[randInt];
                    if (randControl is Button && randControl.Name != "button1" && randControl.Name != "button2")
                    {
                        if (randControl.Text != "")
                        {
                            continue;
                        }
                        else
                        {
                            randControl.Text = Convert.ToString(i);
                            break;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            
            //Random random = new Random();   
            //Random random1 = new Random();

                //for (int i = 1; i < Convert.ToInt32(GameSettings.tilesNumber+1); i++)
                //{
                //    int firstNum = random1.Next(1, GameSettings.boardSize + 1);
                //    int secondNum = random1.Next(1, GameSettings.boardSize + 1);
                //    foreach (Control control in form.Controls)
                //    {
                //        if (control is Button && control.BackColor == Color.SkyBlue)
                //        {
                //            if (control.Name == $"{firstNum}_{secondNum}")
                //            {
                //                if (control.Text != string.Empty)
                //                {
                //                    firstNum = random1.Next(1, GameSettings.boardSize + 1);
                //                    secondNum = random1.Next(1, GameSettings.boardSize + 1);
                //                    continue;
                //                }
                //                else
                //                {
                //                    control.Text = Convert.ToString(i);
                //                    continue;
                //                }
                //            }
                //        }
                //    }
                //}
        }


        public static void creatingTextBoxes(Form form, int gameBoardSize)
        {
            int x = 202;
            int formwidthX = x;
            int y = 35;
            int formwidthY = y;
            for (int i = 0; i < gameBoardSize; i++)
            {
                for (int j = 0; j < gameBoardSize; j++)
                {
                    Button tb = new Button();
                    tb.Name = $"{i}_{j}";
                    tb.Text = "";
                    tb.Font = new Font("Arial", 20);
                    tb.Width = 70;
                    tb.Height = 50;
                    tb.BackColor = Color.SkyBlue;
                    tb.Location = new Point(x, y);
                    tb.Enabled = false;
                    //tb.Click += Button_Click();
                    form.Controls.Add(tb);
                    x += 60;
                    
                }
                x = 202;
                y += 50;
            } 
        }

        //void Button_Click(object sender, EventArgs e, Button buttonName)
        //{
        //    if (buttonName.Text == Convert.ToString(GameSettings.clickOnButtonCheck))
        //    {
        //        buttonName.BackColor = Color.Green;
        //        GameSettings.clickOnButtonCheck++;
        //    }
        //    else
        //    {
        //        buttonName.BackColor = Color.Red;
        //    }
        //}
    }
}
