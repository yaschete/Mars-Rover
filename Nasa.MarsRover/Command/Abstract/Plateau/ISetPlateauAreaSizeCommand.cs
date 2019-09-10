using Nasa.MarsRover.Command.Abstract.Core;
using Nasa.MarsRover.Domain.Plateau;
using Nasa.MarsRover.Domain.Plateau.Abstract;

namespace Nasa.MarsRover.Command.Abstract.Plateau
{
    public interface ISetPlateauAreaSizeCommand : ICommand
    {
        PlateauArea PlateauArea { get; }
        void SetReceiver(IPlateau plateau);
    }
}
