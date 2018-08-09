using System;

namespace BattleShip
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Game game = new Game();

            do
            {
                game.RunStartGame();
                game.RunGame();
                game.RunEndGame();
            }
            while (game.WantsToPlayAgain());
        }
    }
}
