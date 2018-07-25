using System;
namespace BattleShip
{
    public class Human : Player
    {
        // Members
       

        // Constructors
        public Human(bool isPlayer1)
        {
            this.isPlayer1 = isPlayer1;
            GetName();
        }

        // Methods
        public override void FireAtTarget(string target, Player player)
        {
            
        }



    }    
}
