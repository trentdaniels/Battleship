using System;
using System.Collections.Generic;

namespace BattleShip
{
    public abstract class Player
    {
        // Members
        private string name;
        private Board board;
        private List<Ship> ships;
        private bool isPlayer1;


        public string Name { get => name; set => name = value; }
        public Board Board { get => board; set => board = value; }
        public bool IsPlayer1 { get => isPlayer1; set => isPlayer1 = value; }
        public List<Ship> Ships { get => ships; set => ships = value; }


        // Constructors
        public Player()
        {
            board = new Board();
            CreateShips();
        }

        // Methods

        public abstract void FireAtTarget(Player targetedPlayer, int boardDimension);

        public abstract string GetName();

        public abstract void GetShipStartingPosition(Ship ship, int boardDimension);

        public abstract void GetShipOrientation(Ship ship);
       
        public void CreateShips () 
        {
            ships = new List<Ship>() { };
            ships.Add(new Destroyer());
            ships.Add(new Submarine());
            ships.Add(new Battleship());
            ships.Add(new AircraftCarrier());
        }

        private bool enemyShipIsDestroyed(Player targetedPlayer)
        {
            int counter = 0;

            foreach (Ship ship in targetedPlayer.Ships)
            {
                for (int i = 0; i < ship.Coordinates.Count; i++)
                {
                    if (ship.Coordinates[i].IsHit == true)
                    {
                        counter++;
                    }
                }
                if (counter == ship.Size)
                {

                    return true;
                }
            }
            return false;

        }
        public void CheckEnemyShipStatus(Player targetedPlayer)
        {
            foreach (Ship ship in targetedPlayer.Ships)
            {
                if (enemyShipIsDestroyed(targetedPlayer))
                {
                    Console.WriteLine($"{targetedPlayer.Name}'s {ship.Type} is destroyed!");
                    ship.IsDestroyed = true;
                    return;
                }
            }
        }

        public void ReAlignShipX(Ship ship)
        {
            ship.OriginX = 0;

        }
        public void ReAlignShipY(Ship ship)
        {
            ship.OriginY = 0;
        }

        public void ShiftShipDown(Board board, int boardDimension, int index, int counter, Ship ship)
        {
            while (ship.OverlapsOtherShipX(board, index))
            {
                ship.OriginY += 1;
                counter++;
                if (ship.OriginY > boardDimension - 1)
                {
                    ship.OriginY = 0;
                }
            }
            Console.WriteLine($"Shifted {ship.Type} down {counter} rows to avoid overlapping ships.");
        }
        public void ShiftShipAcross(Board board, int boardDimension, int index, int counter, Ship ship)
        {
            while (ship.OverlapsOtherShipY(board, index))
            {
                ship.OriginX += 1;
                counter++;
                if (ship.OriginX > boardDimension - 1)
                {
                    ship.OriginX = 0;
                }
            }
            Console.WriteLine($"Shifted {ship.Type} across {counter} columns to avoid overlapping ships.");
        }

        public void PlaceShip(Board board, int boardDimension, Ship ship)
        {
            int counter = 0;
            for (int i = 0; i < ship.Size; i++)
            {
                if (ship.Orientation == "horizontal")
                {
                    if (ship.NeedsReAlignmentX(boardDimension))
                    {
                        ReAlignShipX(ship);
                    }
                    if (ship.OverlapsOtherShipX(board, i))
                    {
                        ShiftShipDown(board, boardDimension, i, counter, ship);

                    }
                    ship.Coordinates.Add(new Coordinate(ship.OriginX + i, ship.OriginY));
                    board.Grid[ship.OriginX + i][ship.OriginY] = 1;
                }
                // Vertical Case
                else
                {
                    if (ship.NeedsReAlignmentY(boardDimension))
                    {
                        ReAlignShipY(ship);
                    }
                    if (ship.OverlapsOtherShipY(board, i))
                    {
                        ShiftShipAcross(board, boardDimension, i, counter, ship);

                    }
                    ship.Coordinates.Add(new Coordinate(ship.OriginX, ship.OriginY + i));
                    board.Grid[ship.OriginX][ship.OriginY + i] = 1;

                }
            }
        }

        public bool PlayerShipsDestroyed()
        {
            int counter = 0;
            foreach (Ship ship in Ships)
            {
                if (ship.IsDestroyed == true)
                {
                    counter++;
                }
            }
            if (counter == Ships.Count)
            {
                return true;
            }
            return false;
        }
        public bool PlayerShipsAlive()
        {
            foreach(Ship ship in Ships)
            {
                if (ship.IsDestroyed == false)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
