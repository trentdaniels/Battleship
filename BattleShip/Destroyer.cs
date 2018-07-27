using System;
namespace BattleShip
{
    public class Destroyer : Ship
    {
        // Member Variables

        // Constructor
        public Destroyer()
        {
            size = 2;
            type = "Destroyer";
        }

        // Methods
        public override void CreateShip(Player player)
        {
            Console.WriteLine($"Would you like the {type} to be 'horizontal' or 'vertical'?");
            orientation = Console.ReadLine();

            switch (orientation) {
                case "horizontal":
                    GetShipStartingPosition();
                    for (int i = 0; i < size; i++) 
                    {
                        player.board.grid[player.ship.originX + i][player.ship.originY] = 1;

                    }
                    ReAlignShip(player.board);
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
