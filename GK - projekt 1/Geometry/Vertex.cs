using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK___projekt_1
{
    public class Vertex
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Edge EndEdge { get; set; }
        public Edge StartEdge { get; set; }

        public Brush Brush { get; set; }

        public Vertex(int x, int y, Brush brush)
        {
            X = x;
            Y = y;
            Brush = brush;
        }
    }
}
