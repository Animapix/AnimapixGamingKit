using Raylib_cs;

namespace AnimapixGamingKit.Tilemap
{
    public class TileSheet
    {
        public int tileSize { get; private set; }
        public int spacing { get; private set; }
        public int margin { get; private set; }
        private Texture2D texture;

        public TileSheet(string texture ,int tileSize = 16, int spacing = 0, int margin = 0)
        {
            this.tileSize = tileSize;
            this.spacing = spacing;
            this.margin = margin;
            this.texture = TexturesManager.GetTexture(texture);
        }

        public void DrawTile(int tileIndex, Vector position)
        {
            int tilesPerRow = texture.Width / tileSize;
            int row = tileIndex / tilesPerRow;
            int col = tileIndex % tilesPerRow;

            Rectangle source = new Rectangle(col * tileSize + col * spacing + margin, row * tileSize + row * spacing + margin, tileSize, tileSize);
            Raylib.DrawTextureRec(texture, source, position.Vector2, Color.White);
        }
    }
}
