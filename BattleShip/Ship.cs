using System;
using System.Collections.Generic;

namespace BattleShip
{
    public abstract class Ship
    {
        // Member Variables
        private int size;
        private string orientation;
        private string type;
        private int originX;
        private int originY;
        private List<Coordinate> coordinates;
        private bool isDestroyed;

        public int Size { get => size; set => size = value; }
        public string Orientation { get => orientation; set => orientation = value; }
        public string Type { get => type; set => type = value; }
        public int OriginX { get => originX; set => originX = value; }
        public int OriginY { get => originY; set => originY = value; }
        public List<Coordinate> Coordinates { get => coordinates; set => coordinates = value; }
        public bool IsDestroyed { get => isDestroyed; set => isDestroyed = value; }


        // Constructors
        public Ship()
        {
            coordinates = new List<Coordinate>();
        }

        // Methods



       

            


        public bool NeedsReAlignmentX(int boardDimension)
        {
            return OriginX + Size > boardDimension - 1;
        }
        public bool NeedsReAlignmentY(int boardDimension)
        {
            return OriginY + Size > boardDimension - 1;
        }
        public bool OverlapsOtherShipX(Board board, int index)
        {
            for (int i = index; i < Size; i++)
            {
                if (board.Grid[OriginX + i][OriginY] == 1)
                {
                    return true;
                }
            }
            return false;
        }
        public bool OverlapsOtherShipY(Board board, int index)
        {
            for (int i = index; i < Size; i++)
            {
                if (board.Grid[OriginX][OriginY + i] == 1)
                {
                    return true;
                }
            }
            return false;
        }


        public void ReverseShipCreationDirectionX(Board board)
        {
            for (int i = 0; i < size; i++)
            {
                coordinates.Add(new Coordinate(originX - i, originY));
                board.Grid[originX - i][originY] = 1;
            }
            Console.WriteLine("Re-aligned ship to your board.");
        }
        public void ReverseShipCreationDirectionY(Board board)
        {
            for (int i = 0; i < size; i++)
            {
                coordinates.Add(new Coordinate(originX, originY - i));
                board.Grid[originX][originY - i] = 1;
            }
            Console.WriteLine("Re-aligned ship to your board.");
        }
            
    }
}
