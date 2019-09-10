using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Nasa.MarsRover.Command.Enums;
using Nasa.MarsRover.Common;
using Nasa.MarsRover.Exception.Command;

namespace Nasa.MarsRover.Command.Helpers
{
    public class CommandMatcher : ICommandMatcher
    {
        private readonly IDictionary<string, CommandType> _commandTypes;
        public CommandMatcher()
        {
            _commandTypes = new Dictionary<string, CommandType>
            {
                {ConstantValues.PlateauSizeCommandRegex ,CommandType.SetPlateauAreaSizeCommand },
                {ConstantValues.RoverCreateCommandRegex ,CommandType.RoverCreateCommand },
                {ConstantValues.RoverDriveCommandRegex,CommandType.RoverDriveCommand }
            };
        }

        public CommandType GetCommandType(string command)
        {
            try
            {
                var commandType = _commandTypes.First(
                    x => new Regex(x.Key).IsMatch(command));

                return commandType.Value;
            }
            catch (InvalidOperationException e)
            {
                var exceptionMessage = $"'{command}' is not a valid command";
                throw new InvalidCommandException(exceptionMessage, e);
            }
        }
    }
}
