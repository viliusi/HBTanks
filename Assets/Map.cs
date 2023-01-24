

using System;
using System.Collections.Generic;

namespace Assets
{
    public class Map
    {
        public Tank[] Tanks;
        public Tile[,] Tiles;
        public int Width;
        public int Height;

        public Map(int tankCount, int width, int height)
        {
            if (tankCount < 2)
                throw new ArgumentException("Can NOT have less that 2 tanks on the field");
            if (width < 0 || height < 0)
                throw new ArgumentOutOfRangeException("Neither width nor height can be less than zero");
            Width = width;
            Height = height;
            Tanks = new Tank[tankCount];
            Tiles = new Tile[Width, Height];
        }
    }
}
