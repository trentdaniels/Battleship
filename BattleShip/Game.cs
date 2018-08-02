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
            WelcomePlayers();
            GetSizeOfBoard();
            CreatePlayerBoard();
        }

        public void RunGame()
        {
            Destroyer destroyer = new Destroyer();
            destroyer.CreateShip(player1);
            player1.FireAtTarget(player2);
            player2.FireAtTarget(player1);
        }

        public Player CreateNewPlayer(bool isPlayer1)
        {
            string playerType;
            Player player;

            Console.WriteLine("Welcome to Battleship " + (isPlayer1 ? "Player 1! " : "Player 2! "));
            Console.WriteLine("Please choose [1]Human or [2]Computer");
            playerType = Console.ReadLine().ToLower();

            switch (playerType) 
            {
                case "1":
                    player = new Human();
                    return player;
                case "2":
                    player = new Computer();
                    return player;
                default:
                    Console.WriteLine("Invalid input. Please choose 'human' or 'computer'");
                    return CreateNewPlayer(isPlayer1);
            }

        }
        public void GetSizeOfBoard() 
        {
            int boardDimension;

            Console.WriteLine("How many rows does each board have? Please choose a number (20 and above).");
            boardDimension = int.Parse(Console.ReadLine());
            if (boardDimension < 20)
            {
                Console.WriteLine("Your desired board size is too small. Please try again.");
                GetSizeOfBoard();

            }

            player1.Board.BoardDimension = boardDimension;
            player2.Board.BoardDimension = boardDimension;


        }

        public void CreatePlayerBoard () 
        {
            player1.Board.Grid = player1.Board.CreateBoard();
            player2.Board.Grid = player2.Board.CreateBoard();
            Console.WriteLine($"Each Player will have a board with dimensions of {player1.Board.Size}.");
            Console.WriteLine("Created the boards! Now, let's get ready to play.");
            Console.ReadLine();
        }
        private bool HasTwoHumanPlayers() 
        {
            if (player1.Name != "Computer" && player2.Name != "Computer")
            {
                return true;
            }
            return false;
        }
        private void WelcomePlayers()
        {
            if(HasTwoHumanPlayers())
            {
                Console.WriteLine($"Welcome to Battleship {player1.Name} and {player2.Name}!");
                return;
            }
            Console.WriteLine($"Welcome to Battleship {player1.Name}!");
        }




    }   
}
