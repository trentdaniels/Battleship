using System;
namespace BattleShip
{
    public class Computer : Player
    {
        // Members
        private Random random;

        // Constructors
        public Computer(bool isPlayer1)
        {
            this.isPlayer1 = isPlayer1;
            name = "Computer";
            board = new Board();
            random = new Random();
        }

        // Methods
        public override void FireAtTarget(int[][] targetedBoard, Player targetedPlayer)
        {
            string result;
            int randomRowOnBoard;
            int randomColumnOnBoard;

            targetedBoard = targetedPlayer.board.grid;
            randomRowOnBoard = random.Next(0, targetedPlayer.board.boardDimension);
            randomColumnOnBoard = random.Next(0, targetedPlayer.board.boardDimension);

            if (targetedBoard[randomRowOnBoard][randomColumnOnBoard] == 0)
            {
                targetedBoard[randomRowOnBoard][randomColumnOnBoard]++;
            }

            result = $"{targetedPlayer.name} was shot at row {randomRowOnBoard} column {randomColumnOnBoard}";
            Console.WriteLine(result);

            

        }

    }
}
