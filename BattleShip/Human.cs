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
        public override void FireAtTarget(int[][] targetedBoard, Player targetedPlayer)
        {
            int selectedRow;
            int selectedColumn;

            Console.WriteLine($"{targetedPlayer.name}, which row would you like to target?");
            selectedRow = int.Parse(Console.ReadLine());
            if (selectedRow > board.boardDimension) 
            {
                Console.WriteLine($"This is not a valid row. Please choose between 1 and {board.boardDimension}");
            }

            Console.WriteLine($"You selected row {selectedRow}. Which column would you like to target?");
            selectedColumn = int.Parse(Console.ReadLine());
            if (selectedColumn > board.boardDimension)
            {
                Console.WriteLine($"This is not a valid column. Please choose between 1 and {board.boardDimension}");
            }

            Console.WriteLine($"You selected column {selectedColumn}. Firing at {targetedPlayer.name}");

            
        }



    }    
}
