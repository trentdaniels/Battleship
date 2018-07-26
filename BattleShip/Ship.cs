using System;
namespace BattleShip
{
    public abstract class Ship
    {
        // Member Variables
        public int size;
        public string orientation;
        public string name;
        public int originX;
        public int originY;

        // Constructors
        public Ship()
        {
            
        }

        // Methods
        public abstract void CreateShip(Player player);

        public void GetStartingPosition(Player player) 
        {

            int startingRow;
            int startingColumn;

            Console.WriteLine("Which row would you like to create this ship?");
            startingRow = int.Parse(Console.ReadLine());
            Console.WriteLine("Which Column?");
            startingColumn = int.Parse(Console.ReadLine());

            originX = startingRow;
            originY = startingColumn;


        }
    }
}
