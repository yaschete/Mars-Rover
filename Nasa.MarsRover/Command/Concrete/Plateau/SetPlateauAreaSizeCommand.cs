using Nasa.MarsRover.Command.Abstract.Plateau;
using Nasa.MarsRover.Command.Enums;
using Nasa.MarsRover.Domain.Plateau;
using Nasa.MarsRover.Domain.Plateau.Abstract;

namespace Nasa.MarsRover.Command.Concrete.Plateau
{
    public class SetPlateauAreaSizeCommand : ISetPlateauAreaSizeCommand
    {
        public PlateauArea PlateauArea { get; }
        private IPlateau _plateau;

        public SetPlateauAreaSizeCommand(PlateauArea area)
        {
            PlateauArea = area;
        }

        public CommandType GetCommandType()
        {
            return CommandType.SetPlateauAreaSizeCommand;
        }
        public void Run()
        {
            _plateau.SetAreaSize(PlateauArea);
        }
        public void SetReceiver(IPlateau plateau)
        {
            _plateau = plateau;
        }
    }
}
