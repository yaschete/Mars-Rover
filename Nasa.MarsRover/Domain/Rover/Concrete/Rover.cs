using System;
using System.Collections.Generic;
using System.Linq;
using Nasa.MarsRover.Domain.Plateau;
using Nasa.MarsRover.Domain.Plateau.Abstract;
using Nasa.MarsRover.Domain.Rover.Abstract;

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

        public Rover()
        {
            _movementMethodDictionary = new Dictionary<Movement, Action>
            {
                {Movement.Forward,()=> Position =_wing.Move(Position,_plateau) },
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
        public void DriveRover(IPlateau plateau, IEnumerable<Movement> movements)
        {
            _plateau = plateau;
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