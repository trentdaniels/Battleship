using System;
namespace BattleShip
{
    public class Game
    {
        // Member Variables
        Player player1;
        Player player2;

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
            GetSizeOfBoard(player1, player2);
            CreatePlayerBoard(player1, player2);
        }

        public void RunGame()
        {
            player1.FireAtTarget(player2.board.grid, player2);
            player2.FireAtTarget(player1.board.grid, player1);
        }

        public Player CreateNewPlayer(Player player, bool isPlayer1)
        {
            string playerType;

            Console.WriteLine("Welcome to Battleship " + (isPlayer1 ? "Player 1! " : "Player 2! ") + "Are you a 'human' or a 'computer'?");
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
        public void GetSizeOfBoard(Player firstPlayer, Player secondPlayer) 
        {
            firstPlayer = player1;
            secondPlayer = player2;

            Console.WriteLine("How many rows does each board have? Please choose a number (20 and above).");
            int boardDimension = int.Parse(Console.ReadLine());
            if (boardDimension < 20)
            {
                Console.WriteLine("Your desired board size is too small. Please try again.");
                GetSizeOfBoard(firstPlayer, secondPlayer);

            }

            player1.board.boardDimension = boardDimension;
            player2.board.boardDimension = boardDimension;


        }

        public void CreatePlayerBoard (Player firstPlayer, Player secondPlayer) 
        {
            firstPlayer = player1;
            secondPlayer = player2;

            firstPlayer.board.grid = firstPlayer.board.CreateBoard(firstPlayer.board.boardDimension);
            secondPlayer.board.grid = secondPlayer.board.CreateBoard(secondPlayer.board.boardDimension);
            Console.WriteLine($"Each Player will have a board with dimensions of {firstPlayer.board.size}.");
            Console.WriteLine("Created the boards! Now, let's get ready to play.");
            Console.ReadLine();
        }



    }   
}
