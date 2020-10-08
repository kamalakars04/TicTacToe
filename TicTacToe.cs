using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TicTacToe
    {
        char playerChar = ' ';
        char systemChar = ' ';
        //To create a new board
        public char[] CreateBoard()
        {
            //To create 9 blocks for TicTacToe
            char[] board = new char[10];
            //Giving initially null value to all blocks
            for(int block = 0; block < board.Length; block++)
                board[block] = ' ';
            return board;
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
                LetterSelection();
            return false;
        }
        public void ShowBoard(char[] board)
        {
            for (int i = 1; i < 10;)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("|\t" + board[i] + "\t ");
                    i++;
                }
                Console.Write("\n");
                Console.WriteLine("------------------------------------------------");
            }
        }
    }
}
