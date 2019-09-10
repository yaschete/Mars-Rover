namespace Nasa.MarsRover.Domain.Plateau.Abstract
{
    public interface IPlateau
    {
        void SetAreaSize(PlateauArea area);
        PlateauArea GetAreaSize();
        bool CheckPosition(Point point);
    }
}