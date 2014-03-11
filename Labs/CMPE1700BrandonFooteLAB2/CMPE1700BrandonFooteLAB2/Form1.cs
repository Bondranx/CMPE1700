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
        public enum EState { Invisible=1, Visible, Guess };
        public static SCell[,] CellArray = new SCell[10, 10];
        public static bool Visible = false;

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
            

            if (Visible == false)
            {
                for (int count = 0; count < 10; count++)
                {
                    for (int count2 = 0; count2 < 10; count2++)
                    {
                        if (CellArray[count, count2]._Estate == EState.Invisible)
                        {
                            GameField.AddRectangle(count, count2, 1, 1, Color.Black, 1, Color.White);
                        }
                        if (CellArray[count, count2]._Estate == EState.Visible)
                        {
                            GameField.AddText(CellArray[count,count2]._State,10,count,count2,1,1,Color.White);
                        }
                        if (CellArray[count, count2]._Estate == EState.Guess)
                        {
                            GameField.AddText(CellArray[count, count2]._State, 10, count, count2, 1, 1, Color.Green);
                        }
                    }
                }
                GameField.Render();
            }
            if (Visible == true)
            {
                for (int count = 0; count < 10; count++)
                {
                    for (int count2 = 0; count2 < 10; count2++)
                    {
                        GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);

                        if (CellArray[count, count2]._State == "Mine")
                        {
                            GameField.AddText("M", 25, count, count2, 1, 1, Color.Black);
                        }
                        if (CellArray[count, count2]._State == "1"||
                            CellArray[count,count2]._State=="2"||
                            CellArray[count,count2]._State=="3"||
                            CellArray[count,count2]._State=="4"||
                            CellArray[count, count2]._State == "5")
                        {
                            GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Green);
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
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            GameField.Scale = 50;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
            tmrGameTimer.Start();
        }

        private void chbxDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxDebug.Checked == true)
                Visible = true;
            else
                Visible = false;
        }

        private void tmrGameTimer_Tick(object sender, EventArgs e)
        {
            DisplayGame();
        }

        private void lblMines_Click(object sender, EventArgs e)
        {

        }


    }
}
