using System;
namespace BattleShip
{
    public class Board
    {
        // Members
        string size;

        // Constructor
        public Board()
        {
            CreateBoard();
        }

        // Methods
        public void CreateBoard() 
        {
            int boardDimension;
            int[][] board;


            Console.WriteLine("How many rows does the board have? Please choose a number (20 and above");
            boardDimension = int.Parse(Console.ReadLine());

            if (boardDimension >= 20) 
            {
                Console.WriteLine($"Each Player will have a board with and width and height of {boardDimension} units.");
                board = new int[boardDimension][];
                size = $"{boardDimension} X {boardDimension}";
                for (int i = 0; i < board.Length; i++) 
                {
                    board[i] = new int[boardDimension];
                }
                Console.WriteLine(size);
                Console.ReadLine();
            }
            else 
            {
                Console.WriteLine("Your desired board size is too small. Please try again.");
                CreateBoard();
            }
        }
    }
}
