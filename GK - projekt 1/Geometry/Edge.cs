using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK___projekt_1
{
    public class Edge
    {
        public Vertex StartVertex { get; set; }
        public Vertex EndVertex { get; set; }

        public Pen Pen { get; set; }

        public Edge(Vertex s, Vertex e, Pen pen)
        {
            StartVertex = s;
            EndVertex = e;
            Pen = pen;
        }
    }
}
