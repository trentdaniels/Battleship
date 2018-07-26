using System;
namespace BattleShip
{
    public abstract class Player
    {
        // Members
        public string name;
        public bool isPlayer1;
        public Board board;
        public Ship ship;

        // Constructors
        public Player()
        {
            
        }

        // Methods

        public abstract void FireAtTarget(int[][] targetedBoard, Player targetedPlayer, Player shooter);
    }
}
