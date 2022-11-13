using Raylib_cs;

using Screens;

namespace Components
{
    public class Board : Screen
    {
        private float X, Y;
        private int NumRows, NumCols;

        private Color c;

        public Board(float x, float y, int NumRows, int NumCols, Color c)
        {
            this.X = x;
            this.Y = y;
            this.NumRows = NumRows;
            this.NumCols = NumCols;
            this.c = c;
        }

        public override void Draw()
        {
        }

        public override void Init()
        {
        }

        public override void Update()
        {
        }
    }
}