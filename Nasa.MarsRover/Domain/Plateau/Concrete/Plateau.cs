using Nasa.MarsRover.Domain.Plateau.Abstract;
using Nasa.MarsRover.Exception.Plateau;

namespace Nasa.MarsRover.Domain.Plateau.Concrete
{
    public class Plateau : IPlateau
    {
        private PlateauArea PlateauArea { get; set; }


        public void SetAreaSize(PlateauArea area)
        {
            PlateauArea = area;
        }

        public PlateauArea GetAreaSize()
        {
            return PlateauArea;
        }

        public bool CheckPosition(Point point)
        {
            var isValid = (point.CoordinateX >= 0 && point.CoordinateX <= PlateauArea.Width) &&
                          (point.CoordinateY >= 0 && point.CoordinateY <= PlateauArea.Height);

            if (isValid) return true;
            var exceptionMessage =
                $"Invalid Position ==> ({point.CoordinateX},{point.CoordinateY}). This plateau size is {PlateauArea.Width} X {PlateauArea.Height}";

            throw new InvalidPlateauPositionException(exceptionMessage);
        }
    }
}
