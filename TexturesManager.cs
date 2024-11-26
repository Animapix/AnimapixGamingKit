using Raylib_cs;

namespace AnimapixGamingKit
{
    public static class TexturesManager
    {
        private static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        public static void Load(string label, string path)
        {
            if (textures.ContainsKey(label))
                Console.WriteLine($"Texture {label} already loaded");
            else
            {
                Texture2D texture = Raylib.LoadTexture(path);
                textures.Add(label, texture);
            }
        }

        internal static Texture2D GetTexture(string label)
        {
            if (textures.ContainsKey(label))
                return textures[label];
            else
            {
                throw new Exception($"Texture {label} not found");
            }
        }
    }
}
