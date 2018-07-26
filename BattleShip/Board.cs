using System;
using System.Collections.Generic;

namespace BattleShip
{
    public class Board
    {
        // Members
        string size;
        public int boardDimension;
        List<int> targets;

        // Constructor
        public Board()
        {
            targets = new List<int> { };
            Console.WriteLine(CreateBoard());

        }

        // Methods
        public int[][] CreateBoard()
        {

            int[][] board;


            Console.WriteLine("How many rows does the board have? Please choose a number (20 and above).");
            boardDimension = int.Parse(Console.ReadLine());
            if (boardDimension < 20)
            {
                Console.WriteLine("Your desired board size is too small. Please try again.");
                CreateBoard();

            }

            Console.WriteLine($"Each Player will have a board with and width and height of {boardDimension} units.");
            board = new int[boardDimension][];

            size = $"{boardDimension} x {boardDimension}";
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = new int[boardDimension];
            }
            Console.WriteLine(size);
            Console.ReadLine();

            foreach (int[] row in board)
            {
                Array.Clear(row, 0, row.Length);
            }
            return board;

        }



    }


}

