using System;
namespace BattleShip
{
    public abstract class Player
    {
        // Members
        public string name;
        public bool isPlayer1;

        // Constructors
        public Player()
        {
            
        }

        // Methods
        public void GetName() {
            string welcome;


            welcome = isPlayer1 ? "Welcome Player 1. What is your name?" : "Welcome Player 2. What is your name?";
            Console.WriteLine(welcome);
            name = Console.ReadLine();
            Console.WriteLine($"Welcome to Battleship, {name}!");
            Console.ReadLine();
        }
        public abstract void FireAtTarget(Board board, Player targetedPlayer);
    }
}
