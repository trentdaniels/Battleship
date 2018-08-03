using System;
namespace BattleShip
{
    public class Human : Player
    {
        // Members

        // Constructors
        public Human()
        {
        }

        // Methods
        public override void FireAtTarget(Player targetedPlayer, int boardDimension)
        {
            int selectedRow;
            int selectedColumn;
            int[][] targetedBoard;

            targetedBoard = targetedPlayer.Board.Grid;

            Console.WriteLine($"{Name}, which row would you like to target?");
            if(int.TryParse(Console.ReadLine(), out selectedRow))
            {
                Console.WriteLine($"Select Column");
                if(int.TryParse(Console.ReadLine(), out selectedColumn))
                {
                    targetedBoard[selectedRow - 1][selectedColumn - 1] += 2;
                }
                else 
                {
                    Console.WriteLine("Invalid Column. Please try again.");
                    FireAtTarget(targetedPlayer, boardDimension);
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid Row. Please try again.");
                FireAtTarget(targetedPlayer, boardDimension);
                return;
            }
            if (IsTargetOffBoard(selectedRow,selectedColumn,boardDimension)) 
            {
                Console.WriteLine($"This is not a valid target.");
                FireAtTarget(targetedPlayer, boardDimension);
                return;
            }

            targetedBoard[selectedRow - 1][selectedColumn - 1] += 2;
            Console.WriteLine($"{Name} fired at row {selectedRow} column {selectedColumn}");

            
        }
        private bool IsTargetOffBoard(int selectedRow, int selectedColumn, int boardDimension)
        {
            return selectedRow > boardDimension || selectedColumn > boardDimension;
        }
       
       



    }    
}
