using System;
namespace BattleShip
{
    public class Game
    {
        // Member Variables
        Player player1;
        Player player2;
        //Grid grid;

        // Constructors
        public Game()
        {
            SetUpGame();
            RunGame();
        }

        // Methods
        public void SetUpGame() 
        {
            player1 = new Player(true);
            player2 = new Player(false);
        }

        public void RunGame()
        {

        }
    }   
}
