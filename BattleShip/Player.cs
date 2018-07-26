using System;
namespace BattleShip
{
    public abstract class Player
    {
        // Members
        public string name;
        public bool isPlayer1;
        public Board board;

        // Constructors
        public Player()
        {
            
        }

        // Methods
        public void GetName() {
            string welcome;


            welcome = "Awesome! What is your name?";
            Console.WriteLine(welcome);
            name = Console.ReadLine();
            Console.WriteLine($"Welcome to Battleship, {name}!");
            Console.ReadLine();
        }
        public abstract void FireAtTarget(int[][] targetedBoard, Player targetedPlayer);
    }
}
