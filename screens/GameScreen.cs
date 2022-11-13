using Raylib_cs;

using game;

namespace Screens
{
    public class GameScreen : Screen
    {
        public GameScreen()
        {
            Game.ScreenType = ScreenType.GAME_SCREEN;
        }
        public override void Draw()
        {
        }

        public override void Init()
        {
            Game.ScreenType = ScreenType.GAME_SCREEN;
        }

        public override void Update()
        {
            Game.ScreenType = ScreenType.GAME_SCREEN;
        }
    }
}