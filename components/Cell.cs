using Raylib_cs;

namespace components
{
    public class Cell
    {
        private float X, Y;
        private int CellSize;
        private Color c;

        public Cell(float X, float Y, int CellSize, Color c)
        {
            this.X = X;
            this.Y = Y;
            this.CellSize = CellSize;
            this.c = c;
        }
    }
}