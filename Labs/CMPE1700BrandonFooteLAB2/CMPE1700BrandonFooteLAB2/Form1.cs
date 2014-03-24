//***********************************************************************************
//Program: Minesweeper
//Description: Allows user to play  game of Minesweeper
//Date: Mar. 24, 2014
//Author: JD Silver
//Course: CNT1700
//Class: CNT2C/D
//***********************************************************************************

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
        //Definition of the GDIDrawer window
        public static CDrawer GameField = new CDrawer(500, 500, false, true);
        //Cell state enumeration
        public enum EState { Invisible=1, Visible, Guess, Mine };
        //Game cell array
        public static SCell[,] CellArray = new SCell[10, 10];
        //Tracks debug visibility
        public static bool Invisible = false;
        //Tracks number of mines visible on the game form
        public static int VisibleNumberOfMines = 10;
        //tracks total number of mines revealed
        public static int TotalInvisible = 100;

        //Structure definition for game array cells
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

        //********************************************************************************************
        //Method: public static void NewGame()
        //Purpose: Creates a new game when the New Game button is clicked
        //Parameters: N/A
        //Returns: nothing
        //*********************************************************************************************
        public static void NewGame()
        {
            //Clears the gamefield
            GameField.Clear();
            
            int count = 0;      //Sets a counting variable to track mine creation
            Random random = new Random();       //Creates a random number object
            int x = 0;          //Initializes a varaible to track the X value
            int y = 0;          //Initializes a variable to track the Y value

            //Loop to create the array of game cells
            for (int count1 = 0; count1 < 10; count1++)
            {
                for (int count2 = 0; count2 < 10; count2++)
                {
                    //Creates a new Game Cell for each location in the array
                    CellArray[count1, count2] = new SCell(EState.Invisible, "");
                }
            }

            //Loops while fewer than 10 mines have been created
            do
            {
                //Loops while the cell contains a mine
                do
                {
                    x = random.Next(0,10);      //Generates a random number for the X location
                    y = random.Next(0,10);      //Generates a random number for the Y location
                }
                while(CellArray[x,y]._State == "Mine");
                //Sets cell to a mine if it does not contain one
                CellArray[x,y]._State = "Mine";
                //adds one to mine total
                count++;
            }
            while (count < 10);

            //Loop to check all cells in array for mines, and place numbers in 
            //surrounding cells for number of mines touching them
            for (int Row = 0; Row < 10; Row++)
            {
                for(int Column = 0; Column < 10; Column++)
                {
                    //tracks number of mines surrounding each cell
                    int MineCount = 0;
                    if (CellArray[Row, Column]._State == "Mine")
                    {
                    }
                    //error checking for top left corner
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
                    //error checking for bottom left corner
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
                        //error checking for top right corner
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
                    //Error checking for bottom right corner
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
                    //error checking for right wall
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
                    //Error checking for top wall
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
                    //Error checking for bottom wall
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
                    //Error checking for right wall
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
                    //Runs if cell is not on a wall or corner
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

        //********************************************************************************************
        //Method: public static void DisplayGame()
        //Purpose: Displays the game to a GDIDrwaer window
        //Parameters: N/A
        //Returns: nothing
        //*********************************************************************************************
        public static void DisplayGame()
        {
            //Enters if visibility is set to false
            if (Invisible == false)
            {
                //Loops through entire cell array
                for (int count = 0; count < 10; count++)
                {
                    for (int count2 = 0; count2 < 10; count2++)
                    {
                        //Enters if cell EState is set to invisible
                        if (CellArray[count, count2]._Estate == EState.Invisible)
                        {
                            //Draws a black square with a white border to the Drawing window
                            GameField.AddRectangle(count, count2, 1, 1, Color.Black, 1, Color.White);
                        }
                        //Enters if cell EState is set to mine
                        if (CellArray[count, count2]._Estate == EState.Mine)
                        {
                            //Draws a Black square with a white border and a red M to the Drawing window
                            GameField.AddRectangle(count, count2, 1, 1, Color.Black, 1, Color.White);
                            GameField.AddText("M", 25, count, count2, 1, 1, Color.Red);
                        }
                        //Enters is cell EState is set to visible
                        //Checks what number is in the cell state
                        //Draws number with appropriate text color to the window on a white square with black border
                        if (CellArray[count, count2]._Estate == EState.Visible)
                        {
                            if (CellArray[count, count2]._State != "0")
                            {
                                //Draws a blue 1
                                if (CellArray[count, count2]._State == "1")
                                {
                                    GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                    GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Blue);
                                }
                                //Draws a Green 2
                                else if (CellArray[count, count2]._State == "2")
                                {
                                    GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                    GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Green);
                                }
                                //Draws a Gold 3
                                else if (CellArray[count, count2]._State == "3")
                                {
                                    GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                    GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Gold);
                                }
                                //Draws an orange 4
                                else if (CellArray[count, count2]._State == "4")
                                {
                                    GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                    GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Orange);
                                }
                                //Draws a Pink 5
                                else if (CellArray[count, count2]._State == "5")
                                {
                                    GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                    GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Salmon);
                                }
                            }
                            else
                                //Draws a White square with a black border if sell is empty and visible
                                GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                        }
                        //Checks if cell EState is a guess and draws a blue '?'
                        if (CellArray[count, count2]._Estate == EState.Guess)
                        {
                            GameField.AddRectangle(count, count2, 1, 1, Color.Black, 1, Color.White);
                            GameField.AddText("?", 25, count, count2, 1, 1, Color.Blue);
                        }
                    }
                }
                //Renders the CDrawer
                GameField.Render();
            }
            //Enters if visibility is set to true (Debug Mode)
            if (Invisible == true)
            {
                //Loops through cell array
                for (int count = 0; count < 10; count++)
                {
                    for (int count2 = 0; count2 < 10; count2++)
                    {
                        //Draws cell as a white square with black border
                        GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);

                        //Cehcks if cell EState is 'mine'
                        if (CellArray[count, count2]._State == "Mine")
                        {
                            //Draws a Red 'M' to the cell
                            GameField.AddText("M", 25, count, count2, 1, 1, Color.Red);
                        }
                        //Checks if cell contains a number between 1 and 5
                        if (CellArray[count, count2]._State == "1"||
                            CellArray[count,count2]._State=="2"||
                            CellArray[count,count2]._State=="3"||
                            CellArray[count,count2]._State=="4"||
                            CellArray[count, count2]._State == "5")
                        {
                            //Checks if cell contains 1 and draws a blue 1
                            if (CellArray[count, count2]._State == "1")
                            {
                                GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Blue);
                            }
                            //Checks if cell contains 2 and draws a green 2
                            else if (CellArray[count, count2]._State == "2")
                            {
                                GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Green);
                            }
                            //Checks if cell contains 3 and draws a gold 3
                            else if (CellArray[count, count2]._State == "3")
                            {
                                GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Gold);
                            }
                            //Checks if cell contains 4 and draws an orange 4
                            else if (CellArray[count, count2]._State == "4")
                            {
                                GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Orange);
                            }
                            //Checks if cell contains 5 and draws a pink 5
                            else if (CellArray[count, count2]._State == "5")
                            {
                                GameField.AddRectangle(count, count2, 1, 1, Color.White, 1, Color.Black);
                                GameField.AddText(CellArray[count, count2]._State, 25, count, count2, 1, 1, Color.Salmon);
                            }
                        }
                    }
                }
                //Renders game field
                GameField.Render();
            }
        }

        //********************************************************************************************
        //Method: public static void ClearGame()
        //Purpose: Clears game field
        //Parameters: N/A
        //Returns: nothing
        //*********************************************************************************************
        public static void ClearGame()
        {
            //Loops through cell array and resets all values
            for (int count = 0; count < 10; count++)
            {
                for (int count2 = 0; count2 < 10; count2++)
                {
                    //Sets state to blank
                    CellArray[count, count2]._State = "";
                    //Sets EState to invisible
                    CellArray[count, count2]._Estate = EState.Invisible;
                }
            }
        }

        //********************************************************************************************
        //Method: public static void ClearEmpty(int x, int y)
        //Purpose: Recursively clears all cells if clicked cell is empty
        //Parameters: int x - the X-location of last mouse left click
        //int y - the Y-location of last mouose left click
        //Returns: nothing
        //*********************************************************************************************
        public static void ClearEmpty(int x, int y)
        {
            if (x >= 0 && x <= 9 && y >= 0 && y <= 9)
            {
                //returns from method if cell is invisible
                if (CellArray[x, y]._Estate != EState.Invisible)
                {
                    return;
                }
                //Returns from method if cell is a mine
                else if (CellArray[x, y]._State == "Mine")
                {
                    return;
                }
                //If cells is not blank sets cell EState fo visible and returns from method
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
                    //Recursively calls method
                    ClearEmpty(x - 1, y);
                    ClearEmpty(x + 1, y);
                    ClearEmpty(x, y - 1);
                    ClearEmpty(x, y + 1);
                    ClearEmpty(x - 1, y - 1);
                    ClearEmpty(x - 1, y + 1);
                    ClearEmpty(x + 1, y + 1);
                    ClearEmpty(x + 1, y - 1);
                    return;
            }
        }

        //********************************************************************************************
        //Method: public static string CheckWin(Point newPoint)
        //Purpose: Check if user has won or lost
        //Parameters: Point newPoint - Holds value of last mouse left click
        //Returns: string success - holds user win/loss value
        //*********************************************************************************************
        public static string CheckWin(Point newPoint)
        {
            int mineCount = 0;      //Variable to count number of mines found
            string success = "";    //Varaible to store Win/Loss value
            //Checks if user left clicked a mine
            if (CellArray[newPoint.X, newPoint.Y]._State == "Mine")
            {
                success = "Game Over";      //Sets success to Game Over
                return success;             //Returns from method
            }
            //Loops through cell array
            for (int rows = 0; rows < 10; rows++)
            {
                for (int columns = 0; columns < 10; columns++)
                {
                    //Checks if cell EState and state are both 'mine'
                    if (CellArray[rows, columns]._Estate == EState.Mine && CellArray[rows, columns]._State == "Mine")
                        mineCount++;    //Adds one to minecount
                    //Checks if all mines are clicked, or all non-mines are revealed
                    if (mineCount == 10 || TotalInvisible == (10 - mineCount))
                    {
                        success = "You Win";    //Sets success to "You Win"
                        return success;         //Returns from method
                    }
                }
            }
            return success;
        }

        public frmMain()
        {
            InitializeComponent();
        }

        //********************************************************************************************
        //Method: frmMain_Load(object sender, EventArs e)
        //Purpose: Runs on form load
        //Returns: nothing
        //*********************************************************************************************
        private void frmMain_Load(object sender, EventArgs e)
        {
            GameField.Scale = 50;
            lblNumMines.Visible = true;
        }

        //********************************************************************************************
        //Method: btnNewGame_Click(object sender, EventArgs e)
        //Purpose: Button click event for New Game button
        //Returns: nothing
        //*********************************************************************************************
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Point nPoint = new Point();     //Stores left button click
            Point rPoint = new Point();     //Stroes right button click
            ClearGame();    //Clears game
            NewGame();      //Creates a new game
            DisplayGame();  //Displays game
            GameField.GetLastMouseLeftClickScaled(out nPoint);  //Reads mouse left click
            GameField.GetLastMouseRightClickScaled(out rPoint); //Reads mouse right click
            btnNewGame.Enabled = false;     //Disables NewGame button
            tmrGameTimer.Start();   //Starts timer for game events
        }

        //********************************************************************************************
        //Method: chbxDebug_CheckedChanged(object sender, EventArgs e)
        //Purpose: change event for Debug checkbox
        //Returns: nothing
        //*********************************************************************************************
        private void chbxDebug_CheckedChanged(object sender, EventArgs e)
        {
            //Checks if debug box is selected
            if (chbxDebug.Checked == true)
            {
                Invisible = true;   //Sets visibility to true
                GameField.Clear();  //Clears gamefield
                DisplayGame();      //Redisplays gamefield
            }
            else
            {
                Invisible = false;  //Sets visibility to false
                GameField.Clear();  //Clears gamefield
                DisplayGame();      //Redispalys gamefield
            }
        }

        private void tmrGameTimer_Tick(object sender, EventArgs e)
        {
            Point newPoint = new Point();   //Point variable to store left clicks
            Point RightPoint = new Point(); //Point variable to stroe right clicks
            bool success = false;           //Stores left click success
            bool success2 = false;          //Stores right click success
            string WinLose = "";            //Holds Win/Loss string
            
            //Reads in a left click and stores the scaled location
            success = GameField.GetLastMouseLeftClickScaled(out newPoint);
            //Reads in a right click and stores the scaled location
            success2 = GameField.GetLastMouseRightClickScaled(out RightPoint);
            
            //checks if left click and NOT right click
            if (success && !success2) 
                ClearEmpty(newPoint.X, newPoint.Y); //Calls ClearEmpty recursive  method

            //Checks if right click and NOT left click
            if (success2 && !success)
            {
                //Checks if cell is visible
                if (CellArray[RightPoint.X, RightPoint.Y]._Estate == EState.Invisible)
                {
                    //sets invisible cell to mine
                    CellArray[RightPoint.X, RightPoint.Y]._Estate = EState.Mine;
                    //decreases number of mines visible on the game form by 1
                    VisibleNumberOfMines--;
                }
                //Checks if cell is a mine
                else if (CellArray[RightPoint.X, RightPoint.Y]._Estate == EState.Mine)
                {
                    //Sets mine cell to a guess
                    CellArray[RightPoint.X, RightPoint.Y]._Estate = EState.Guess;
                    //Increases number of mines visible on game form by 1
                    VisibleNumberOfMines++;
                }
                //Checks if cell is a guess
                else if(CellArray[RightPoint.X,RightPoint.Y]._Estate == EState.Guess)
                    //Changes guess to invisible
                    CellArray[RightPoint.X, RightPoint.Y]._Estate = EState.Invisible;
            }
            //Updates number of mines visible on the form
            lblNumMines.Text = VisibleNumberOfMines.ToString();

            if (success && !success2)
            {
                WinLose = CheckWin(newPoint);
                DisplayGame();
            }

            if (!success && success2)
            {
                WinLose = CheckWin(newPoint);
                DisplayGame();
            }

            //Checks if Win/Loss variable is "Game Over"
            //Displays entire game field if true
            //Diplays "Game Over" in red text over game field
            //resets all global variables
            if (WinLose == "Game Over")
            {
                Invisible = true;       
                DisplayGame();
                GameField.AddText("Boom", 50, Color.Red);
                tmrGameTimer.Stop();
                VisibleNumberOfMines = 10;
                Invisible = false;
                btnNewGame.Enabled = true;
            }

            //Checks if Win/Loss variable is "You Win"
            //Displays entire game field if true
            //Displays "You Win" in green text over game field
            //Resets all global variables
            else if (WinLose == "You Win")
            {
                Invisible = true;
                DisplayGame();
                GameField.AddText(WinLose, 50, Color.Green);
                VisibleNumberOfMines = 10;
                tmrGameTimer.Stop();
                Invisible = false;
                btnNewGame.Enabled = true;
            }
        }
    }
}
