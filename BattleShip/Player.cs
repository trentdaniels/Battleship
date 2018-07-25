using System;
namespace BattleShip
{
    public abstract class Player
    {
        // Members
        public string name;
        bool isPlayer1;

        // Constructors
        public Player()
        {
            GetName(isPlayer1); 
        }

        // Methods
        public void GetName(bool isPlayer1) {
            string welcome;


            welcome = isPlayer1 ? "Welcome Player 1. What is your name?" : "Welcome Player 2. What is your name?";
            name = Console.ReadLine();
        }
    }
}
