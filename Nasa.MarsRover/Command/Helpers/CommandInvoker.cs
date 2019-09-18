using System;
using System.Collections.Generic;
using System.Linq;
using Nasa.MarsRover.Command.Abstract.Core;
using Nasa.MarsRover.Command.Abstract.Plateau;
using Nasa.MarsRover.Command.Abstract.Rover;
using Nasa.MarsRover.Command.Enums;
using Nasa.MarsRover.Domain.Plateau.Abstract;
using Nasa.MarsRover.Domain.Rover.Abstract;
using Nasa.MarsRover.Exception.Rover;

namespace Nasa.MarsRover.Command.Helpers
{
    public class CommandInvoker : ICommandInvoker
    {
        private readonly Func<IRover> _roverFactory;
        private readonly IDictionary<CommandType, Action<ICommand>> _receiversMethodDictionary;

        private IPlateau _plateau;
        private IList<IRover> _rovers;
        private IEnumerable<ICommand> _commands;


        public CommandInvoker(Func<IRover> roverFactory)
        {
            _roverFactory = roverFactory;
            _receiversMethodDictionary = new Dictionary<CommandType, Action<ICommand>>
            {
                {CommandType.SetPlateauAreaSizeCommand,SetReceiversOnPlateauSizeCommand },
                {CommandType.RoverCreateCommand,SetReceiversOnRoverCreateCommand },
                {CommandType.RoverDriveCommand,SetReceiversOnRoverDriveCommand }
            };
        }


        public void SetRovers(IList<IRover> rovers)
        {
            _rovers = rovers;
        }

        public void SetPlateau(IPlateau plateau)
        {
            _plateau = plateau;
        }


        public void SetCommands(IEnumerable<ICommand> commands)
        {
            _commands = commands;
        }
        public void InvokeAll()
        {
            foreach (var command in _commands)
            {
                SetReceivers(command);
                command.Run();
            }
        }


        #region Private Methods
        private void SetReceivers(ICommand command)
        {
            _receiversMethodDictionary[command.GetCommandType()]
                .Invoke(command);
        }
        private void SetReceiversOnPlateauSizeCommand(ICommand command)
        {
            var plateauSizeCommand = (ISetPlateauAreaSizeCommand)command;
            plateauSizeCommand.SetReceiver(_plateau);
        }
        private void SetReceiversOnRoverCreateCommand(ICommand command)
        {
            var roverDeployCommand = (IRoverCreateCommand)command;
            var newRover = _roverFactory();
            _rovers.Add(newRover);
            roverDeployCommand.SetReceiver(newRover, _plateau);
        }
        private void SetReceiversOnRoverDriveCommand(ICommand command)
        {
            var roverExploreCommand = (IRoverDriveCommand)command;
            var latestRover = _rovers[_rovers.Count - 1];
            roverExploreCommand.SetReceiver(latestRover, _plateau);
        }
        #endregion
    }
}
