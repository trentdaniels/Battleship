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
                case "1":
                    GetShipStartingPosition();
                    for (int i = 0; i < Size; i++) 
                    {
                        if(OriginX > player.Board.BoardDimension)
                        {
                            ReAlignShip(player.Board);
                            break;
                        }

                        player.Board.Grid[OriginX + i][OriginY] = 1;

                    }
                    break;
                case "vertical":
                    GetShipStartingPosition();
                    for (int i = 0; i < Size; i++) {
                        player.Board.Grid[OriginX][OriginY + i] = 1;
                    }
                    ReAlignShip(player.Board);
                    break;
                default:
                    Console.WriteLine("Invalid Input. Please choose 'horizontal' or 'vertical'");
                    CreateShip(player);
                    break;
            }
        }

    }

   
}
