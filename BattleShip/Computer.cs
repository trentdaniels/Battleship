using System;
namespace BattleShip
{
    public class Computer : Player
    {
        // Members
        private Random random;

        // Constructors
        public Computer()
        {
            Name = "Computer";
            random = new Random();
        }

        // Methods
        public override void FireAtTarget(Player targetedPlayer)
        {
            string result;
            int randomRowOnBoard;
            int randomColumnOnBoard;
            int[][] targetedBoard;

            targetedBoard = targetedPlayer.board.grid;
            randomRowOnBoard = random.Next(0, targetedPlayer.board.boardDimension);
            randomColumnOnBoard = random.Next(0, targetedPlayer.board.boardDimension);


            targetedBoard[randomRowOnBoard][randomColumnOnBoard]+= 2;
            

            result = $"{name} fired at row {randomRowOnBoard} column {randomColumnOnBoard}";
            Console.WriteLine(result);
            Console.ReadLine();

            

        }

    }
}
