using System.Collections.Generic;
using Nasa.MarsRover.Command.Abstract.Core;
using Nasa.MarsRover.Domain.Plateau.Abstract;
using Nasa.MarsRover.Domain.Rover.Abstract;

namespace Nasa.MarsRover.Command.Helpers
{
    public interface ICommandInvoker
    {
        void SetPlateau(IPlateau plateau);
        void SetRovers(IList<IRover> rovers);
        void SetCommands(IEnumerable<ICommand> commands);
        void InvokeAll();
    }
}