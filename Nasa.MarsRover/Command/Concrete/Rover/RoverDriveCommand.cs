using System.Collections.Generic;
using Nasa.MarsRover.Command.Abstract.Rover;
using Nasa.MarsRover.Command.Enums;
using Nasa.MarsRover.Domain.Rover;
using Nasa.MarsRover.Domain.Rover.Abstract;

namespace Nasa.MarsRover.Command.Concrete.Rover
{
    public class RoverDriveCommand : IRoverDriveCommand
    {
        public IList<Movement> Movements { get; }
        private IRover _rover;

        public RoverDriveCommand(IList<Movement> movements)
        {
            Movements = movements;
        }

        public CommandType GetCommandType()
        {
            return CommandType.RoverDriveCommand;
        }
        public void Run()
        {
            _rover.DriveRover(Movements);
        }
        public void SetReceiver(IRover rover)
        {
            _rover = rover;
        }
    }
}
