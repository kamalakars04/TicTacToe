using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To TicTacToe");
            TicTacToe ticTacToe = new TicTacToe();
            ticTacToe.CreateBoard();
        }
    }
}
