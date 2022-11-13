using Raylib_cs;
using static Raylib_cs.Raylib;

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
            InitAudioDevice();
        }

        public void Run()
        {
            init();
            CreditsScreen.LoadCreditTexture();
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
                    break;
                case ScreenType.GAME_SCREEN:
                    ScreenType = ScreenType.GAME_SCREEN;
                    CurrentScreen = new GameScreen();
                    break;
                case ScreenType.CREDITS_SCREEN:
                    ScreenType = ScreenType.CREDITS_SCREEN;
                    CurrentScreen = new CreditsScreen();
                    break;
                default:
                    break;
            }
            CurrentScreen.Update();
        }

        private void Draw()
        {
            Raylib.ClearBackground(Color.BLACK);
            CurrentScreen.Draw();
        }

        public void DeInit()
        {
            UnloadImage(CreditsScreen.image);
            Raylib.UnloadTexture(CreditsScreen.Texture);
            CloseAudioDevice();
            Raylib.CloseWindow();
        }

        public static void SetScreenType(ScreenType screenType) 
        {
            Game.ScreenType = screenType;
        }
    }
}