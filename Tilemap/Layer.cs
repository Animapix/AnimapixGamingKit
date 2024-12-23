﻿namespace AnimapixGamingKit.Tilemap
{
    class Layer
    {
        public string name { get; private set; }
        public TileSheet tileSheet { get; private set; }
        private Tile[,] tiles;

        public Layer(string name, int columns, int rows, TileSheet tileSheet)
        {
            this.name = name;
            this.tileSheet = tileSheet;

            tiles = new Tile[columns, rows];
        }

        public void Draw()
        {
            for (int column = 0; column < tiles.GetLength(0); column++)
            {
                for (int row = 0; row < tiles.GetLength(1); row++)
                {
                    if (tiles[column, row] != null)
                        tiles[column, row].Draw();
                }
            }
        }

        public void SetTile(int column, int row, int tileIndex)
        {
            if (column >= tiles.GetLength(0) || row >= tiles.GetLength(1)) return;
            tiles[column, row] = new Tile(tileIndex, column, row, tileSheet);
        }
    }
}
