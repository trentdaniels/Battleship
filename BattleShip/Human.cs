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
                selectedRow--;
                Console.WriteLine($"Select Column");
                if(int.TryParse(Console.ReadLine(), out selectedColumn))
                {
                    selectedColumn--;
                    foreach(Ship ship in targetedPlayer.Ships)
                    {
                        foreach(Coordinate coordinate in ship.Coordinates)
                        {
                            if (selectedRow == coordinate.CoordinateX && selectedColumn == coordinate.CoordinateY)
                            {
                                coordinate.IsHit = true;
                                Console.WriteLine($"Hit the {ship.Type} at row {selectedRow} column {selectedColumn}.");
                                targetedBoard[selectedRow - 1][selectedColumn - 1] += 2;
                                break;
                            }

                        }
                    }
                    Console.WriteLine($"Missed at row {selectedRow} column {selectedColumn}.");
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


            Console.WriteLine($"{Name} fired at row {selectedRow} column {selectedColumn}");

            
        }
        private bool IsTargetOffBoard(int selectedRow, int selectedColumn, int boardDimension)
        {
            return selectedRow > boardDimension || selectedColumn > boardDimension;
        }

        public override string GetName()
        {
            string welcome;
            string playerName;

            welcome = "What is your name?";
            Console.WriteLine(welcome);
            playerName = Console.ReadLine();

            if (playerName.Length < 1)
            {
                Console.WriteLine("Whoops. Please enter a name next time!");
                return GetName();
            }
            return playerName;

        }
       
       



    }    
}
