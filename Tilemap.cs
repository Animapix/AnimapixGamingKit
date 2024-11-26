namespace AnimapixGamingKit
{
    public class Tilemap
    {
        public int tileSize { get; private set; }
        private Tile[,] tiles;
        private TileSheet tileSheet;

        public Tilemap(int columns, int rows, int tileSize, string texture)
        {
            this.tileSize = tileSize;
            this.tileSheet = new TileSheet(tileSize, 0, 0, texture);
            tiles = new Tile[columns, rows];
        }

        public void Draw()
        {
            for (int column = 0; column < tiles.GetLength(0); column++)
            {
                for (int row = 0; row < tiles.GetLength(1); row++)
                {
                    if (tiles[column,row] != null)
                        tiles[column, row].Draw();
                    

                }
            }
        }

        public void SetTile(int column, int row, int tileIndex)
        {
            tiles[column, row] = new Tile(tileIndex, column, row, this, tileSheet);
        }
    }
}
