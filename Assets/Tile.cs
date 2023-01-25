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
            Invalid = -1,
            North = 0,
            East = 1,
            South = 2,
            West = 3,
        }

        public bool[] Directions;

        public Tile()
        {
            Directions = new bool[4];
        }

        public Tile(bool[] directions)
        {
            if (directions.Length != 4)
                throw new Exception("Can NOT have directions less or more than 4");
            Directions = directions;
        }

        public Direction GetRandomOpenDirection(Random rand)
        {
            if (Directions.Count(x => !x) == 0)
                return Direction.Invalid; // No openings
            while (true)
            {
                int dir = rand.Next(0, 4);
                if (Directions[dir])
                {
                    return (Direction)dir;
                }
            }
        }

        public bool this[Direction index]
        {
            get => Directions[(int)index];
            set => Directions[(int)index] = value;
        }
    }
}
