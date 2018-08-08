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
       
        public override void PlaceShip(Board board, int boardDimension, Ship ship)
        {
            int counter = 0;
            for (int i = 0; i < ship.Size; i++)
            {
                if (ship.Orientation == "horizontal")
                {
                    if (ship.NeedsReAlignmentX(boardDimension))
                    {
                        ReAlignShipX(ship);
                    }
                    if (ship.OverlapsOtherShipX(board, i))
                    {
                        ShiftShipDown(board, boardDimension, i, counter, ship);

                    }
                    ship.Coordinates.Add(new Coordinate(ship.OriginX + i, ship.OriginY));
                    board.Grid[ship.OriginX + i][ship.OriginY] = 1;
                }
                // Vertical Case
                else
                {
                    if (ship.NeedsReAlignmentY(boardDimension))
                    {
                        ReAlignShipY(ship);
                    }
                    if (ship.OverlapsOtherShipY(board, i))
                    {
                        ShiftShipAcross(board, boardDimension, i, counter, ship);

                    }
                    ship.Coordinates.Add(new Coordinate(ship.OriginX, ship.OriginY + i));
                    board.Grid[ship.OriginX][ship.OriginY + i] = 1;

                }
            }
        }

        private void ReAlignShipX(Ship ship)
        {
            ship.OriginX = 0;

        }
        private void ReAlignShipY(Ship ship)
        {
            ship.OriginY = 0;
        }

        private void ShiftShipDown(Board board, int boardDimension, int index, int counter, Ship ship)
        {
            while (ship.OverlapsOtherShipX(board, index))
            {
                ship.OriginY += 1;
                counter++;
                if (ship.OriginY > boardDimension - 1)
                {
                    ship.OriginY = 0;
                }
            }
            Console.WriteLine($"Shifted {ship.Type} down {counter} rows to avoid overlapping ships.");
        }
        private void ShiftShipAcross(Board board, int boardDimension, int index, int counter, Ship ship)
        {
            while (ship.OverlapsOtherShipY(board, index))
            {
                ship.OriginX += 1;
                counter++;
                if (ship.OriginX > boardDimension - 1)
                {
                    ship.OriginX = 0;
                }
            }
            Console.WriteLine($"Shifted {ship.Type} across {counter} columns to avoid overlapping ships.");
        }

        public void GetShipStartingPosition(Ship ship)
        {
            int selectedColumn;
            int selectedRow;

            Console.WriteLine($"On which row would you like to place the {ship.Type}?");
            if (int.TryParse(Console.ReadLine(), out selectedRow))
            {
                ship.OriginX = selectedRow;
                ship.OriginX--;
            }
            else
            {
                Console.WriteLine("Whoops! Try Again.");
                GetShipStartingPosition(ship);
                return;
            }
            Console.WriteLine("Which Column?");
            if (int.TryParse(Console.ReadLine(), out selectedColumn))
            {
                ship.OriginY = selectedColumn;
                ship.OriginY--;
            }
            else
            {
                Console.WriteLine("Whoops! Try Again.");
                GetShipStartingPosition(ship);
                return;
            }
        }

        public void GetShipOrientation(Ship ship)
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
