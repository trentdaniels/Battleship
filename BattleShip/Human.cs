using System;
namespace BattleShip
{
    public class Human : Player
    {
        // Members

        // Constructors
        public Human(bool isPlayer1)
        {
            this.isPlayer1 = isPlayer1;
            GetName();
            board = new Board();
        }

        // Methods
        public override void FireAtTarget(int[][] targetedBoard, Player targetedPlayer, Player shooter)
        {
            int selectedRow;
            int selectedColumn;

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

        public void GetName()
        {
            string welcome;


            welcome = "Awesome! What is your name?";
            Console.WriteLine(welcome);
            name = Console.ReadLine();
            Console.WriteLine($"Welcome to Battleship, {name}!");
            Console.ReadLine();
        }



    }    
}
