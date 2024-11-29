namespace AnimapixGamingKit.Tilemap
{
    public class Tilemap
    {
        private List<Layer> layers = new List<Layer>();
        public int columns { get; private set; }
        public int rows { get; private set; }


        public Tilemap(int columns, int rows)
        {
            this.columns = columns;
            this.rows = rows;
        }

        public void AddLayer(string name, TileSheet tileSheet)
        {
            layers.Add(new Layer(name, columns, rows, tileSheet));
        }

        public void Draw()
        {
            foreach (Layer layer in layers)
            {
                layer.Draw();
            }
        }

        public void SetTile(int column, int row, int tileIndex, string layer)
        {
            var l = layers.Find(l => l.name == layer);
            if (l != null)
            {
                l.SetTile(column, row, tileIndex);
            }
        }
    }
}