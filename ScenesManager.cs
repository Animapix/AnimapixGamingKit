namespace AnimapixGamingKit
{
    public static class ScenesManager
    {
        private static Scene? currentScene;

        internal static void Process() { 
            if(currentScene != null)
                currentScene.Process();
        }

        public static void Set<T>() where T : Scene, new()
        {
            if (currentScene != null)
                currentScene.Dispose();
            currentScene = new T();
            currentScene.Initialize();
        }
    }
}
