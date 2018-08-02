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
            player1 = CreateNewPlayer(true);
            player2 = CreateNewPlayer(false);
            GetSizeOfBoard();
            CreatePlayerBoard();
        }

        public void RunGame()
        {
            Destroyer destroyer = new Destroyer();
            destroyer.CreateShip(player1);
            player1.FireAtTarget(player2.board.grid, player2, player1);
            player2.FireAtTarget(player1.board.grid, player1, player2);
        }

        public Player CreateNewPlayer(bool isPlayer1)
        {
            string playerType;
            Player player;

            Console.WriteLine("Welcome to Battleship " + (isPlayer1 ? "Player 1! " : "Player 2! ") + "Are you a 'human' or a 'computer'?");
            playerType = Console.ReadLine().ToLower();

            switch (playerType) 
            {
                case "human":
                    player = new Human(isPlayer1);
                    return player;
                case "computer":
                    player = new Computer(isPlayer1);
                    return player;
                default:
                    Console.WriteLine("Invalid input. Please choose 'human' or 'computer'");
                    return CreateNewPlayer(isPlayer1);
            }

        }
        public void GetSizeOfBoard() 
        {
            

            Console.WriteLine("How many rows does each board have? Please choose a number (20 and above).");
            int boardDimension = int.Parse(Console.ReadLine());
            if (boardDimension < 20)
            {
                Console.WriteLine("Your desired board size is too small. Please try again.");
                GetSizeOfBoard();

            }

            player1.board.boardDimension = boardDimension;
            player2.board.boardDimension = boardDimension;


        }

        public void CreatePlayerBoard () 
        {
            player1.board.grid = player1.board.CreateBoard(player1.board.boardDimension);
            player2.board.grid = player2.board.CreateBoard(player2.board.boardDimension);
            Console.WriteLine($"Each Player will have a board with dimensions of {player1.board.size}.");
            Console.WriteLine("Created the boards! Now, let's get ready to play.");
            Console.ReadLine();
        }



    }   
}
