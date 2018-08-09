using System;
using System.Collections.Generic;

namespace BattleShip
{
    public class Game
    {
        // Member Variables
        List<Player> players;
        private int boardDimension;
        private int maxNumberOfPlayers;

        public int BoardDimension { get => boardDimension; set => boardDimension = value; }

        // Constructors
        public Game()
        {
            maxNumberOfPlayers = 2;
        }

        // Methods
        public void RunStartGame()
        {
            SetUpPlayers();
            SetUpGame();
            RunShipCreation();
        }

        private void SetUpPlayers()
        {
            players = new List<Player>();
            for (int i = 0; i < maxNumberOfPlayers; i++)
            {
                players.Add(CreateNewPlayer());
            }
            DeterminePlayer1();
            foreach(Player player in players)
            {
                player.Name = player.GetName();
            }

        }

        public void SetUpGame() 
        {
            UserInterface.WelcomePlayers(players);
            SetSizeOfBoard();
            CreatePlayerBoard();
        }



        public void RunShipCreation()
        {
            foreach(Player player in players)
            {
                foreach(Ship ship in player.Ships)
                {
                    player.GetShipStartingPosition(ship, boardDimension);
                    player.GetShipOrientation(ship);
                    player.PlaceShip(boardDimension, ship);
                }
                UserInterface.ConfirmShipCreation(player);
            }
        }

        public void RunGame()
        {
            do
            {
                UserInterface.DisplayBoard(players[0]);
                players[0].FireAtTarget(players[1], boardDimension);
                players[0].CheckEnemyShipStatus(players[1]);
                if(!NewRoundNeeded())
                {
                    break;
                }
                UserInterface.DisplayBoard(players[1]);
                players[1].FireAtTarget(players[0], boardDimension);
                players[1].CheckEnemyShipStatus(players[0]);
            } while (NewRoundNeeded());

        }
        public void RunEndGame()
        {
            DetermineResults();
        }

        private Player CreateNewPlayer()
        {
            string playerType;
            Player player;

            UserInterface.AskPlayerType();
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
                    UserInterface.ErrorMessage();
                    return CreateNewPlayer();

            }

        }

        private void CreatePlayerBoard ()
        {
            foreach (Player player in players)
            {
                player.Board = player.CreateBoard(boardDimension);
            }
            UserInterface.ConfirmBoardCreation(boardDimension);
        }
        private void WelcomePlayers()
        {
            Console.WriteLine($"Welcome to Battleship, {players[0].Name} and {players[1].Name}!");
        }

        private void SetSizeOfBoard()
        {
            boardDimension = GetSizeOfBoard();

        }

        private int GetSizeOfBoard()
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
        private void DeterminePlayer1()
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


        private void DetermineResults()
        {
            foreach(Player player in players)
            {
                if (player.PlayerShipsDestroyed())
                {
                    Console.WriteLine($"{player.Name} has no more ships.");
                }
                if (player.PlayerShipsAlive())
                {
                    Console.WriteLine($"{player.Name} has won!!");
                }
            }
        }

        private bool NewRoundNeeded()
        {
            foreach(Player player in players)
            {
                int counter = 0;
                foreach(Ship ship in player.Ships)
                {
                    if (ship.IsDestroyed)
                    {
                        counter++;
                    }
                    if (counter == player.Ships.Count)
                    {
                        return false;

                    }
                }

            }
            return true;
        }

        public bool WantsToPlayAgain()
        {
            Console.WriteLine("Would you like to play again? [1]Yes or [2]No");
            string playAgainString = Console.ReadLine();

            switch(playAgainString)
            {
                case "1":
                    return true;
                case "2":
                    return false;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    return WantsToPlayAgain();
            }
        }

    }   
}
