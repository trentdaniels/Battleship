using System;
using System.Collections.Generic;

namespace BattleShip
{
    public abstract class Player
    {
        // Members
        private string name;
        private Board board;
        private List<Ship> ships;
       

        public string Name { get => name; set => name = value; }
        public Board Board { get => board; set => board = value; }
        public List<Ship> Ships { get => ships; set => ships = value; }


        // Constructors
        public Player()
        {
            Name = GetName();
            board = new Board();
            CreateShips();
        }

        // Methods

        public abstract void FireAtTarget(Player targetedPlayer, int boardDimension);
        public string GetName()
        {
            string welcome;
            string playerName;

            welcome = "What is your name?";
            Console.WriteLine(welcome);
            playerName = Console.ReadLine();

            if (playerName.Length < 1)
            {
                Console.WriteLine("Whoops. Please enter a name next time!");
                return GetName();
            }
            return playerName;

        }

       
        public void CreateShips () 
        {
            ships = new List<Ship>() { };
            ships.Add(new Destroyer());
        }
    }
}
