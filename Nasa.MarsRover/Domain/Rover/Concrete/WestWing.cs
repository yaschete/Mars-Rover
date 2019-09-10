using Nasa.MarsRover.Domain.Plateau;
using Nasa.MarsRover.Domain.Rover.Abstract;

namespace Nasa.MarsRover.Domain.Rover.Concrete
{
    public class WestWing : IWing
    {
        public Direction Direction => Direction.West;

        public Point Move(Point location)
        {
            return new Point(location.CoordinateX - 1, location.CoordinateY);
        }
        public IWing TurnRight()
        {
            return new NorthWing();
        }
        public IWing TurnLeft()
        {
            return new SouthWing();
        }
    }
}
