using System.Collections.Generic;
using Nasa.MarsRover.Command.Abstract.Core;
using Nasa.MarsRover.Domain.Plateau.Abstract;
using Nasa.MarsRover.Domain.Rover;
using Nasa.MarsRover.Domain.Rover.Abstract;

namespace Nasa.MarsRover.Command.Abstract.Rover
{
    public interface IRoverDriveCommand : ICommand
    {
        IList<Movement> Movements { get; }
        void SetReceiver(IRover rover, IPlateau plateau);
    }
}