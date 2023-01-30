using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class FBox
    {
        // Top side
        public float X;
        // Left side
        public float Y;
        public float Width;
        public float Height;
        [Range(0, 360)]
        public float Rotation;

        public Line[] GetLines()
        {
            Line[] lines = new Line[4];
            throw new NotImplementedException();
            return lines;
        }
    }
}
