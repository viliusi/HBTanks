

using Assets;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

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
    public struct Line
    {
        public float x1;
        public float y1;
        public float x2;
        public float y2;

        public Line(float x1, float y1, float x2, float y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }
    }

    public class Map
    {
        public Tank[] Tanks;
        public Tile[,] Tiles;
        public int Width;
        public int Height;

        ///// <summary>
        ///// All lines is based in the top left cornor and goes down or towards the right
        ///// </summary>
        public List<Line> Lines = new List<Line>();

        public Map(int tankCount)
        {
            if (tankCount < 2)
                throw new ArgumentException("Can NOT have less that 2 tanks on the field");
            Tanks = new Tank[tankCount];
        }

        public void ProceduralGenerate(int width, int height, int agentsCount = -1, int seed = int.MinValue)
        {
            if (width < 0 || height < 0)
                throw new ArgumentOutOfRangeException("Neither width nor height can be less than zero");
            Width = width;
            Height = height;
            Tiles = new Tile[Width, Height];
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                    Tiles[i, j] = new Tile();

            if (agentsCount == -1)
                agentsCount = Math.Min(1, Width * Height / 20);

            System.Random rand = new System.Random();
            if (seed != int.MinValue)
                rand = new System.Random(seed);

            int tilesCount = Height * Width - 1;
            int tilesGoneOver = 0;
            Agent[] agents = new Agent[tilesCount];

            for (int i = 0; i < agentsCount; i++)
                agents[i] = new Agent(rand.Next(0, Width), rand.Next(0, Height));

            while (tilesGoneOver < tilesCount)
            {
                // Set all the Agents random places
                // Make them go all difrent 
                // When they hit a allready initilized square, make the wall open so all the agents is connected

                // TESTING

                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        for (int k = 0; k < 4; k++)
                            Tiles[i, j][(Tile.Direction)k] = true;
                        if (i == 0)
                            Tiles[i, j][Tile.Direction.North] = false;
                        if (i == Width - 1)
                            Tiles[i, j][Tile.Direction.South] = false;
                        if (j == 0)
                            Tiles[i, j][Tile.Direction.West] = false;
                        if (j == Width - 1)
                            Tiles[i, j][Tile.Direction.East] = false;
                    }
                }
                break;
            }

            _GenerateLines();
        }

        private void _GenerateLines()
        {
            Lines.Clear();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Tile tile = Tiles[i, j];

                    bool North = !tile[Tile.Direction.North];
                    bool East = !tile[Tile.Direction.East];
                    bool South = !tile[Tile.Direction.South];
                    bool West = !tile[Tile.Direction.West];

                    // Used to avoid double lines, so if the left east or top south side is allready there,
                    // it will also allready have been added
                    bool LeftEastSide = true;
                    if (i > 0)
                        LeftEastSide = Tiles[i - 1, j][Tile.Direction.East];
                    bool TopSouthSide = true;
                    if (j > 0)
                        TopSouthSide = Tiles[i, j - 1][Tile.Direction.South];


                    if (North && !TopSouthSide)
                    {
                        Lines.Add(new Line(i, j, i + 1, j));
                    }
                    if (East)
                    {
                        Lines.Add(new Line(i + 1, j, i + 1, j - 1));
                    }
                    if (South)
                    {
                        Lines.Add(new Line(i, j - 1, i - 1, j - 1));
                    }
                    if (West && !LeftEastSide)
                    {
                        Lines.Add(new Line(i, j, i, j - 1));
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the body is inside a wall
        /// </summary>
        //public void IsPosValid(FRect body, float rotation)
        public bool IsPositionValid(Tank body)
        {
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsLineColliding(float x1, float y1, float x2, float y2)
        {
            foreach (var line in Lines)
            {
                float lx1 = line.x1;
                float ly1 = line.y1;
                float lx2 = line.x2;
                float ly2 = line.y2;

                // Check if the line is close enough
                if (lx1 < x1 && lx2 < x1)
                    continue;
                if (x2 < lx1 && x2 < lx2)
                    continue;
                if (ly1 < y1 && ly2 < y1)
                    continue;
                if (y2 < ly1 && y2 < ly2)
                    continue;

                // https://gamedev.stackexchange.com/questions/26004/how-to-detect-2d-line-on-line-collision
                float denominator = ((x2 - x1) * (ly2 - ly1)) - ((y2 - y2) * (lx2 - lx1));
                float numerator1 = ((y2 - ly1) * (lx2 - lx1)) - ((x1 - lx1) * (ly2 - ly1));
                float numerator2 = ((y2 - ly1) * (x2 - x1)) - ((x1 - lx1) * (y2 - y2));

                // Detect coincident lines
                if (denominator == 0 && numerator1 == 0 && numerator2 == 0)
                    return true;

                float r = numerator1 / denominator;
                float s = numerator2 / denominator;

                if ((r >= 0 && r <= 1) && (s >= 0 && s <= 1))
                    return true;
            }
            return false;
        }
    }
}
