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
                                Console.WriteLine($"{Name} hit the {ship.Type} at row {selectedRow} column {selectedColumn}.");
                                break;
                            }

                        }
                    }
                    Console.WriteLine($"{Name} missed at row {selectedRow} column {selectedColumn}.");
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
        }

        private bool IsTargetOffBoard(int selectedRow, int selectedColumn, int boardDimension)
        {
            return selectedRow > boardDimension || selectedColumn > boardDimension;
        }

        public override string GetName()
        {
            string welcome;
            string playerName;

            welcome = $"{(IsPlayer1 ? "Player1:": "Player2:")} What is your name?";
            Console.WriteLine(welcome);
            playerName = Console.ReadLine();

            if (playerName.Length < 1)
            {
                Console.WriteLine("Whoops. Please enter a name next time!");
                return GetName();
            }
            return playerName;

        }
       

        public override void GetShipStartingPosition(Ship ship, int boardDimension)
        {
            int selectedColumn;
            int selectedRow;

            Console.WriteLine($"On which row would you like to place the {ship.Type}?");
            if (int.TryParse(Console.ReadLine(), out selectedRow))
            {
                if (selectedRow > boardDimension)
                {
                    Console.WriteLine("Selected Row isn't on the board. Please try again.");
                    GetShipStartingPosition(ship, boardDimension);
                    return;
                }
                ship.OriginX = selectedRow;
                ship.OriginX--;

            }
            else
            {
                Console.WriteLine("Whoops! Try Again.");
                GetShipStartingPosition(ship, boardDimension);
                return;
            }
            Console.WriteLine("Which Column?");
            if (int.TryParse(Console.ReadLine(), out selectedColumn))
            {
                if (selectedColumn > boardDimension)
                {
                    Console.WriteLine("Selected Column isn't on the board. Please try again.");
                    GetShipStartingPosition(ship, boardDimension);
                    return;
                }
                ship.OriginY = selectedColumn;
                ship.OriginY--;
            }
            else
            {
                Console.WriteLine("Whoops! Try Again.");
                GetShipStartingPosition(ship, boardDimension);
                return;
            }
        }

        public override void GetShipOrientation(Ship ship)
        {
            Console.WriteLine($"Would you like the {ship.Type} to be [1]Horizontal or [2]Vertical  ?");
            string direction = Console.ReadLine();
            switch (direction)
            {
                case "1":
                    ship.Orientation = "horizontal";
                    break;
                case "2":
                    ship.Orientation = "vertical";
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    GetShipOrientation(ship);
                    return;
            }
        }



    }    
}
