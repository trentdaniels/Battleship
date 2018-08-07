using System;
using System.Collections.Generic;

namespace BattleShip
{
    public class Computer : Player
    {
        // Members
        private Random random;


        // Constructors
        public Computer()
        {
            random = new Random();
        }

        // Methods
        public override void FireAtTarget(Player targetedPlayer, int boardDimension)
        {
            string result;
            int randomRowOnBoard;
            int randomColumnOnBoard;
            int[][] targetedBoard;

            targetedBoard = targetedPlayer.Board.Grid;
            randomRowOnBoard = random.Next(0, boardDimension);
            randomColumnOnBoard = random.Next(0, boardDimension);


            targetedBoard[randomRowOnBoard][randomColumnOnBoard]+= 2;


            result = $"{Name} fired at row {randomRowOnBoard} column {randomColumnOnBoard}";
            Console.WriteLine(result);

            

        }
        public override string GetName()
        {
            string computerName = "Computer"; 
            computerName += IsPlayer1 ? "1" : "2";
            return computerName;
        }

    }
}
