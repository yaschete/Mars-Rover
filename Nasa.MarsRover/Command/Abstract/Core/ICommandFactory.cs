using Nasa.MarsRover.Domain.Plateau.Abstract;

namespace Nasa.MarsRover.Command.Abstract.Core
{
    public interface ICommandFactory
    {
        void Execute(string command);
        string GetCombinedRoverReport();
        IPlateau GetPlateau();
    }
}
