using System;

namespace TicTacToe
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int numOfTurn = 1;
            Console.WriteLine("Welcome To TicTacToe");
            TicTacToe ticTacToe = new TicTacToe();
            //To create a board
            ticTacToe.CreateBoard();
            // If user doesnt select correct input
            if (!ticTacToe.LetterSelection())
                return;
            ticTacToe.ShowBoard();
            int playerNum = ticTacToe.Toss();
            if (!ticTacToe.SelectIndex(playerNum)) return;
        }
    }
}
