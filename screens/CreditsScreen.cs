using Raylib_cs;

using game;

namespace Screens
{
    public class CreditsScreen : Screen
    {
        public static Texture2D Texture;
        public static Image image;
        public CreditsScreen()
        {
            Init();
        }
        public override void Draw()
        {
            Raylib.DrawTexture(Texture, 00, 450 / 2, Color.WHITE);
            // Dispose();
        }

        public override void Init()
        {
            
        }

        public override void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_Q))
            {
                Game.SetScreenType(ScreenType.MENU_SCREEN);
            }
        }

        public void Dispose()
        {
            Raylib.UnloadTexture(Texture);
        }

        public static void LoadCreditTexture()
        {
            image = Raylib.LoadImage(Directory.GetCurrentDirectory() + "/assets/tetrix.png");
            Texture = Raylib.LoadTextureFromImage(image);
        }
    }
}