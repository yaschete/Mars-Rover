using Nasa.MarsRover.Domain.Plateau;
using Nasa.MarsRover.Domain.Plateau.Abstract;
using Nasa.MarsRover.Domain.Rover.Abstract;
using Nasa.MarsRover.Exception.Rover;

namespace Nasa.MarsRover.Domain.Rover.Concrete
{
    public class SouthWing : IWing
    {
        public Direction Direction => Direction.South;


        public Point Move(Point location, IPlateau plateau)
        {
            var tempPoint = new Point(location.CoordinateX, location.CoordinateY - 1);

            if (plateau.CheckPosition(tempPoint))
            {
                throw new RoverOutOfPlateuException($"{tempPoint.CoordinateX} * {tempPoint.CoordinateY}  ==> out of plateau");
            }
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
