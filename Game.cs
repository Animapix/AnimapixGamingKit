using AnimapixGamingKit.Scenes;
using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace AnimapixGamingKit
{
    public static class Game
    {
        public static int width { get; private set; } = 320;
        public static int height { get; private set; } = 180;
        public static float scale => MathF.Min(GetScreenWidth() / (float)width, GetScreenHeight() / (float)height);

        private static float offsetX = 1f;
        private static float offsetY = 1f;

        public static void Init(int screenWidth = 1280, int screenHeight = 720, string title = "MY GAME", int width = 320, int height = 180, int targetFPS = 60)
        {
            Game.width = width;
            Game.height = height;
            SetConfigFlags(ConfigFlags.ResizableWindow | ConfigFlags.VSyncHint);
            InitWindow(screenWidth, screenHeight, title);
            SetTargetFPS(targetFPS);
            InitAudioDevice();
        }

        public static void Run()
        {
            RenderTexture2D canvas = LoadRenderTexture(width, height);
            SetTextureFilter(canvas.Texture, TextureFilter.Point);
            while (!WindowShouldClose())
            {
                float scaledW = width * scale;
                float scaledH = height * scale;
                offsetX = (GetRenderWidth() - scaledW) * .5f;
                offsetY = (GetRenderHeight() - scaledH) * .5f;

                BeginTextureMode(canvas);
                ClearBackground(Color.Gray);

                ScenesManager.Process();

                EndTextureMode();

                BeginDrawing();
                ClearBackground(Color.Black);
                DrawTexturePro(canvas.Texture, new Rectangle(0, 0, width, -height), new Rectangle(offsetX, offsetY, scaledW, scaledH), Vector2.Zero, 0, Color.White);
                EndDrawing();
            }
            CloseWindow();
        }

    }
}
