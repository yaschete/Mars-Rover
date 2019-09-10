using System.Collections.Generic;
using System.Text;
using Nasa.MarsRover.Common;
using Nasa.MarsRover.Domain.Plateau;
using Nasa.MarsRover.Domain.Rover;
using Nasa.MarsRover.Domain.Rover.Abstract;
using Nasa.MarsRover.Exception.Rover;
using Nasa.MarsRover.Report.Abstract;

namespace Nasa.MarsRover.Report.Concrete
{
    public class ReportComposer : IReportComposer
    {
        private readonly IDictionary<Direction, char> _directionDictionary;

        public ReportComposer()
        {
            _directionDictionary = ConstantValues.GetDirectoryDictionaryReverse();
        }

        public string Compose(Point point, Direction direction)
        {
            return $"{point.CoordinateX} {point.CoordinateY} {_directionDictionary[direction]}";
        }
        public string CompileReports(IEnumerable<IRover> rovers)
        {
            var reports = ComposeEachReport(rovers);
            return ConvertToString(reports);
        }

        #region Private Methods
        private StringBuilder ComposeEachReport(IEnumerable<IRover> rovers)
        {
            var reports = new StringBuilder();
            foreach (var rover in rovers)
            {
                EnsureRoverIsCreated(rover);
                var report = Compose(rover.Position, rover.Direction);
                reports.AppendLine(report);
            }
            return reports;
        }
        private static string ConvertToString(StringBuilder reports)
        {
            return reports
                .ToString()
                .TrimEnd('\n', '\r');
        }
        private static void EnsureRoverIsCreated(IRover rover)
        {
            if (!rover.CheckCreateStatus())
            {
                throw new RoverNotCreatedException("Cannot create report because one or more rovers are not created");
            }
        }
        #endregion
    }
}
