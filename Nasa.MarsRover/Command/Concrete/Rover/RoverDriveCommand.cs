using System.Collections.Generic;
using Nasa.MarsRover.Command.Abstract.Rover;
using Nasa.MarsRover.Command.Enums;
using Nasa.MarsRover.Domain.Plateau;
using Nasa.MarsRover.Domain.Plateau.Abstract;
using Nasa.MarsRover.Domain.Rover;
using Nasa.MarsRover.Domain.Rover.Abstract;

namespace Nasa.MarsRover.Command.Concrete.Rover
{
    public class RoverDriveCommand : IRoverDriveCommand
    {
        public IList<Movement> Movements { get; }
        private IRover _rover;
        private IPlateau _plateau;
        private IList<Point> _otherRoverPoints;

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
            _rover.DriveRover(_plateau, Movements,_otherRoverPoints);
        }
        public void SetReceiver(IRover rover, IPlateau plateau, IList<Point> otherRoverPoints)
        {
            _rover = rover;
            _plateau = plateau;
            _otherRoverPoints = otherRoverPoints;
        }
    }
}
