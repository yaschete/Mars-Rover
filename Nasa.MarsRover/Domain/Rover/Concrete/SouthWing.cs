using Nasa.MarsRover.Domain.Plateau;
using Nasa.MarsRover.Domain.Rover.Abstract;

namespace Nasa.MarsRover.Domain.Rover.Concrete
{
    public class SouthWing : IWing
    {
        public Direction Direction => Direction.South;


        public Point Move(Point location)
        {
            var tempPoint = new Point(location.CoordinateX, location.CoordinateY - 1);

            return tempPoint;
        }
        public IWing TurnRight()
        {
            return new WestWing();
        }
        public IWing TurnLeft()
        {
            return new EastWing();
        }
    }
}
