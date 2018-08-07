using System;
namespace BattleShip
{
    public class Coordinate
    {
        private int coordinateX;
        private int coordinateY;

        public int CoordinateX { get => coordinateX; set => coordinateX = value; }
        public int CoordinateY { get => coordinateY; set => coordinateY = value; }


        public Coordinate(int coordinateX, int coordinateY)
        {
            this.coordinateX = coordinateX;
            this.coordinateY = coordinateY;
        }
    }
}
