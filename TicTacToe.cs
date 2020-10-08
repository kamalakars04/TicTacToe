using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TicTacToe
    {
        //To create a new board
        public void CreateBoard()
        {
            //To create 9 blocks for TicTacToe
            char[] board = new char[10];
            //Giving initially null value to all blocks
            for(int block = 0; block < board.Length; block++)
                board[block] = ' ';
        }
    }
}
