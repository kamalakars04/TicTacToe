using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TicTacToe
    {
        Random random = new Random();
        int noOfTurn = 0;
        char playerChar = ' ';
        char systemChar = ' ';
        char[] board;
        //To create a new board
        public void CreateBoard()
        {
            //To create 9 blocks for TicTacToe
            board = new char[10];
            //Giving initially null value to all blocks
            for(int block = 0; block < board.Length; block++)
                board[block] = ' ';
        }
        // To select Letter by player
        public bool LetterSelection()
        {
            Console.WriteLine("Select one of Letter X or O to continue game");
            char playerSelection = Convert.ToChar(Console.ReadLine().ToUpper());
            //if player selects X
            if (playerSelection == 'X')
            {
                playerChar = 'X';
                systemChar = 'O';
                return true;
            }
            //if player selects O
            else if (playerSelection == 'O')
            {
                playerChar = 'O';
                systemChar = 'X';
                return true;
            }
            else if (playerChar == 'E')
                return false;
            else
                return LetterSelection();
        }
        public void ShowBoard()
        {
            for (int block = 1; block < 10;)
            {
                for (int row = 1; row < 4; row++)
                {
                    Console.Write("|\t" +board[block] + "\t ");
                    block++;
                }
                Console.Write("\n");
                Console.WriteLine("------------------------------------------------");
            }
        }

        public bool checkAvailability(int index)
        {
            if (board[index] == ' ')
                return true;
            return false;
        }

        public bool SelectIndex(int playerNum)
        {
            int index = 0;
            noOfTurn++;
            if (playerNum == 1 && noOfTurn < 10)
            {
                Console.WriteLine("Select the Index number from 1 to 9 or 0 to exit");
                index = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                index = random.Next(1, 10);
            }
            if (index < 10 && index > 0 && noOfTurn < 10)
            {
                if (checkAvailability(index) && playerNum == 1)
                {
                    board[index] = 'X';
                    noOfTurn++;
                    playerNum = 0;
                    Console.WriteLine("\n\n\n");
                    ShowBoard();
                }
                else if (checkAvailability(index) && playerNum == 0)
                {
                    board[index] = 'O';
                    noOfTurn++;
                    playerNum = 1;
                    Console.WriteLine("\n\n\n");
                    ShowBoard();
                }
            }
            if (!SelectIndex(playerNum)) return false;
            else if (index == 0)
                return false;

            return true;
            

        }

        public int Toss()
        {
            Random random = new Random();
            int turn = random.Next(0, 2);
            if (turn == 0)
            {
                Console.WriteLine("User turn first");
                return 1;
            }
            return 0;
        }
    }
}
