using System;
using System.Collections.Generic;

namespace BattleShip
{
    public class Game
    {
        // Member Variables
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
            players = new List<Player>();
            for (int i = 0; i < 2; i++)
            {
                players.Add(CreateNewPlayer());
                players[i].Name = players[i].GetName();
            }
            DeterminePlayer1();
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
                Console.WriteLine($"{player.Name}:");
                foreach(Ship ship in player.Ships)
                {
                    ship.GetShipStartingPosition();
                    ship.GetShipOrientation();
                    ship.PlaceShip(player.Board, boardDimension);
                }
            }
        }

        public void RunGame()
        {
            players[0].FireAtTarget(players[1], boardDimension);
            players[1].FireAtTarget(players[0], boardDimension);
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
            players[0].Board.Grid = players[0].Board.CreateBoard(boardDimension);
            players[1].Board.Grid = players[1].Board.CreateBoard(boardDimension);
            Console.WriteLine($"Each Player will have a board with dimensions of {players[0].Board.Size}.");
            Console.WriteLine("Created the boards! Now, let's get ready to play.");
        }
        private void WelcomePlayers()
        {
            Console.WriteLine($"Welcome to Battleship {players[0].Name} and {players[1].Name}!");
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
        public void DeterminePlayer1()
        {
            foreach(Player player in players)
            {
                if (players.IndexOf(player) % 2 == 0)
                {
                    player.IsPlayer1 = true;
                }
                else
                {
                    player.IsPlayer1 = false;
                }
            }
        }





    }   
}
