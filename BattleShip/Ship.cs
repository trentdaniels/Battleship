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
        public abstract void CreateShip(Player player);

        public void GetShipStartingPosition()
        {

            int startingRow;
            int startingColumn;

            Console.WriteLine("Which row would you like to create this ship?");
            startingRow = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Which Column?");
            startingColumn = int.Parse(Console.ReadLine()) - 1;

            originX = startingRow;
            originY = startingColumn;


        }
        public void ReAlignShip(Board board)
        {
            if (originX + size > board.BoardDimension)
            {
                originX = board.BoardDimension;
                for (int i = board.BoardDimension; i > board.BoardDimension - size; i--) 
                {
                    board.Grid[originX - i][originY] = 1;

                }
                Console.WriteLine("Re-aligned ship to your board.");
            }
            else if (originY + size > board.BoardDimension) 
            {
                originY = board.BoardDimension;
                for (int i = board.BoardDimension; i > board.BoardDimension - size; i--) 
                {
                    board.Grid[originX][originY - i] = 1;

                }
                Console.WriteLine("Re-aligned ship to your board.");
            }
        }
    }
}
