using System.Collections.Generic;
using Nasa.MarsRover.Domain.Plateau;
using Nasa.MarsRover.Domain.Rover;
using Nasa.MarsRover.Domain.Rover.Abstract;

namespace Nasa.MarsRover.Report.Abstract
{
    public interface IReportComposer
    {
        string Compose(Point point, Direction direction);
        string CompileReports(IEnumerable<IRover> rovers);
    }
}