using System;
using System.Collections.Generic;

namespace BattleShip
{
    public abstract class Player
    {
        // Members
        private string name;
        private string[][] board;
        private List<Ship> ships;
        private bool isPlayer1;
        private string shipMarker;
        private string hitMarker;
        private string missMarker;
        private string boardMarker;


        public string HitMarker { get => hitMarker; }
        public string MissMarker { get => missMarker; }
        public string Name { get => name; set => name = value; }
        public string[][] Board { get => board; set => board = value; }
        public bool IsPlayer1 { get => isPlayer1; set => isPlayer1 = value; }
        public List<Ship> Ships { get => ships; set => ships = value; }


        // Constructors
        public Player()
        {
            CreateShips();
            CreateMarkers();
        }

        // Methods

        public abstract void FireAtTarget(Player targetedPlayer, int boardDimension);

        public abstract string GetName();

        public abstract void GetShipStartingPosition(Ship ship, int boardDimension);

        public abstract void GetShipOrientation(Ship ship);
       
        private void CreateShips () 
        {
            ships = new List<Ship>() { };
            ships.Add(new Destroyer());
            ships.Add(new Submarine());
            ships.Add(new Battleship());
            ships.Add(new AircraftCarrier());
        }
        private void CreateMarkers()
        {
            shipMarker = "S ";
            hitMarker = "X ";
            missMarker = "0 ";
            boardMarker = "# ";
        }

        private bool EnemyShipIsDestroyed(Ship ship)
        {
            int hitCounter = 0;

            for (int i = 0; i < ship.Coordinates.Count; i++)
            {
                if (ship.Coordinates[i].IsHit)
                {
                    hitCounter++;
                }
            }
            if (hitCounter == ship.Size)
            {
                return true;
            }
            return false;

        }
        public void CheckEnemyShipStatus(Player targetedPlayer)
        {
            foreach (Ship ship in targetedPlayer.Ships)
            {
                if (EnemyShipIsDestroyed(ship))
                {
                    Console.WriteLine($"{targetedPlayer.Name}'s {ship.Type} is destroyed!");
                    ship.IsDestroyed = true;
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

        public void ShiftShipDown(int boardDimension, int index, int counter, Ship ship)
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
            Console.WriteLine($"Shifted {ship.Type} over {counter} rows to avoid overlapping ships.");
        }
        public void ShiftShipAcross(int boardDimension, int index, int counter, Ship ship)
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
            Console.WriteLine($"Shifted {ship.Type} over {counter} columns to avoid overlapping ships.");
        }

        public void PlaceShip(int boardDimension, Ship ship)
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
                        ShiftShipDown(boardDimension, i, counter, ship);

                    }
                    ship.Coordinates.Add(new Coordinate(ship.OriginX + i, ship.OriginY));
                    board[ship.OriginX + i][ship.OriginY] = shipMarker;
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
                        ShiftShipAcross(boardDimension, i, counter, ship);

                    }
                    ship.Coordinates.Add(new Coordinate(ship.OriginX, ship.OriginY + i));
                    board[ship.OriginX][ship.OriginY + i] = shipMarker;

                }
            }
        }

        public bool PlayerShipsDestroyed()
        {
            int counter = 0;
            foreach (Ship ship in Ships)
            {
                if (ship.IsDestroyed)
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
                if (!ship.IsDestroyed)
                {
                    return true;
                }
            }
            return false;
        }

        public string[][] CreateBoard(int boardDimension)
        {
            
            string[][] newBoard;

            newBoard = new string[boardDimension][];


            for (int i = 0; i < newBoard.Length; i++)
            {
                newBoard[i] = new string[boardDimension];
                for (int j = 0; j < newBoard.Length; j++)
                {
                    newBoard[i][j] = boardMarker;
                }
            }

            return newBoard;
        }

    }
}
