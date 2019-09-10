using Nasa.MarsRover.Command.Enums;

namespace Nasa.MarsRover.Command.Abstract.Core
{
    public interface ICommand
    {
        CommandType GetCommandType();
        void Run();
    }
}