using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK___projekt_1
{
    public class Polygon
    {
        public List<Vertex> Vertices { get; set; }
        public List<Edge> Edges { get; set; }

        public Polygon(List<Vertex> vertices, List<Edge> edges)
        {
            Vertices = vertices;
            Edges = edges;
        }
    }
}
