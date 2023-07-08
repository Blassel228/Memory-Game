using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Game
{
    internal class GameSettings
    {
        public static int boardSize;
        public static int livesNumber;
        public static string showingTime;
        public static int tilesNumber;
        public static string playerName;
        public static List<Button> textboxesNames = new List<Button>();
        public static int clickOnButtonCheck = 1;
    }
}
