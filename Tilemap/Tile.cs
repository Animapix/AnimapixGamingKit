namespace AnimapixGamingKit.Tilemap
{
    public class Tile
    {
        private TileSheet tileSheet;
        private bool walkable = true;
        private int textureID = 0;
        private int column;
        private int row;

        public int TextureID => textureID;
        public bool Walkable => walkable;

        public Tile(int textureID, int column, int row, TileSheet tileSheet, bool walkable = true)
        {
            this.textureID = textureID;
            this.column = column;
            this.row = row;
            this.tileSheet = tileSheet;
            this.walkable = walkable;
        }

        public void Draw()
        {
            int x = column * tileSheet.tileSize;
            int y = row * tileSheet.tileSize;

            tileSheet.DrawTile(textureID, new Vector(x, y));
        }
    }
}
