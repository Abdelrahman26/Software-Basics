using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakesLadders
{
    
    public partial class Form1 : Form
    {
        static int playerTurnFlag;
        static int OrangeX, OrangeY;
        static int BlueX, BlueY;
        static bool orangeFlag, blueFlag;
        static int distanceX = 64, distanceY = 43;
        static int bluecurcellNum;
        static int orangecurcellNum;
        static int LTRB; // left-to-right-blue
        static int BTUB; // bottom-to-up-blue
        static int LTRO;
        static int BTUO;
        static int dice;
        static int endRowB;
        static int endRowO;
        //ladders (src num, des num)
        static Dictionary<int, int> ladders;
        //laddersPoint (dest num, point(x, y))
        static Dictionary<int, Point> laddersPoint;
        //laddersDirection(dest num, direction LTR in this row)
        static Dictionary<int, int> laddersDirection;
        //ladderDictionary(dest num, endrow)
        static Dictionary<int, int> laddersEndRow;

        //snakes (src num, des num)
        static Dictionary<int, int> snakes;
        //snakesPoint (dest num, point(x, y))
        static Dictionary<int, Point> snakesPoint;
        //snakesDirection(dest num, direction LTR in this row)
        static Dictionary<int, int>  snakesDirection;
        //snakesDictionary(dest num, endrow)
        static Dictionary<int, int> snakesEndRow;
        public Form1()
        {
            InitializeComponent();
            DiceBbox.Load(@"E:\VSCode_projects\SnakesLadders\Dice\1.png");
            //DiceBbox.SizeMode = PictureBoxSizeMode.StretchImage;
            playerTurnFlag = 0;
            PlayerTurnlbl.Text = "Are You Ready ?";
            OrangeX = BlueX = -1 - distanceX;
            OrangeY = BlueY = 402;
            //bluePoint.Location = new Point(BlueX, BlueY);
            //orangePoint.Location = new Point(OrangeX, OrangeY);
            //bluePoint.Visible = false;
            //orangePoint.Visible = false;
            orangeFlag = blueFlag = false;
            orangecurcellNum = 0;
            bluecurcellNum   = 0;
            LTRB = 1;
            BTUB = 1;
            LTRO = 1;
            BTUO = 1;
            endRowB = 10;
            endRowO = 10;

            ladders = new Dictionary<int, int>();
            laddersPoint = new Dictionary<int, Point>();
            laddersDirection = new Dictionary<int, int>();
            laddersEndRow = new Dictionary<int, int>();

            snakes = new Dictionary<int, int>();
            snakesPoint = new Dictionary<int, Point>();
            snakesDirection = new Dictionary<int, int>();
            snakesEndRow = new Dictionary<int, int>();
            addToDictladder();
            addToDictsnake();
        }

        private void DiceBbox_Click(object sender, EventArgs e)
        {
            
            
        }

        private void MainGrid_Click(object sender, EventArgs e)
        {

        }

        private void rollPbox_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            dice = random.Next(1, 7);

            //DiceBbox.Load(@"E:\VSCode_projects\SnakesLadders\Dice\" + dice + ".png");
            DiceBbox.Load($"Dice/{dice}.png");// inside bin/debug folder

           
            if (playerTurnFlag == 1)
            {
                // player two (orange) has rooled
                move2(OrangeX, OrangeY, orangecurcellNum, endRowO, LTRO);
                PlayerTurnlbl.Text = "Player One Turn!";
            }
            else
            {
                // player one (blue) has rolled, so move him
                move2(BlueX, BlueY, bluecurcellNum,endRowB, LTRB);
                PlayerTurnlbl.Text = "Player Two Turn!";
            }
            playerTurnFlag ^= 1;

        }
        
        private void move2(int px, int py, int curcellNum, int endRow, int LTR)
        {
            int newcell = curcellNum + dice;
            if (newcell > 100)
                return;
            if(newcell <= endRow)
            {
                if (LTR == 1)
                    px += dice * distanceX;
                else
                    px -= dice * distanceX;
                            
            }
            else
            {
                // update x
                int stepx = dice - (newcell - endRow);
                if (LTR == 1)
                    px += stepx * distanceX;
                else
                    px -= stepx * distanceX;
                dice -= stepx;
                // update y
                py -= distanceY; 
                LTR ^= 1;
                dice--;
                // update reminder in x direction 
                if (LTR == 1)
                    px += dice * distanceX;
                else
                    px -= dice * distanceX;
                
                
                //update endrow
                endRow += 10;
            }


            curcellNum = newcell;
            if (playerTurnFlag == 0)
            {
                BlueX = px;
                BlueY = py;
                bluePoint.Location = new Point(px, py);
                bluecurcellNum = curcellNum;
                endRowB = endRow;
                LTRB = LTR;

                // check ladder
                if(ladders.ContainsKey(bluecurcellNum) == true)
                {
                    int dest = ladders[bluecurcellNum];
                    bluePoint.Location = laddersPoint[dest];
                    LTRB = laddersDirection[dest];
                    bluecurcellNum = dest;
                    BlueX = bluePoint.Location.X;
                    BlueY = bluePoint.Location.Y;
                    endRowB = laddersEndRow[dest];
                }

                // check snake
                if (snakes.ContainsKey(bluecurcellNum) == true)
                {
                    int dest = snakes[bluecurcellNum];
                    bluePoint.Location = snakesPoint[dest];
                    LTRB = snakesDirection[dest];
                    bluecurcellNum = dest;
                    BlueX = bluePoint.Location.X;
                    BlueY = bluePoint.Location.Y;
                    endRowB = snakesEndRow[dest];
                }
                
                // check Winner 
                if(checkWinner(bluecurcellNum) == true)
                {
                    MessageBox.Show("Congratulation Blue Player");
                    this.Close();
                }

            }
            else
            {
                OrangeX = px;
                OrangeY = py;
                orangePoint.Location = new Point(px, py);
                orangecurcellNum = curcellNum;
                endRowO = endRow;
                LTRO = LTR;

                // check ladder
                if (ladders.ContainsKey(orangecurcellNum) == true)
                {
                    int dest = ladders[orangecurcellNum];
                    orangePoint.Location = laddersPoint[dest];
                    LTRO = laddersDirection[dest];
                    orangecurcellNum = dest;
                    OrangeX = orangePoint.Location.X;
                    OrangeY = orangePoint.Location.Y;
                    endRowO = laddersEndRow[dest];
                }

                // check snake
                if (snakes.ContainsKey(orangecurcellNum) == true)
                {
                    int dest = snakes[orangecurcellNum];
                    orangePoint.Location = snakesPoint[dest];
                    LTRO = snakesDirection[dest];
                    orangecurcellNum = dest;
                    OrangeX = orangePoint.Location.X;
                    OrangeY = orangePoint.Location.Y;
                    endRowO = snakesEndRow[dest];
                }

                // check Winner 
                if (checkWinner(orangecurcellNum) == true)
                {
                    MessageBox.Show("Congratulation Orange Player");
                    this.Close();
                }

            }

        }
        
        private void BluePB_Click(object sender, EventArgs e)
        {
            
        }

        private void addToDictladder()
        {
            int startX = -1;
            int startY = 402;
            // insert ladders
            ladders.Add(1, 38);
            ladders.Add(4, 14);
            ladders.Add(8, 30);
            ladders.Add(28, 76);
            ladders.Add(21, 42);
            ladders.Add(50, 67);
            ladders.Add(71, 92);
            ladders.Add(80, 99);
            // insert up ladder location
            laddersPoint.Add(38, new Point(startX + (2 * distanceX), startY - (3 * distanceY)));
            laddersPoint.Add(14, new Point(startX + (6 * distanceX), startY - (1 * distanceY)));
            laddersPoint.Add(30, new Point(startX + (9 * distanceX), startY - (2 * distanceY)));
            laddersPoint.Add(42, new Point(startX + (1 * distanceX), startY - (4 * distanceY)));
            laddersPoint.Add(76, new Point(startX + (4 * distanceX), startY - (7 * distanceY)));
            laddersPoint.Add(67, new Point(startX + (6 * distanceX), startY - (6 * distanceY)));
            laddersPoint.Add(92, new Point(startX + (8 * distanceX), startY - (9 * distanceY)));
            laddersPoint.Add(99, new Point(startX + (1 * distanceX), startY - (9 * distanceY)));
            // inser ladder direction 
            laddersDirection.Add(38, 0);
            laddersDirection.Add(14, 0);
            laddersDirection.Add(30, 1);
            laddersDirection.Add(42, 1);
            laddersDirection.Add(76, 0);
            laddersDirection.Add(67, 1);
            laddersDirection.Add(92, 0);
            laddersDirection.Add(99, 0);
            // insert ladder endrow
            laddersEndRow.Add(38, 40);
            laddersEndRow.Add(14, 20);
            laddersEndRow.Add(30, 30);
            laddersEndRow.Add(42, 50);
            laddersEndRow.Add(76, 80);
            laddersEndRow.Add(67, 1);
            laddersEndRow.Add(92, 100);
            laddersEndRow.Add(99, 100);
        }

        private void addToDictsnake()
        {
            int startX = -1;
            int startY = 402;
            // insert snake
            snakes.Add(32, 10);
            snakes.Add(36, 6);
            snakes.Add(62, 18);
            snakes.Add(48, 26);
            snakes.Add(88, 24);
            snakes.Add(95, 56);
            snakes.Add(97, 78);
            // insert down snake location
            snakesPoint.Add(10, new Point(startX + (9 * distanceX), startY - (0 * distanceY)));
            snakesPoint.Add(6 , new Point(startX + (5 * distanceX), startY - (0 * distanceY)));
            snakesPoint.Add(18, new Point(startX + (2 * distanceX), startY - (1 * distanceY)));
            snakesPoint.Add(24, new Point(startX + (3 * distanceX), startY - (2 * distanceY)));
            snakesPoint.Add(26, new Point(startX + (5 * distanceX), startY - (2 * distanceY)));
            snakesPoint.Add(56, new Point(startX + (4 * distanceX), startY - (5 * distanceY)));
            snakesPoint.Add(78, new Point(startX + (2 * distanceX), startY - (7 * distanceY)));
            // insert snake direction
            snakesDirection.Add(10, 1);
            snakesDirection.Add(6, 1);
            snakesDirection.Add(18, 0);
            snakesDirection.Add(24, 1);
            snakesDirection.Add(26, 1);
            snakesDirection.Add(56, 0);
            snakesDirection.Add(78, 0);
            // insert snake endrow
            snakesEndRow.Add(10, 10);
            snakesEndRow.Add(6, 10);
            snakesEndRow.Add(18, 20);
            snakesEndRow.Add(24, 30);
            snakesEndRow.Add(26, 30);
            snakesEndRow.Add(56, 60);
            snakesEndRow.Add(78, 80);

        }
        private bool checkWinner(int num)
        {
            return num == 100;
        }
    }
}
