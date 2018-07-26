using System;
using System.Collections.Generic;

namespace BattleShip
{
    public class Board
    {
        // Members
        public string size;
        public int boardDimension;
        List<int> targets;
        public int[][] grid;

        // Constructor
        public Board()
        {
            targets = new List<int> { };

        }

        // Methods
        public int[][] CreateBoard(int boardDimension)
        {

            int[][] board;

            board = new int[boardDimension][];


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
            size = $"{boardDimension} x {boardDimension} units";
            return board;
        }



    }


}    

