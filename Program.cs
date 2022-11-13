using Raylib_cs;
using game;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(Constants.WINDOW_WIDTH, Constants.WINDOW_HEIGHT, Constants.WINDOW_TITLE);
            game.Run();
        }
    }
}