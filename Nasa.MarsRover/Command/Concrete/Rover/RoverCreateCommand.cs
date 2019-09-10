using Nasa.MarsRover.Command.Abstract.Rover;
using Nasa.MarsRover.Command.Enums;
using Nasa.MarsRover.Domain.Plateau;
using Nasa.MarsRover.Domain.Plateau.Abstract;
using Nasa.MarsRover.Domain.Rover;
using Nasa.MarsRover.Domain.Rover.Abstract;

namespace Nasa.MarsRover.Command.Concrete.Rover
{
    public class RoverCreateCommand : IRoverCreateCommand
    {
        public Point CreatePoint { get; set; }
        public Direction CreateDirection { get; set; }

        private IRover _rover;
        private IPlateau _plateau;

        public RoverCreateCommand(Point point, Direction direction)
        {
            CreateDirection = direction;
            CreatePoint = point;
        }

        public CommandType GetCommandType()
        {
            return CommandType.RoverCreateCommand;
        }
        public void Run()
        {
            _rover.CreateRover(_plateau, CreatePoint, CreateDirection);
        }
        public void SetReceiver(IRover rover, IPlateau plateau)
        {
            _rover = rover;
            _plateau = plateau;
        }
    }
}
