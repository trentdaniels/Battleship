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

        public void ReAlignShipX(Board board, int boardDimension)
        {
            originX = boardDimension;
            for (int i = boardDimension; i > boardDimension - size; i--)
            {
                board.Grid[originX - i][originY] = 1;
            }
            Console.WriteLine("Re-aligned ship to your board.");
        }
        public void ReAlignShipY(Board board, int boardDimension)
        {
            originY = boardDimension;
            for (int i = boardDimension; i > boardDimension - size; i--)
            {
                board.Grid[originX][originY - i] = 1;

            }
            Console.WriteLine("Re-aligned ship to your board.");
        }

        public void PlaceShip(Board board, int boardDimension)
        {
            int counter = 0;
            if (orientation == "horizontal")
            {
                for (int i = 0; i < Size; i++)
                {
                    if (NeedsReAlignment(boardDimension))
                    {
                        if (OverlapsOtherShip(board, i))
                        {
                            ShiftShipDown(board, i, counter);                            
                        }
                        ReAlignShipX(board, boardDimension);
                        break;
                    }
                    if (OverlapsOtherShip(board, i))
                    {
                        ShiftShipDown(board, i, counter);                   
                    }
                    board.Grid[OriginX + i][OriginY] = 1;
                }
            }

            else 
            {
                for (int i = 0; i < Size; i++)
                {
                    if (NeedsReAlignment(boardDimension))
                    {
                        if (OverlapsOtherShip(board, i))
                        {
                            ShiftShipAcross(board, i, counter);
                        }
                        ReAlignShipY(board, boardDimension);
                        break;
                    }
                    if (OverlapsOtherShip(board, i))
                    {
                        ShiftShipAcross(board, i, counter);
                    }
                    board.Grid[OriginX][OriginY + i] = 1;
                }
            }

        }

        private bool NeedsReAlignment(int boardDimension)
        {
            return OriginX + Size > boardDimension || OriginY + Size > boardDimension;
        }
        private bool OverlapsOtherShip(Board board, int index)
        {
            for (int i = index; i < Size; i++)
            {
                if (board.Grid[OriginX + i][OriginY] == 1 || board.Grid[OriginX][OriginY + i] == 1)
                {
                    return true;
                }
            }
            return false;
        }
        private void ShiftShipDown (Board board, int index, int counter)
        {
            while (OverlapsOtherShip(board, index))
            {
                OriginY += 1;
                counter++;
            }
            Console.WriteLine($"Shifted {Type} over {counter} columns to avoid overlapping ships.");  
        }
        private void ShiftShipAcross(Board board, int index, int counter)
        {
            while (OverlapsOtherShip(board, index))
            {
                OriginX += 1;
                counter++;
            }
            Console.WriteLine($"Shifted {Type} over {counter} columns to avoid overlapping ships.");
        }
            
    }
}
