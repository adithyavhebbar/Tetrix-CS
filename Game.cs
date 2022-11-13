using Raylib_cs;
using Screens;

namespace game
{
    public class Game
    {
        public int WindowWidth, WindowHeight;
        string Title;
        public static bool IsPlaying = true;
        public static ScreenType ScreenType;
        public static Screen CurrentScreen;
        public static Font SuperGameFont;
        public Game(int windowWidth, int windowHeight, string title)
        {
            this.WindowHeight = windowHeight;
            this.WindowWidth = windowWidth;
            this.Title = title;
            CurrentScreen = new MenuScreen();
        }

        public void init()
        {
            Raylib.InitWindow(this.WindowWidth, this.WindowHeight, this.Title);
        }

        public void Run()
        {
            init();
            while (!Raylib.WindowShouldClose() && IsPlaying)
            {
                Raylib.BeginDrawing();
                Update();
                Draw();
                Raylib.EndDrawing();
            }
            DeInit();
        }

        private void Update()
        {
            switch (ScreenType)
            {
                case ScreenType.MENU_SCREEN:
                    ScreenType = ScreenType.MENU_SCREEN;
                    CurrentScreen = new MenuScreen();
                    CurrentScreen.Init();
                    break;
                case ScreenType.GAME_SCREEN:
                    ScreenType = ScreenType.GAME_SCREEN;
                    CurrentScreen = new GameScreen();
                    CurrentScreen.Init();
                    break;
                default:
                    break;
            }
            CurrentScreen.Update();
        }

        private void Draw()
        {
            Raylib.ClearBackground(Color.BLUE);
            CurrentScreen.Draw();
        }

        public void DeInit()
        {
            Raylib.CloseWindow();
        }
    }
}