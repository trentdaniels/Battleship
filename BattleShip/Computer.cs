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
            int randomRowOnBoard;
            int randomColumnOnBoard;
            int[][] targetedBoard;

            targetedBoard = targetedPlayer.Board.Grid;
            randomRowOnBoard = random.Next(0, boardDimension);
            randomColumnOnBoard = random.Next(0, boardDimension);

            foreach (Ship ship in targetedPlayer.Ships)
            {
                foreach(Coordinate coordinate in ship.Coordinates)
                {
                    if (randomRowOnBoard == coordinate.CoordinateX && randomColumnOnBoard == coordinate.CoordinateY)
                    {
                        Console.WriteLine($"{Name} hit the {ship.Type} at row {randomRowOnBoard} column {randomColumnOnBoard}.");
                        coordinate.IsHit = true;
                        break;
                    }
                }
                Console.WriteLine($"Missed at row {randomRowOnBoard} column {randomColumnOnBoard}.");
            }


        }
        public override string GetName()
        {
            string computerName = "Computer"; 
            computerName += IsPlayer1 ? "1" : "2";
            return computerName;
        }

    }
}
