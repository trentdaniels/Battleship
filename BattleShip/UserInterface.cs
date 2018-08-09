using System;
using System.Collections.Generic;

namespace BattleShip
{
    static class UserInterface
    {
        // Members
        private static int numberOfRounds;

        public static int  NumberOfRounds { get => numberOfRounds; set => numberOfRounds = value; }

        // Constructor
        static UserInterface()
        {
            
        }

        // Methods
        public static void WelcomePlayers (List<Player>players)
        {
            Console.WriteLine($"Welcome to Battleship, {players[0].Name} and {players[1].Name}!");
        }

        public static void ConfirmShipCreation (Player player)
        {
            Console.WriteLine($"Created Ships for {player.Name}.");
        }

        public static void AskPlayerType ()
        {
            Console.WriteLine($"New Player:");
            Console.WriteLine("Are you a [1]Human or [2]Computer");
        }

        public static void ErrorMessage()
        {
            Console.WriteLine("Invalid input. Please try again.");
        }

        public static void ConfirmBoardCreation(int boardDimension)
        {
            Console.WriteLine($"Each Player will have a board with dimensions of {boardDimension} x {boardDimension} units.");
            Console.WriteLine("Created the boards! Now, let's get ready to play.");

        }

        public static void DisplayBoard(Player player)
        {
            string rowOfString;
            Console.WriteLine($"{player.Name}'s Board:");
            for (int i = 0; i < player.Board.Length; i++)
            {
                rowOfString = "";
                for (int j = 0; j < player.Board.Length; j++)
                {
                    rowOfString += player.Board[i][j];
                }
                Console.WriteLine(rowOfString);
            }
        }
    }

}
