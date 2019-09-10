using Nasa.MarsRover.Command.Abstract.Core;
using Nasa.MarsRover.Domain.Plateau;
using Nasa.MarsRover.Domain.Plateau.Abstract;
using Nasa.MarsRover.Domain.Rover;
using Nasa.MarsRover.Domain.Rover.Abstract;

namespace Nasa.MarsRover.Command.Abstract.Rover
{
    public interface IRoverCreateCommand : ICommand
    {
        Point CreatePoint { get; set; }
        Direction CreateDirection { get; set; }
        void SetReceiver(IRover rover, IPlateau plateau);
    }
}