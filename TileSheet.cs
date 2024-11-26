using Raylib_cs;

namespace AnimapixGamingKit
{
    internal class TileSheet
    {
        internal int tileSize { get; private set; }
        internal int spacing { get; private set; }
        internal int margin { get; private set; }
        private Texture2D texture;

        internal TileSheet(int tileSize, int spacing, int margin, string texture)
        {
            this.tileSize = tileSize;
            this.spacing = spacing;
            this.margin = margin;
            this.texture = TexturesManager.GetTexture(texture);
        }

        internal void DrawTile(int tileIndex, Vector position)
        {
            int tilesPerRow = texture.Width / tileSize;
            int row = tileIndex / tilesPerRow;
            int col = tileIndex % tilesPerRow;
            
            Rectangle source = new Rectangle(col * tileSize + col * spacing + margin, row * tileSize + row * spacing + margin, tileSize, tileSize);
            Raylib.DrawTextureRec(texture, source, position.Vector2, Color.White);
        }
    }
}
