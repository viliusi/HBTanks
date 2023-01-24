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
        public bool North;
        public bool East;
        public bool South;
        public bool West;

        public Tile(bool north, bool east, bool south, bool west)
        {
            North = north;
            East = east;
            South = south;
            West = west;
        }
    }
}
