namespace AnimapixGamingKit.Tilemap
{
    internal class Tile
    {
        private Tilemap tilemap;
        private TileSheet tileSheet;
        private bool walkable = true;
        private int textureID = 0;
        private int column;
        private int row;

        public int TextureID => textureID;
        public bool Walkable => walkable;

        internal Tile(int textureID, int column, int row, Tilemap tilemap, TileSheet tileSheet, bool walkable = true)
        {
            this.textureID = textureID;
            this.column = column;
            this.row = row;
            this.tilemap = tilemap;
            this.tileSheet = tileSheet;
            this.walkable = walkable;
        }

        internal void Draw()
        {
            int x = column * tilemap.tileSize;
            int y = row * tilemap.tileSize;
            tileSheet.DrawTile(textureID, new Vector(x, y));
        }
    }
}
