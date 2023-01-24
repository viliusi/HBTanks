

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

        public void ProceduralGenerate(int agentsCount, int seed = int.MinValue)
        {
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
