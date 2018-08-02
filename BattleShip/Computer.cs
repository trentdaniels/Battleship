using System;
namespace BattleShip
{
    public class Computer : Player
    {
        // Members
        private Random random;
        private bool isPlayer1;

        public bool IsPlayer1 { get => isPlayer1; set => isPlayer1 = value; }

        // Constructors
        public Computer()
        {
            random = new Random();

        }

        // Methods
        public override void FireAtTarget(Player targetedPlayer, int boardDimension)
        {
            string result;
            int randomRowOnBoard;
            int randomColumnOnBoard;
            int[][] targetedBoard;

            targetedBoard = targetedPlayer.Board.Grid;
            randomRowOnBoard = random.Next(0, boardDimension);
            randomColumnOnBoard = random.Next(0, boardDimension);


            targetedBoard[randomRowOnBoard][randomColumnOnBoard]+= 2;


            result = $"{Name} fired at row {randomRowOnBoard} column {randomColumnOnBoard}";
            Console.WriteLine(result);

            

        }


    }
}
