using Nasa.MarsRover.Command.Enums;

namespace Nasa.MarsRover.Command.Helpers
{
    public interface ICommandMatcher
    {
        CommandType GetCommandType(string command);
    }
}