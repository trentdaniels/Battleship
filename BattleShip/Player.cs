using System;
namespace BattleShip
{
    public abstract class Player
    {
        // Members
        private string name;
        private Board board;
        private Ship ship;

        public string Name { get => name; set => name = value; }
        public Board Board { get => board; set => board = value; }
        public Ship Ship { get => ship; set => ship = value; }


        // Constructors
        public Player()
        {
            board = new Board();
        }

        // Methods

        public abstract void FireAtTarget(Player targetedPlayer);
    }
}
