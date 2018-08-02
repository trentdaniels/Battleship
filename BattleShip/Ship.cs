using System;
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

        public int Size { get => size; set => size = value; }
        public string Orientation { get => orientation; set => orientation = value; }
        public string Type { get => type; set => type = value; }
        public int OriginX { get => originX; set => originX = value; }
        public int OriginY { get => originY; set => originY = value; }


        // Constructors
        public Ship()
        {

        }

        // Methods
        public abstract void PlaceShip(Player player, int boardDimension);

        public void GetShipStartingPosition()
        {
            Console.WriteLine($"On which row would you like to place the {Type}?");
            originX = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Which Column?");
            originY = int.Parse(Console.ReadLine()) - 1;
        }

        public void ReAlignShipX(Board board, int boardDimension)
        {
            originX = boardDimension;
            for (int i = boardDimension; i > boardDimension - size; i--)
            {
                board.Grid[originX - i][originY] = 1;

            }
            Console.WriteLine("Re-aligned ship to your board.");
        }
        public void ReAlignShipY(Board board, int boardDimension)
        {
            originY = boardDimension;
            for (int i = boardDimension; i > boardDimension - size; i--)
            {
                board.Grid[originX][originY - i] = 1;

            }
            Console.WriteLine("Re-aligned ship to your board.");
        }
            
    }
}
