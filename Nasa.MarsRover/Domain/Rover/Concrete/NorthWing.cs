using Nasa.MarsRover.Domain.Plateau;
using Nasa.MarsRover.Domain.Rover.Abstract;

namespace Nasa.MarsRover.Domain.Rover.Concrete
{
    public class NorthWing : IWing
    {
        public Direction Direction => Direction.North;


        public Point Move(Point location)
        {
            return new Point(location.CoordinateX, location.CoordinateY + 1);
        }
        public IWing TurnRight()
        {
            return new EastWing();
        }
        public IWing TurnLeft()
        {
            return new WestWing();
        }
    }
}
