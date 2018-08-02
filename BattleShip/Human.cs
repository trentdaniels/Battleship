using System;
namespace BattleShip
{
    public class Human : Player
    {
        // Members

        // Constructors
        public Human()
        {
            
            Name = GetName();
        }

        // Methods
        public override void FireAtTarget(Player targetedPlayer)
        {
            int selectedRow;
            int selectedColumn;
            int[][] targetedBoard;

            targetedBoard = targetedPlayer.board.grid;

            Console.WriteLine($"{name}, which row would you like to target?");
            selectedRow = int.Parse(Console.ReadLine());
            if (selectedRow > board.boardDimension) 
            {
                Console.WriteLine($"This is not a valid row. Please choose between 1 and {board.boardDimension}");
            }

            Console.WriteLine($"Select Column");
            selectedColumn = int.Parse(Console.ReadLine());
            if (selectedColumn > board.boardDimension)
            {
                Console.WriteLine($"This is not a valid column. Please choose between 1 and {board.boardDimension}");
            }
            targetedBoard[selectedRow - 1][selectedColumn - 1] += 2;
            Console.WriteLine($"{name} fired at row {selectedRow} column {selectedColumn}");

            
        }

        public string GetName()
        {
            string welcome;
            string playerName;

            welcome = "Awesome! What is your name?";
            Console.WriteLine(welcome);
            playerName = Console.ReadLine();

            if (playerName.Length < 1)
            {
                Console.WriteLine("Whoops. Please enter a name next time!");
                return GetName();
            }
            Console.WriteLine($"Welcome to Battleship, {name}!");
            return playerName;

        }



    }    
}
