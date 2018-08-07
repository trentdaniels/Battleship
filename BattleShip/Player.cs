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
        private bool isPlayer1;


        public string Name { get => name; set => name = value; }
        public Board Board { get => board; set => board = value; }
        public bool IsPlayer1 { get => isPlayer1; set => isPlayer1 = value; }
        public List<Ship> Ships { get => ships; set => ships = value; }


        // Constructors
        public Player()
        {
            board = new Board();
            CreateShips();
        }

        // Methods

        public abstract void FireAtTarget(Player targetedPlayer, int boardDimension);

        public abstract string GetName();
       

       
        public void CreateShips () 
        {
            ships = new List<Ship>() { };
            ships.Add(new Destroyer());
            ships.Add(new Submarine());
            ships.Add(new Battleship());
            ships.Add(new AircraftCarrier());
        }
    }
}
