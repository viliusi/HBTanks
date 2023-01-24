using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    /// <summary>
    /// Indicates what sides you can walk through
    /// </summary>
    public class Tile
    {
        //public bool North;
        //public bool East;
        //public bool South;
        //public bool West;

        //public Tile(bool north, bool east, bool south, bool west)
        //{
        //    North = north;
        //    East = east;
        //    South = south;
        //    West = west;
        //}

        public enum Direction
        {
            North = 0,
            East = 1,
            South = 2,
            West = 3,
        }

        public bool[] Directions;

        public Tile(bool[] directions)
        {
            Directions = directions;
        }

        public int GetRandomOpenDirection(Random rand)
        {
            if (Directions.Count(x => !x) == 0)
                return -1; // No openings
            while (true)
            {
                int dir = rand.Next(0, 4);
                if (Directions[dir])
                {
                    return dir;
                }
            }
        }

        public bool this[int index]
        {
            get => Directions[index];
            set => Directions[index] = value;
        }
    }
}
