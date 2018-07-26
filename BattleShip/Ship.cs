using System;
namespace BattleShip
{
    public abstract class Ship
    {
        // Member Variables
        public int size;
        public string orientation;
        public string name;

        // Constructors
        public Ship()
        {
            
        }

        // Methods
        public abstract void CreateShip();
    }
}
