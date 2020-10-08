using System;

namespace TicTacToe
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To TicTacToe");
            while(true)
            {
                TicTacToe ticTacToe = new TicTacToe();
                //To create a board
                ticTacToe.CreateBoard();
                //show the board
                ticTacToe.ShowBoard();
                string firstTurn = ticTacToe.Toss();
                // If user doesnt select correct input and want to exit
                if (!ticTacToe.LetterSelection(firstTurn))
                    return;
                //If user want to exit in between the game
                if (!ticTacToe.MakeMove(firstTurn)) 
                    return;
                Console.WriteLine("Enter E to exit or any other key to Play Again");
                //If user doesnt want to play again
                if (Console.ReadLine().ToUpper() == "E")
                    return;
            }
        }
    }
}
