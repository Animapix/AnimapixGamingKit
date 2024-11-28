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

        private static RenderTexture2D canvas = LoadRenderTexture(width, height);


        public static void Init(int screenWidth = 1280, int screenHeight = 720, string title = "MY GAME", int targetFPS = 60)
        {
            SetConfigFlags(ConfigFlags.ResizableWindow | ConfigFlags.VSyncHint);
            InitWindow(screenWidth, screenHeight, title);
            SetTargetFPS(targetFPS);
            SetTextureFilter(canvas.Texture, TextureFilter.Point);
            InitAudioDevice();
        }

        public static void Run()
        {
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
