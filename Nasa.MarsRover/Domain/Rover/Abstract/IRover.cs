using Nasa.MarsRover.Domain.Plateau;
using System.Collections.Generic;
using Nasa.MarsRover.Domain.Plateau.Abstract;

namespace Nasa.MarsRover.Domain.Rover.Abstract
{
    public interface IRover
    {
        Point Position { get; set; }
        Direction Direction { get; set; }

        void DriveRover(IPlateau plateau, IEnumerable<Movement> movements);
        void CreateRover(IPlateau plateau, Point point, Direction direction);
        bool CheckCreateStatus();
    }
}