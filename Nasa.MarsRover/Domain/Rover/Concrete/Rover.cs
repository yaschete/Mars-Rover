using System;
using System.Collections.Generic;
using System.Linq;
using Nasa.MarsRover.Domain.Plateau;
using Nasa.MarsRover.Domain.Plateau.Abstract;
using Nasa.MarsRover.Domain.Rover.Abstract;
using Nasa.MarsRover.Exception.Rover;

namespace Nasa.MarsRover.Domain.Rover.Concrete
{
    public class Rover : IRover
    {

        private bool _isCreate;
        private readonly IDictionary<Movement, Action> _movementMethodDictionary;
        private readonly List<IWing> _wingList;
        private IWing _wing;
        //
        public Point Position { get; set; }
        public Direction Direction { get; set; }
        private IPlateau _plateau;
        private IList<Point> _otherRoverPoints;

        public Rover()
        {
            _movementMethodDictionary = new Dictionary<Movement, Action>
            {
                {Movement.Forward,()=> SetPosition(_wing.Move(Position)) },
                {Movement.Left,()=> _wing = _wing.TurnLeft() },
                {Movement.Right,()=> _wing = _wing.TurnRight() }
            };

            _wingList = new List<IWing>()
                {
                    new NorthWing(),
                    new EastWing(),
                    new WestWing(),
                    new SouthWing()
                };

        }

        public void SetPosition(Point newPoint)
        {
            var plateauSize = _plateau.GetAreaSize();

            // check for out of plateau exception
            if (newPoint.CoordinateX < 0 || plateauSize.Width < newPoint.CoordinateX || newPoint.CoordinateY < 0 || plateauSize.Height < newPoint.CoordinateY)
            {
                throw new RoverOutOfPlateuException($" out of plateau ==>X: {newPoint.CoordinateX} - Y: {newPoint.CoordinateY} ");
            }

            // check for rover crash exception
            if (_otherRoverPoints.Any(x => x.CoordinateX == newPoint.CoordinateX && x.CoordinateY == newPoint.CoordinateY))
            {
                throw new RoverCrashException($"rover crash ==> X: {newPoint.CoordinateX} - Y: {newPoint.CoordinateY}");
            }

            Position = newPoint;
        }
        public void DriveRover(IPlateau plateau, IEnumerable<Movement> movements, IList<Point> otherRoverPoints)
        {
            _plateau = plateau;
            _otherRoverPoints = otherRoverPoints;
            foreach (var movement in movements)
            {
                _movementMethodDictionary[movement].Invoke();
            }
        }
        public void CreateRover(IPlateau plateau, Point point, Direction direction)
        {
            plateau.CheckPosition(point);

            Position = point;
            Direction = direction;
            _wing = _wingList.FirstOrDefault(x => x.Direction == direction);
            _isCreate = true;
        }
        public bool CheckCreateStatus()
        {
            return _isCreate;
        }
    }
}