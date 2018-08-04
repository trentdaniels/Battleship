using System;
namespace BattleShip
{
    public abstract class Ship
    {
        // Member Variables
        private int size;
        private string orientation;
        private string type;
        private int originX;
        private int originY;

        public int Size { get => size; set => size = value; }
        public string Orientation { get => orientation; set => orientation = value; }
        public string Type { get => type; set => type = value; }
        public int OriginX { get => originX; set => originX = value; }
        public int OriginY { get => originY; set => originY = value; }


        // Constructors
        public Ship()
        {

        }

        // Methods

        public void GetShipStartingPosition()
        {
            Console.WriteLine($"On which row would you like to place the {Type}?");
            originX = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Which Column?");
            originY = int.Parse(Console.ReadLine()) - 1;
        }
        public void GetShipOrientation()
        {
            Console.WriteLine($"Would you like the {Type} to be [1]Horizontal or [2]Vertical  ?");
            string direction = Console.ReadLine();
            switch (direction) 
            {
                case "1":
                    orientation = "horizontal";
                    break;
                case "2":
                    orientation = "vertical";
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    GetShipOrientation();
                    return;
            }
        }

        public void ReAlignShipX(int boardDimension)
        {
            originX = boardDimension - 1;

        }
        public void ReAlignShipY(int boardDimension)
        {
            originY = boardDimension - 1;
        }

        public void PlaceShip(Board board, int boardDimension)
        {
            if (orientation == "horizontal")
            {
                for (int i = 0; i < Size; i++)
                {
                    if (NeedsReAlignmentX(boardDimension))
                    {
                        ReAlignShipX(boardDimension);
                        if (OverlapsOtherShipReverseX(board))
                        {
                            ShiftShipDown(board, boardDimension);
                            ReverseShipCreationDirectionX(board);
                            break;
                        }
                        ReverseShipCreationDirectionX(board);
                        break;
                    }
                    if (OverlapsOtherShipX(board))
                    {
                        ShiftShipDown(board, boardDimension); 
                        Console.WriteLine($"Shifted {Type} over to avoid overlapping ships.");  
                    }
                    board.Grid[OriginX + i][OriginY] = 1;
                }
            }

            else 
            {
                for (int i = 0; i < Size; i++)
                {
                    if (NeedsReAlignmentY(boardDimension))
                    {
                        ReAlignShipY(boardDimension);
                        if (OverlapsOtherShipReverseY(board))
                        {
                            ShiftShipAcross(board, boardDimension);

                            ReverseShipCreationDirectionY(board);
                            break;
                        }
                        ReverseShipCreationDirectionY(board);
                        break;
                    }
                    if (OverlapsOtherShipY(board))
                    {
                        ShiftShipAcross(board, boardDimension);
                        Console.WriteLine($"Shifted {Type} over to avoid overlapping ships.");  
                    }
                    board.Grid[OriginX][OriginY + i] = 1;
                }
            }

        }

        private bool NeedsReAlignmentX(int boardDimension)
        {
            return OriginX + Size > boardDimension - 1;
        }
        private bool NeedsReAlignmentY(int boardDimension)
        {
            return OriginY + Size > boardDimension - 1;
        }
        private bool OverlapsOtherShipX(Board board)
        {
            for (int i = 0; i < Size; i++)
            {
                if (board.Grid[OriginX + i][OriginY] == 1)
                {
                    return true;
                }
            }
            return false;
        }
        private bool OverlapsOtherShipY(Board board)
        {
            for (int i = 0; i < Size; i++)
            {
                if (board.Grid[OriginX][OriginY + i] == 1)
                {
                    return true;
                }
            }
            return false;
        }
        private bool OverlapsOtherShipReverseX(Board board)
        {
            for (int i = 0; i < size; i++)
            {
                if (board.Grid[OriginX - i][OriginY] == 1)
                {
                    return true;
                }
            }
            return false;
        }
        private bool OverlapsOtherShipReverseY(Board board)
        {
            for (int i = 0; i < size; i++)
            {
                if (board.Grid[OriginX][OriginY - i] == 1)
                {
                    return true;
                }
            }
            return false;
        }
        private void ShiftShipDown (Board board, int boardDimension)
        {
            while (OverlapsOtherShipX(board))
            {
                OriginY += 1;
                if (OriginY > boardDimension - 1)
                {
                    OriginY = 0;
                }
            }

        }
        private void ShiftShipAcross(Board board, int boardDimension)
        {
            while (OverlapsOtherShipY(board))
            {
                OriginX += 1;
                if(OriginX > boardDimension - 1)
                {
                    OriginX = 0;
                }
            }

        }
        private void ReverseShipCreationDirectionX(Board board)
        {
            for (int i = 0; i < size; i++)
            {
                board.Grid[originX - i][originY] = 1;
            }
            Console.WriteLine("Re-aligned ship to your board.");
        }
        private void ReverseShipCreationDirectionY(Board board)
        {
            for (int i = 0; i < size; i++)
            {
                board.Grid[originX][originY - i] = 1;
            }
            Console.WriteLine("Re-aligned ship to your board.");
        }
            
    }
}
