using System;
using System.Collections.Generic;

namespace BattleShip
{
    public class Game
    {
        // Member Variables
        Player player1;
        Player player2;
        List<Player> players;
        private int boardDimension;

        public int BoardDimension { get => boardDimension; set => boardDimension = value; }

        // Constructors
        public Game()
        {
            SetUpPlayers();
            SetUpGame();
            RunShipCreation();
            RunGame();
        }

        // Methods
        private void SetUpPlayers()
        {
            player1 = CreateNewPlayer();
            player2 = CreateNewPlayer();
                
            players = new List<Player>() { };
            players.Add(player1);
            players.Add(player2);

        }

        public void SetUpGame() 
        {
            WelcomePlayers();
            SetSizeOfBoard();
            CreatePlayerBoard();
        }



        public void RunShipCreation()
        {
            foreach(Player player in players)
            {
                foreach(Ship ship in player.Ships)
                {
                    ship.GetShipStartingPosition();
                    ship.PlaceShip(player, boardDimension);
                }
            }
        }

        public void RunGame()
        {
            player1.FireAtTarget(player2, boardDimension);
            player2.FireAtTarget(player1, boardDimension);
        }

        public Player CreateNewPlayer()
        {
            string playerType;
            Player player;

            Console.WriteLine("New Player:");
            Console.WriteLine("Are you a [1]Human or [2]Computer");
            playerType = Console.ReadLine();

            switch (playerType) 
            {
                case "1":
                    player = new Human();
                    return player;
                case "2":
                    player = new Computer();
                    return player;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    return CreateNewPlayer();
            }

        }

        public void CreatePlayerBoard () 
        {
            player1.Board.Grid = player1.Board.CreateBoard(boardDimension);
            player2.Board.Grid = player2.Board.CreateBoard(boardDimension);
            Console.WriteLine($"Each Player will have a board with dimensions of {player1.Board.Size}.");
            Console.WriteLine("Created the boards! Now, let's get ready to play.");
        }
        private void WelcomePlayers()
        {
            Console.WriteLine($"Welcome to Battleship {player1.Name} and {player2.Name}!");
        }

        public void SetSizeOfBoard()
        {
            boardDimension = GetSizeOfBoard();

        }

        public int GetSizeOfBoard()
        {

            Console.WriteLine("How many rows does each board have? Please choose a number (20 and above).");
            int boardPossibleDimension = int.Parse(Console.ReadLine());
            if (boardPossibleDimension < 20)
            {
                Console.WriteLine("Your desired board size is too small. Please try again.");
                return GetSizeOfBoard();

            }
            return boardPossibleDimension;
        }





    }   
}
