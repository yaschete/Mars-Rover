namespace Nasa.MarsRover.Domain.Plateau
{
    public struct PlateauArea
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public PlateauArea(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
