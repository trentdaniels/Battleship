using System;
namespace BattleShip
{
    public class Game
    {
        // Member Variables
        Player player1;
        Player player2;
        Board board;

        // Constructors
        public Game()
        {
            SetUpGame();
            RunGame();
        }

        // Methods
        public void SetUpGame() 
        {
            player1 = CreateNewPlayer(player1, true);
            player2 = CreateNewPlayer(player2, false);
            board = new Board();
        }

        public void RunGame()
        {

        }
        public Player CreateNewPlayer(Player player, bool isPlayer1)
        {
            string playerType;

            Console.WriteLine("Welcome to Battleship. Are you a 'human' or a 'computer'?");
            playerType = Console.ReadLine().ToLower();

            switch (playerType) 
            {
                case "human":
                    player = new Human(isPlayer1);
                    break;
                case "computer":
                    player = new Computer(isPlayer1);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please choose 'human' or 'computer'");
                    Console.ReadLine();
                    CreateNewPlayer(player, isPlayer1);
                    break;
            }
            return player;

        }



    }   
}
