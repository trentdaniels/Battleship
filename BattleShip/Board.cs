using System;
using System.Collections.Generic;

namespace BattleShip
{
    public class Board
    {
        // Members
        private string size;
        private int boardDimension;
        private int[][] grid;

        public string Size { get => size; set => size = value; }
        public int BoardDimension { get => boardDimension; set => boardDimension = value; }
        public int[][] Grid { get => grid; set => grid = value; }

        // Constructor
        public Board()
        {

        }

        // Methods
        public int[][] CreateBoard()
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

