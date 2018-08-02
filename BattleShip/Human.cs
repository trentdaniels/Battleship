﻿using System;
namespace BattleShip
{
    public class Human : Player
    {
        // Members

        // Constructors
        public Human()
        {
        }

        // Methods
        public override void FireAtTarget(Player targetedPlayer)
        {
            int selectedRow;
            int selectedColumn;
            int[][] targetedBoard;

            targetedBoard = targetedPlayer.Board.Grid;

            Console.WriteLine($"{Name}, which row would you like to target?");
            selectedRow = int.Parse(Console.ReadLine());
            if (selectedRow > Board.BoardDimension) 
            {
                Console.WriteLine($"This is not a valid row. Please choose between 1 and {Board.BoardDimension}");
            }

            Console.WriteLine($"Select Column");
            selectedColumn = int.Parse(Console.ReadLine());
            if (selectedColumn > Board.BoardDimension)
            {
                Console.WriteLine($"This is not a valid column. Please choose between 1 and {Board.BoardDimension}");
            }
            targetedBoard[selectedRow - 1][selectedColumn - 1] += 2;
            Console.WriteLine($"{Name} fired at row {selectedRow} column {selectedColumn}");

            
        }

       



    }    
}
