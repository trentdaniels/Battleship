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
            name = "Destroyer";
        }

        // Methods
        public override void CreateShip(Player player)
        {
            Console.WriteLine($"Would you like the {name} to be 'horizontal' or 'vertical'?");
            orientation = Console.ReadLine();

            switch (orientation) {
                case "horizontal":
                    break;
                case "vertical":
                    break;
                default:
                    Console.WriteLine("Invalid Input. Please choose 'horizontal' or 'vertical'");
                    CreateShip(player);
                    break;
            }
        }
    }

   
}
