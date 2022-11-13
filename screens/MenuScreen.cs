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
            Color rectColor = new Color(1, 0, 0, 1);
            Raylib.DrawRectangleRec(playRect, Color.WHITE);
            Raylib.DrawRectangleRec(creditsRect, Color.WHITE);
            Raylib.DrawRectangleRec(exitRect, Color.WHITE);
            Color fontColor = Color.BLACK;
            // fontColor.r = 171;
            // fontColor.g = 127;
            // fontColor.b = 5;
            // fontColor.a = 0;
            Raylib.DrawText(PlayMsg, (int)(playRect.x + (playRect.width / 2 - PlayMsgLen / 2)),
                                (int)(playRect.y + (playRect.height / 2)), 26, fontColor);
            Raylib.DrawText(CreditsMsg, (int)(creditsRect.x + (creditsRect.width / 2 - CreditsMsgLen / 2)),
                                (int)(creditsRect.y + (creditsRect.height / 2)), 26, fontColor);
            Raylib.DrawText(ExitMsg, (int)(exitRect.x + (exitRect.width / 2 - ExitMsgLen / 2)),
                                (int)(exitRect.y + (exitRect.height / 2)), 26, fontColor);
        }

        public override void Init()
        {
            Game.ScreenType = ScreenType.MENU_SCREEN;
            float x = (float)Raylib.GetScreenWidth() / 2 - MenuRectWidth / 2;
            float y = (float)(Raylib.GetScreenHeight() / MenuRectHeight) / 3;
            playRect = new Rectangle(x, y * MenuRectHeight - MenuRectHeight, MenuRectWidth, MenuRectHeight);
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
                    && Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), creditsRect))
            {
                Console.WriteLine("[INFO]: Pressed Exit");
                Game.IsPlaying = false;
            }
        }
    }
}