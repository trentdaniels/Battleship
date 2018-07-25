using System;
namespace BattleShip
{
    public class Player
    {
        // Members
        public string name;
        bool isPlayer1;

        // Constructors
        public Player(bool isPlayer1)
        {
            this.isPlayer1 = isPlayer1;
            GetName(); 
        }

        // Methods
        public void GetName() {
            string welcome;


            welcome = isPlayer1 ? "Welcome Player 1. What is your name?" : "Welcome Player 2. What is your name?";
            Console.WriteLine(welcome);
            name = Console.ReadLine();
            Console.WriteLine("Welcome to Battleship, {0}.", name);
            Console.ReadLine();
        }
    }
}
