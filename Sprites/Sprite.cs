using Raylib_cs;

namespace AnimapixGamingKit
{
    public class Sprite
    {
        public Vector position;

        private Texture2D texture;

        public Sprite(Vector position, string texture)
        {
            this.position = position;
            this.texture = TexturesManager.GetTexture(texture);
        }

        public void Draw()
        {
            Raylib.DrawTexture(texture, (int)position.x, (int)position.y, Color.White);
        }

        public void Update()
        {

        }
    }
}
