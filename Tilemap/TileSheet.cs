using Raylib_cs;

namespace AnimapixGamingKit.Tilemap
{
    public class TileSheet
    {
        public int tileSize { get; private set; }
        public int spacing { get; private set; }
        public int padding { get; private set; }
        public int UID { get; private set; }
        private Texture2D texture;

        public TileSheet(string texture , int tileSize = 16, int spacing = 0, int margin = 0, int UID = 0)
        {
            this.tileSize = tileSize;
            this.spacing = spacing;
            this.padding = margin;
            this.texture = TexturesManager.GetTexture(texture);
            this.UID = UID;
         }

        public void DrawTile(int tileIndex, Vector position)
        {
            int tilesPerRow = texture.Width / tileSize;
            int row = tileIndex / tilesPerRow;
            int col = tileIndex % tilesPerRow;

            Rectangle source = new Rectangle(col * tileSize + col * spacing + padding, row * tileSize + row * spacing + padding, tileSize, tileSize);
            Raylib.DrawTextureRec(texture, source, position.Vector2, Color.White);
        }
    }
}
