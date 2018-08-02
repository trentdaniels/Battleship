using System;
namespace BattleShip
{
    public class Destroyer : Ship
    {
        // Member Variables

        // Constructor
        public Destroyer()
        {
            Size = 2;
            Type = "Destroyer";
        }

        // Methods
        public override void CreateShip(Player player)
        {
            Console.WriteLine($"Would you like the {Type} to be [1]Horizontal or [2]Vertical  ?");
            Orientation = Console.ReadLine();

            switch (Orientation) {
                case "horizontal":
                    GetShipStartingPosition();
                    for (int i = 0; i < size; i++) 
                    {
                        if(originX > player.board.boardDimension)
                        {
                            ReAlignShip(player.board);
                            break;
                        }

                        player.board.grid[originX + i][originY] = 1;

                    }
                    break;
                case "vertical":
                    GetShipStartingPosition();
                    for (int i = 0; i < size; i++) {
                        player.board.grid[originX][originY + i] = 1;
                    }
                    ReAlignShip(player.board);
                    break;
                default:
                    Console.WriteLine("Invalid Input. Please choose 'horizontal' or 'vertical'");
                    CreateShip(player);
                    break;
            }
        }

    }

   
}
