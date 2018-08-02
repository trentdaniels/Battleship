using System;
namespace BattleShip
{
    public abstract class Ship
    {
        // Member Variables
        public int size;
        public string orientation;
        public string type;
        public int originX;
        public int originY;

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
            if (originX + size > board.boardDimension)
            {
                originX = board.boardDimension;
                for (int i = board.boardDimension; i > board.boardDimension - size; i--) 
                {
                    board.grid[originX - i][originY] = 1;

                }
                Console.WriteLine("Re-aligned ship to your board.");
            }
            else if (originY + size > board.boardDimension) 
            {
                originY = board.boardDimension;
                for (int i = board.boardDimension; i > board.boardDimension - size; i--) 
                {
                    board.grid[originX][originY - i] = 1;

                }
                Console.WriteLine("Re-aligned ship to your board.");
            }
        }
    }
}
