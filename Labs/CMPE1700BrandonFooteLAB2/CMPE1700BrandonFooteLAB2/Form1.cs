using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GDIDrawer;

namespace CMPE1700BrandonFooteLAB2
{
    public partial class frmMain : Form
    {

        public static CDrawer GameField = new CDrawer(500, 500, false, true);
        public enum EState { Invisible=1, Visible, Guess, Mine };
        public static SCell[,] CellArray = new SCell[10, 10];
        public static bool Invisible = false;
        public static Point newPoint = new Point();
        public static Point RightPoint = new Point();
        public static int VisibleNumberOfMines = 10;
        public static int TotalInvisible = 100;

        public struct SCell
        {
            public EState _Estate;
            public string _State;

            public SCell(EState estate, string state)
            {
                _Estate = estate;
                _State = "";
            }
        }

        public static void NewGame()
        {
            GameField.Clear();
            
            int count = 0;
            Random random = new Random();
            int x = 0;
            int y = 0;

            for (int count1 = 0; count1 < 10; count1++)
            {
                for (int count2 = 0; count2 < 10; count2++)
                {
                    CellArray[count1, count2] = new SCell(EState.Invisible, "");
                }
            }

            do
            {
                do
                {
                    x = random.Next(0,10);
                    y = random.Next(0,10); 
                }
                while(CellArray[x,y]._State == "Mine");
                CellArray[x,y]._State = "Mine";
                count++;
            }
            while (count < 10);

            for (int Row = 0; Row < 10; Row++)
            {
                for(int Column = 0; Column < 10; Column++)
                {
                    int MineCount = 0;
                    if (CellArray[Row, Column]._State == "Mine")
                    {
                    }
                    else if (Row == 0 && Column == 0)
                    {
                        if(CellArray[Row+1,Column]._State == "Mine")
                            MineCount++;
                        if(CellArray[Row+1,Column+1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row, Column + 1]._State == "Mine")
                            MineCount++;
                        CellArray[Row, Column]._State = MineCount.ToString();
                    }
                    else if (Row == 0 && Column == 9)
                    {
                        if (CellArray[Row + 1, Column-1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row + 1, Column]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row, Column - 1]._State == "Mine")
                            MineCount++;
                        CellArray[Row, Column]._State = MineCount.ToString();
                    }
                    else if (Row == 9 && Column == 0)
                    {
                        if (CellArray[Row - 1, Column]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row - 1, Column + 1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row, Column + 1]._State == "Mine")
                            MineCount++;
                        CellArray[Row, Column]._State = MineCount.ToString();
                    }
                    else if (Row == 9 && Column == 9)
                    {
                        if (CellArray[Row - 1, Column]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row - 1, Column - 1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row, Column - 1]._State == "Mine")
                            MineCount++;
                        CellArray[Row, Column]._State = MineCount.ToString();
                    }
                    else if (Row == 0)
                    {
                        if (CellArray[Row + 1, Column-1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row, Column - 1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row, Column + 1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row + 1, Column + 1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row + 1, Column]._State == "Mine")
                            MineCount++;
                        CellArray[Row, Column]._State = MineCount.ToString();
                    }
                    else if (Column == 0)
                    {
                        if (CellArray[Row, Column + 1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row - 1, Column + 1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row + 1, Column + 1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row + 1, Column]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row - 1, Column]._State == "Mine")
                            MineCount++;
                        CellArray[Row, Column]._State = MineCount.ToString();
                    }
                    else if (Column == 9)
                    {
                        if (CellArray[Row + 1, Column]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row + 1, Column - 1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row, Column - 1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row - 1, Column]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row - 1, Column - 1]._State == "Mine")
                            MineCount++;
                        CellArray[Row, Column]._State = MineCount.ToString();
                    }
                    else if (Row == 9)
                    {
                        if (CellArray[Row, Column - 1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row, Column + 1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row - 1, Column + 1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row - 1, Column]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row - 1, Column - 1]._State == "Mine")
                            MineCount++;
                        CellArray[Row, Column]._State = MineCount.ToString();
                    }
                    else
                    {
                        if (CellArray[Row - 1, Column - 1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row - 1, Column]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row - 1, Column + 1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row, Column - 1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row, Column + 1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row + 1, Column - 1]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row + 1, Column]._State == "Mine")
                            MineCount++;
                        if (CellArray[Row + 1, Column + 1]._State == "Mine")
                            MineCount++;
                        CellArray[Row, Column]._State = MineCount.ToString();
                    }
                }
            }
        }

        public static void DisplayGame()
        {
            if (Invisible == false)
            {
                for (int count = 0; count < 10; count++)
                {
                    for (int count2 = 0; count2 < 10; count2++)
                    {
                        if (CellArray[count, count2]._Estate == EState.Invisible)
                        {
                            GameField.AddRectangle(count, count2, 1, 1, Color.Black, 1, Color.White);
                        }
                        if (CellArray[count, count2]._Estate == EState.Mine)
                        {
                            GameField.AddRectangle(count, count2, 1, 1, Color.Black, 1, Color.White);
                            GameField.AddText("M", 25, count, count2, 1, 1, Color.Red);
                        }
                        if (CellArray[count, count2]._Estate == EState.Visible)
                        {
                            if (CellArray[count, count2]._State != "0")
                            {
                                if (CellArray[count, count2]._State == "1")
                                {
                                    GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                    GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Blue);
                                }
                                else if (CellArray[count, count2]._State == "2")
                                {
                                    GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                    GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Green);
                                }
                                else if (CellArray[count, count2]._State == "3")
                                {
                                    GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                    GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Gold);
                                }
                                else if (CellArray[count, count2]._State == "4")
                                {
                                    GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                    GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Orange);
                                }
                                else if (CellArray[count, count2]._State == "5")
                                {
                                    GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                    GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Salmon);
                                }
                            }
                            else
                                GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                        }
                        if (CellArray[count, count2]._Estate == EState.Guess)
                        {
                            GameField.AddRectangle(count, count2, 1, 1, Color.Black, 1, Color.White);
                            GameField.AddText("?", 25, count, count2, 1, 1, Color.Blue);
                        }
                    }
                }
                GameField.Render();
            }
            if (Invisible == true)
            {
                for (int count = 0; count < 10; count++)
                {
                    for (int count2 = 0; count2 < 10; count2++)
                    {
                        GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);

                        if (CellArray[count, count2]._State == "Mine")
                        {
                            GameField.AddText("M", 25, count, count2, 1, 1, Color.Red);
                        }
                        if (CellArray[count, count2]._State == "1"||
                            CellArray[count,count2]._State=="2"||
                            CellArray[count,count2]._State=="3"||
                            CellArray[count,count2]._State=="4"||
                            CellArray[count, count2]._State == "5")
                        {
                                                            if (CellArray[count, count2]._State == "1")
                                {
                                    GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                    GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Blue);
                                }
                                else if (CellArray[count, count2]._State == "2")
                                {
                                    GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                    GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Green);
                                }
                                else if (CellArray[count, count2]._State == "3")
                                {
                                    GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                    GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Gold);
                                }
                                else if (CellArray[count, count2]._State == "4")
                                {
                                    GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                    GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Orange);
                                }
                                else if (CellArray[count, count2]._State == "5")
                                {
                                    GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                    GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Salmon);
                                }
                        }
                    }
                }
                GameField.Render();
            }
        }
        public static void ClearGame()
        {
            for (int count = 0; count < 10; count++)
            {
                for (int count2 = 0; count2 < 10; count2++)
                {
                    CellArray[count, count2]._State = "";
                    CellArray[count, count2]._Estate = EState.Invisible;
                }
            }
        }
        public static void ClearEmpty(int x, int y)
        {
            if (x >= 0 && x <= 9 && y >= 0 && y <= 9)
            {
                if (CellArray[x, y]._Estate != EState.Invisible)
                {
                    return;
                }
                else if (CellArray[x, y]._State == "Mine")
                {
                    return;
                }

                else if (CellArray[x, y]._State != "")
                {
                    CellArray[x, y]._Estate = EState.Visible;
                    TotalInvisible--;
                    if (CellArray[x, y]._State == "1")
                        return;
                    if (CellArray[x, y]._State == "2")
                        return;
                    if (CellArray[x, y]._State == "3")
                        return;
                    if (CellArray[x, y]._State == "4")
                        return;
                    if (CellArray[x, y]._State == "5")
                        return;
                }
                    ClearEmpty(x - 1, y);
                    ClearEmpty(x + 1, y);
                    ClearEmpty(x, y - 1);
                    ClearEmpty(x, y + 1);
                    return;
            }
        }

        public static string CheckWin()
        {
            int mineCount = 0;
            string success = "";
            if (CellArray[newPoint.X, newPoint.Y]._State == "Mine")
            {
                success = "Game Over";
                return success;
            }
            if (CellArray[newPoint.X, newPoint.Y]._State != "Mine")
            for (int rows = 0; rows < 10; rows++)
            {
                for (int columns = 0; columns < 10; columns++)
                {
                    if (CellArray[rows, columns]._Estate == EState.Mine && CellArray[rows, columns]._State == "Mine")
                        mineCount++;
                    if (mineCount == 10 || TotalInvisible == (10-mineCount))
                    {
                        success = "You Win";
                        return success;
                    }
                }
            }
            return success;
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            GameField.Scale = 50;
            lblNumMines.Visible = true;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            ClearGame();
            NewGame();
            DisplayGame();
            btnNewGame.Enabled = false;
            tmrGameTimer.Start();
        }

        private void chbxDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxDebug.Checked == true)
            {
                Invisible = true;
                GameField.Clear();
                DisplayGame();
            }
            else
            {
                Invisible = false;
                GameField.Clear();
                DisplayGame();
            }
        }

        private void tmrGameTimer_Tick(object sender, EventArgs e)
        {
            bool success = false;
            bool success2 = false;
            string WinLose = "";
            
            success = GameField.GetLastMouseLeftClickScaled(out newPoint);
            success2 = GameField.GetLastMouseRightClickScaled(out RightPoint);
            ClearEmpty(newPoint.X, newPoint.Y);
            if (success2 == true)
            {
                if (CellArray[RightPoint.X, RightPoint.Y]._Estate == EState.Invisible)
                {
                    CellArray[RightPoint.X, RightPoint.Y]._Estate = EState.Mine;
                    VisibleNumberOfMines--;
                }
                else if (CellArray[RightPoint.X, RightPoint.Y]._Estate == EState.Mine)
                {
                    CellArray[RightPoint.X, RightPoint.Y]._Estate = EState.Guess;
                    VisibleNumberOfMines++;
                }
                else
                    CellArray[RightPoint.X, RightPoint.Y]._Estate = EState.Invisible;
            }
            lblNumMines.Text = VisibleNumberOfMines.ToString();
            if (success == true || success2 == true)
            {
                WinLose = CheckWin();
                DisplayGame();
            }
            if (WinLose == "Game Over")
            {
                Invisible = true;
                DisplayGame();
                GameField.AddText(WinLose, 50, Color.Red);
                tmrGameTimer.Stop();
                VisibleNumberOfMines = 10;
                btnNewGame.Enabled = true;
            }
            else if (WinLose == "You Win")
            {
                Invisible = true;
                DisplayGame();
                GameField.AddText(WinLose, 50, Color.Green);
                VisibleNumberOfMines = 10;
                tmrGameTimer.Stop();
                btnNewGame.Enabled = true;
            }
        }




    }
}
