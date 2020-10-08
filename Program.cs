using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To TicTacToe");
            TicTacToe ticTacToe = new TicTacToe();
            //To create a board
            ticTacToe.CreateBoard();
            // If user doesnt select correct input
            if (!ticTacToe.LetterSelection())
                return;
            ticTacToe.ShowBoard();
            ticTacToe.SelectIndex();
        }
    }
}
