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
                Console.WriteLine($"{Name} missed at row {randomRowOnBoard} column {randomColumnOnBoard}.");
                break;

            }


        }
        public override string GetName()
        {
            string computerName = "Computer"; 
            computerName += IsPlayer1 ? "1" : "2";
            return computerName;
        }



        public override void GetShipStartingPosition(Ship ship, int boardDimension)
        {
            int selectedRow;
            int selectedColumn;

            selectedRow = random.Next(0, boardDimension);
            selectedColumn = random.Next(0, boardDimension);

            ship.OriginX = selectedRow;
            ship.OriginY = selectedColumn;
        }

        public override void GetShipOrientation(Ship ship)
        {
            int randomOrientation = random.Next(0, 2);

            switch(randomOrientation)
            {
                case 0:
                    ship.Orientation = "horizontal";
                    break;
                case 1:
                    ship.Orientation = "vertical";
                    break;
            }
        }



    }
}
