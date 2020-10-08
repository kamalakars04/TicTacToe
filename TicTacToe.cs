using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TicTacToe
    {
        public void CreateBoard()
        {
            char[] board = new char[10];
            for(int block=0; block<10; block++)
                board[block] = Convert.ToChar(0);
        }
    }
}
