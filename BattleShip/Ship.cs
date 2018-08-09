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
        public bool OverlapsOtherShipX(string[][] board, int index)
        {
            for (int i = index; i < Size; i++)
            {
                if (board[OriginX + i][OriginY] == "O")
                {
                    return true;
                }
            }
            return false;
        }
        public bool OverlapsOtherShipY(string[][] board, int index)
        {
            for (int i = index; i < Size; i++)
            {
                if (board[OriginX][OriginY + i] == "O")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
