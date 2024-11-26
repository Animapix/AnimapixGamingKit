using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AnimapixGamingKit
{
    internal class Tile
    {
        private Tilemap tilemap;
        private TileSheet tileSheet;
        private int id = 0;
        private int column;
        private int row;

        internal Tile(int id, int column, int row, Tilemap tilemap, TileSheet tileSheet)
        {
            this.id = id;
            this.column = column;
            this.row = row;
            this.tilemap = tilemap;
            this.tileSheet = tileSheet;
        }

        internal void Draw()
        {
            int x = column * tilemap.tileSize;
            int y = row * tilemap.tileSize;
            tileSheet.DrawTile(id, new Vector(x, y));
        }
    }
}
