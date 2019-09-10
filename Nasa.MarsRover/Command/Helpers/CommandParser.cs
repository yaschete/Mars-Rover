using System;
using System.Collections.Generic;
using System.Linq;
using Nasa.MarsRover.Command.Abstract.Core;
using Nasa.MarsRover.Command.Abstract.Plateau;
using Nasa.MarsRover.Command.Abstract.Rover;
using Nasa.MarsRover.Command.Enums;
using Nasa.MarsRover.Common;
using Nasa.MarsRover.Domain.Plateau;
using Nasa.MarsRover.Domain.Rover;

namespace Nasa.MarsRover.Command.Helpers
{
    public class CommandParser : ICommandParser
    {

        private readonly Func<PlateauArea, ISetPlateauAreaSizeCommand> _plateauSizeCommandFactory;
        private readonly Func<Point, Direction, IRoverCreateCommand> _roverCreateCommandFactory;
        private readonly Func<IList<Movement>, IRoverDriveCommand> _roverDriveCommandFactory;

        private readonly ICommandMatcher _commandMatcher;
        private readonly IDictionary<CommandType, Func<string, ICommand>> _commandParserDictionary;
        private readonly IDictionary<char, Direction> _directionDictionary;
        private readonly IDictionary<char, Movement> _movementDictionary;


        public CommandParser(ICommandMatcher commandMatcher,
            Func<PlateauArea, ISetPlateauAreaSizeCommand> plateauSizeCommandFactory,
            Func<Point, Direction, IRoverCreateCommand> roverCreateCommandFactory,
            Func<IList<Movement>, IRoverDriveCommand> roverDriveCommandFactory)
        {
            _commandMatcher = commandMatcher;
            _plateauSizeCommandFactory = plateauSizeCommandFactory;
            _roverCreateCommandFactory = roverCreateCommandFactory;
            _roverDriveCommandFactory = roverDriveCommandFactory;

            _commandParserDictionary = new Dictionary<CommandType, Func<string, ICommand>>
            {
                {CommandType.SetPlateauAreaSizeCommand, ParsePlateauSizeCommand},
                {CommandType.RoverCreateCommand, ParseRoverCreateCommand},
                {CommandType.RoverDriveCommand, ParseRoverDriveCommand}
            };

            _directionDictionary = ConstantValues.GetDirectoryDictionary();
            _movementDictionary = ConstantValues.GetMovementDictionary();
        }


        public IEnumerable<ICommand> ParseCommand(string command)
        {
            var commands = command.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return commands
                .Select(x => _commandParserDictionary[_commandMatcher.GetCommandType(x)].Invoke(x))
                .ToList();
        }

        #region Private Methods
        private ICommand ParsePlateauSizeCommand(string toParse)
        {
            var arguments = toParse.Split(' ');
            var width = int.Parse(arguments[0]);
            var height = int.Parse(arguments[1]);
            var size = new PlateauArea(width, height);

            var populatedCommand = _plateauSizeCommandFactory(size);
            return populatedCommand;
        }
        private ICommand ParseRoverCreateCommand(string toParse)
        {
            var arguments = toParse.Split(' ');

            var x = int.Parse(arguments[0]);
            var y = int.Parse(arguments[1]);

            var directionSignifier = arguments[2][0];
            var deployDirection = _directionDictionary[directionSignifier];

            var createPoint = new Point(x, y);

            var populatedCommand = _roverCreateCommandFactory(createPoint, deployDirection);
            return populatedCommand;
        }
        private ICommand ParseRoverDriveCommand(string toParse)
        {
            var arguments = toParse.ToCharArray();
            var movements = arguments.Select(argument => _movementDictionary[argument]).ToList();
            var populatedCommand = _roverDriveCommandFactory(movements);
            return populatedCommand;
        }
        #endregion
    }
}
