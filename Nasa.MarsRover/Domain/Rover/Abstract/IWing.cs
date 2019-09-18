using Nasa.MarsRover.Domain.Plateau;
using Nasa.MarsRover.Domain.Plateau.Abstract;

namespace Nasa.MarsRover.Domain.Rover.Abstract
{
    public interface IWing
    {
        Direction Direction { get; }

        Point Move(Point location, IPlateau plateau);
        IWing TurnRight();
        IWing TurnLeft();
    }
}