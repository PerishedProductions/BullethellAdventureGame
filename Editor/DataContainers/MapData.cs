using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.DataContainers
{
    public class MapData
    {
        public int rows;
        public int columns;
        public int tileSize;
        public string[] tiles;

        public MapData(int rows, int columns, int tileSize, string[] tiles)
        {
            this.rows = rows;
            this.columns = columns;
            this.tileSize = tileSize;
            this.tiles = tiles;
        }
    }
}
