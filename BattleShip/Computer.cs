using System;
namespace BattleShip
{
    public class Computer : Player
    {
        // Members


        // Constructors
        public Computer(bool isPlayer1)
        {
            this.isPlayer1 = isPlayer1;
            GetName();
        }

        // Methods
        public override void FireAtTarget(Board board, Player player)
        {

        }

    }
}
