

using Assets;
using System;
using System.Collections.Generic;

struct Agent
{
    int x, y;

    public Agent(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void Move(int xMove, int yMove)
    {
        x += xMove;
        y += yMove;
    }
}

namespace Assets
{
    public class Map
    {
        public Tank[] Tanks;
        public Tile[,] Tiles;
        public int Width;
        public int Height;

        public Map(int tankCount)
        {
            if (tankCount < 2)
                throw new ArgumentException("Can NOT have less that 2 tanks on the field");
            Tanks = new Tank[tankCount];
        }

        public void ProceduralGenerate(int width, int height, int agentsCount, int seed = int.MinValue)
        {
            if (width < 0 || height < 0)
                throw new ArgumentOutOfRangeException("Neither width nor height can be less than zero");
            Width = width;
            Height = height;
            Tiles = new Tile[Width, Height];

            Random rand;
            if (seed == int.MinValue)
                rand = new Random();
            else
                rand = new Random(seed);

            int tilesCount = Height * Width - 1;
            int tilesGoneOver = 0;
            Agent[] agents = new Agent[tilesCount];

            for (int i = 0; i < agentsCount; i++)
                agents[i] = new Agent(rand.Next(0, Width), rand.Next(0, Height));

            while (tilesGoneOver < tilesCount)
            {
                throw new NotImplementedException();
            }
        }
    }
}
