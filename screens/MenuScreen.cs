using Raylib_cs;
using System;
using game;

namespace Screens
{
    public class MenuScreen : Screen
    {

        public MenuScreen()
        {
            Game.ScreenType = ScreenType.MENU_SCREEN;
            this.MenuRectHeight = Constants.MENU_RECT_HEIGHT;
            this.MenuRectWidth = Constants.MENU_RECT_WIDTH;
            Init();
        }


        private Rectangle playRect;
        private Rectangle creditsRect;
        private Rectangle exitRect;


        private static string PlayMsg = "Play";
        private static string CreditsMsg = "Credits";
        private static string ExitMsg = "Exit";


        private int PlayMsgLen = Raylib.MeasureText(PlayMsg, 26);
        private int CreditsMsgLen = Raylib.MeasureText(CreditsMsg, 26);
        private int ExitMsgLen = Raylib.MeasureText(ExitMsg, 26);

        private int MenuRectHeight, MenuRectWidth;
        public override void Draw()
        {
            Color rectColor = Raylib.ColorAlpha(Raylib.GetColor(0xC14242), 0);
            Raylib.DrawRectangleRec(playRect, rectColor);
            Raylib.DrawRectangleRec(creditsRect, rectColor);
            Raylib.DrawRectangleRec(exitRect, rectColor);
            Color fontColor = Color.WHITE;
            Raylib.DrawText(PlayMsg, (int)(playRect.x + (playRect.width / 2 - PlayMsgLen / 2)),
                                (int)(playRect.y + (playRect.height / 2)), 30, fontColor);
            Raylib.DrawText(CreditsMsg, (int)(creditsRect.x + (creditsRect.width / 2 - CreditsMsgLen / 2)),
                                (int)(creditsRect.y + (creditsRect.height / 2)), 30, fontColor);
            Raylib.DrawText(ExitMsg, (int)(exitRect.x + (exitRect.width / 2 - ExitMsgLen / 2)),
                                (int)(exitRect.y + (exitRect.height / 2)), 30, fontColor);
        }

        public override void Init()
        {
            Game.ScreenType = ScreenType.MENU_SCREEN;
            float x = (float)Math.Floor((double)Raylib.GetScreenWidth() / 2 - MenuRectWidth / 2);
            float y = (float)Math.Floor((double)(Raylib.GetScreenHeight() / MenuRectHeight) / 3);
            playRect = new Rectangle(x, y * MenuRectHeight, MenuRectWidth, MenuRectHeight);
            creditsRect = new Rectangle(x, y * MenuRectHeight * 2, MenuRectWidth, MenuRectHeight);
            exitRect = new Rectangle(x, y * MenuRectHeight * 3, MenuRectWidth, MenuRectHeight);
        }

        public override void Update()
        {
            HandleInput();
        }

        public void HandleInput()
        {
            if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT)
                    && Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), playRect))
            {
                Console.WriteLine("[INFO]: Pressed Game");
                Game.ScreenType = ScreenType.GAME_SCREEN;
            }

            if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT)
                    && Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), creditsRect))
            {
                Console.WriteLine("[INFO]: Pressed Credits");
                Game.ScreenType = ScreenType.CREDITS_SCREEN;
            }

            if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT)
                    && Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), exitRect))
            {
                Console.WriteLine("[INFO]: Pressed Exit");
                Game.IsPlaying = false;
            }
        }
    }
}