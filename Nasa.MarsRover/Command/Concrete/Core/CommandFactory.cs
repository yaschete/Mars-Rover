using System.Collections.Generic;
using Nasa.MarsRover.Command.Abstract.Core;
using Nasa.MarsRover.Command.Helpers;
using Nasa.MarsRover.Domain.Plateau.Abstract;
using Nasa.MarsRover.Domain.Rover.Abstract;
using Nasa.MarsRover.Report.Abstract;

namespace Nasa.MarsRover.Command.Concrete.Core
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IPlateau _plateau;
        private readonly ICommandParser _commandParser;
        private readonly ICommandInvoker _commandInvoker;
        private readonly IReportComposer _reportComposer;
        private readonly IList<IRover> _rovers;

        public CommandFactory(IPlateau plateau, ICommandParser commandParser, ICommandInvoker commandInvoker, IReportComposer reportComposer)
        {
            _rovers = new List<IRover>();
            _plateau = plateau;
            _commandParser = commandParser;
            _commandInvoker = commandInvoker;
            _reportComposer = reportComposer;

            _commandInvoker.SetPlateau(_plateau);
            _commandInvoker.SetRovers(_rovers);
        }

        public void Execute(string command)
        {
            var commands = _commandParser.ParseCommand(command);
            _commandInvoker.SetCommands(commands);
            _commandInvoker.InvokeAll();
        }

        public string GetCombinedRoverReport()
        {
            return _reportComposer.CompileReports(_rovers);
        }

        public IPlateau GetPlateau()
        {
            return _plateau;
        }
    }
}
