using System.Collections.Generic;
using Nasa.MarsRover.Command.Abstract.Core;

namespace Nasa.MarsRover.Command.Helpers
{
    public interface ICommandParser
    {
        IEnumerable<ICommand> ParseCommand(string command);
    }
}