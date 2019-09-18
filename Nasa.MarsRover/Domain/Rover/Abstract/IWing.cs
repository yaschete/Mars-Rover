using Nasa.MarsRover.Domain.Plateau;

namespace Nasa.MarsRover.Domain.Rover.Abstract
{
    public interface IWing
    {
        Direction Direction { get; }

        Point Move(Point location);
        IWing TurnRight();
        IWing TurnLeft();
    }
}