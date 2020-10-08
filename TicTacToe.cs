using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class TicTacToe
    {
        //CONSTANTS
        const int USER_FIRST = 0;
        const int MAX_CHECK_RULE = 3;
        const int CHECK_SYSTEM_WIN_MOVE = 1;
        const int CHECK_USER_WIN_MOVE = 2;
        Random random = new Random();
        //variables
        int noOfTurn = 1;
        int checkRule = 1;
        char playerChar = ' ';
        char systemChar = ' ';
        char[] board;
        int[] corner = new int[4]{ 1, 3, 7, 9 };
        private int playerNum;
        
        //To create a new board
        public void CreateBoard()
        {
            //To create 9 blocks for TicTacToe
            board = new char[10];
            //Giving initially null value to all blocks
            for(int block = 0; block < board.Length; block++)
                board[block] = ' ';
        }

        // To select char by player or system
        public bool LetterSelection(string firstTurn)
        {
            //If first turn is for player then he selects character
            if (firstTurn == "user")
            {
                Console.WriteLine("\nSelect one of Letter X or O to continue game or E to exit\n");
                playerChar= Convert.ToChar(Console.ReadLine().ToUpper());
            }
            // If the first turn is of system then system selects char
            else
            {
                systemChar = (random.Next(0,2) == 0)? 'X':'O';
            }
            //if player selects X
            if (playerChar == 'X' || systemChar == 'O')
            {
                playerChar = 'X';
                systemChar = 'O';
                Console.WriteLine("The character for User is {0}\nThe character for system is {1}",playerChar,systemChar);
                return true;
            }
            //if player selects O
            else if (playerChar == 'O' || systemChar == 'X')
            {
                playerChar = 'O';
                systemChar = 'X';
                Console.WriteLine("The character for User is {0}\nThe character for system is {1}", playerChar, systemChar);
                return true;
            }
            else if (playerChar == 'E')
                return false;
            else
                return LetterSelection(firstTurn);
        }
        /// <summary>
        /// Method to show board
        /// </summary>
        public void ShowBoard()
        {
            Console.WriteLine("");
            for (int block = 1; block < 10;)
            {
                for (int row = 1; row < 4; row++)
                {
                    Console.Write("|\t" +board[block]+ "\t ");
                    block++;
                }
                Console.Write("\n");
                Console.WriteLine("------------------------------------------------");
            }
        }
        /// <summary>
        /// Method to check availability of index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool checkAvailability(int index)
        {
            //return true if block is empty
            if (board[index] == ' ')
                return true;
            //return false if block is occupied
            return false;
        }
        /// <summary>
        /// To start and make a move till game completes
        /// </summary>
        /// <param name="firstTurn"></param>
        /// <returns></returns>
        public bool MakeMove(string firstTurn)
        {
            if(noOfTurn == 1)
            {
                //if User has first turn then assigning his playerNum
                if (firstTurn == "user")
                    playerNum = 1;
                //If system has first turn then assigning its playerNum
                else
                    playerNum = 0;
            }
            //Select the index to be filled
            int index = SelectIndex(playerNum);
            //if user chooses to exit
            if (index == 0)
            {
                Console.WriteLine("\nThe User Has Chosen To Exit");
                return false;
            }
            //Fill the board 
            FillBoard(index);
            //Check for winner, if found then exit game
            if(CheckWinner())
            {
                Console.WriteLine("\nGAME OVER!\n{0} has won the game", (playerNum == 1)? "System":"User");
                return true;
            }
            if (noOfTurn != 1 && noOfTurn < 10)
            {
                Console.WriteLine("\nThe game continues to next turn");
                return MakeMove(firstTurn);
            }
            //After maximum turns game is draw
            Console.WriteLine("\nGAME OVER!\nThe game has been a draw");
            return true;
        }
        /// <summary>
        /// To select index to fill the char
        /// </summary>
        /// <param name="playerNum"></param>
        /// <returns></returns>
        public int SelectIndex(int playerNum)
        {
            int index = 0;
            //If it is user turn then asking him to select index
            if (playerNum == 1)
            {
                Console.WriteLine("\nUser Turn\nSelect the Block number from 1 to 9 or 0 to exit");
                index = Convert.ToInt32(Console.ReadLine());
            }
            //if it is system turn then getting index with random function
            else if(playerNum == 0)
            {
                Console.WriteLine("System Turn");
                index = getSystemMove(checkRule);
                if(index == 0)
                 index = random.Next(1, 10);
            }
            //If user chooses to exit
            if (index == 0)
                return 0;
            //Check for validity if index
            else if (index < 1 || index > 9)
                return SelectIndex(playerNum);
            //If there is no availability of index and if index is valid
            else if (!checkAvailability(index))
            {
                Console.WriteLine("\nThe Chosen Block is already filled.Choose Again");
                return SelectIndex(playerNum);
            }
            //If the index is available then return index
            else
                return index;
        }
        /// <summary>
        /// To fill the block chosen, if found available
        /// </summary>
        /// <param name="index"></param>
        public void FillBoard(int index)
        {
            // If the turn is of player one i.e user
            if (playerNum == 1)
            {
                board[index] = playerChar;
                noOfTurn++;
                playerNum = 0;
                Console.WriteLine("\n\n");
                ShowBoard();
            }
            //If the turn is of computer
            else if (playerNum == 0)
            {
                board[index] = systemChar;
                noOfTurn++;
                playerNum = 1;
                Console.WriteLine("\n\n");
                ShowBoard();
            }
        }
        public string Toss()
        {
            //Using random function to toss
            Random random = new Random();
            int turn = random.Next(0, 2);
            if (turn == USER_FIRST)
            {
                Console.WriteLine("\nUser turn first");
                return "user";
            }
            Console.WriteLine("\nComputer turn first");
            return "system";
        }
        /// <summary>
        /// Checking for winner
        /// </summary>
        /// <returns></returns>
        public bool CheckWinner()
        {
            //If the char in rows are equal
            for (int row = 1; row < 8;)
            {
                if (board[row] == board[row + 1] && board[row + 1] == board[row + 2] && board[row + 2] != ' ')
                    return true;
                row += 3;
            }
            //If the char in columns are equal
            for (int column = 1; column < 4; column++)
            {
                if (board[column] == board[column + 3] && board[column + 3] == board[column + 6] && board[column + 3] != ' ')
                        return true;
            }
            //If the char in diagnol are equal
            if (board[1] == board[5] && board[5] == board[9] && board[9] != ' ')
                return true;
            if (board[3] == board[5] && board[5] == board[7] && board[3] != ' ')
                return true;
            //If no row,no column , no diagnol matches
            return false;
        }
        /// <summary>
        /// Get winning condition if any
        /// </summary>
        /// <returns></returns>
        public int getSystemMove(int systemCheck)
        {
            //check the winning conditions for each block
            for (int block = 1; block < 10; block++)
            {
                if(board[block] == ' ')
                {
                    board[block] = (systemCheck == 1) ? systemChar : playerChar;
                    if (CheckWinner())
                    {
                        board[block] = ' ';
                        return block;
                    }
                    board[block] = ' ';
                }
            }
            systemCheck++;
            //To check the winning condition of opponent
            if (systemCheck <= 2)
                return getSystemMove(systemCheck);
            //To check the corners for empty blocks
            corner = Array.FindAll(corner, checkAvailability).ToArray();
            if (corner.Length != 0)
            {
                int index = random.Next(corner.Length);
                return corner[index];
            }
            //If no corner block is free and if central block is free
            else if (checkAvailability(5))
                return 5;
            //If no specified rules are met
            return 0;
        }
    }
}
