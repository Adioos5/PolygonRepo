using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK___projekt_1
{
    public static class PredefinedSceneGenerator
    {
        public static void GeneratePredefinedScene(Context context)
        {
            // Polygon #1
            Conditions.isPolygonInCreationProcess = true;
            AddVertexWithCoordinates(context, 250, 300);
            AddVertexWithCoordinates(context, 300, 350);
            AddVertexWithCoordinates(context, 250, 450);
            AddVertexWithCoordinates(context, 450, 400);
            AddVertexWithCoordinates(context, 400, 350);
            AddVertexWithCoordinates(context, 550, 100);
            AddVertexWithCoordinates(context, 400, 100);
            AddVertexWithCoordinates(context, 350, 100);
            AddVertexWithCoordinates(context, 200, 100);
            FinishPredefinedPolygonCreation(context);

            context.parallelismConstraint.AddEdgeToConstraint(context.polygons[0].Edges[1], context.lengthConstraint);
            context.parallelismConstraint.AddEdgeToConstraint(context.polygons[0].Edges[4], context.lengthConstraint);
            context.lengthConstraint.AddEdgeToConstraint(context.polygons[0].Edges[7], context.parallelismConstraint, 100);
            context.lengthConstraint.AddEdgeToConstraint(context.polygons[0].Edges[8], context.parallelismConstraint, 100);

            // Polygon #2
            Conditions.isPolygonInCreationProcess = true;
            AddVertexWithCoordinates(context, 800, 400);
            AddVertexWithCoordinates(context, 700, 600);
            AddVertexWithCoordinates(context, 700, 700);
            AddVertexWithCoordinates(context, 800, 700);
            AddVertexWithCoordinates(context, 800, 500);
            FinishPredefinedPolygonCreation(context);

            context.parallelismConstraint.AddEdgeToConstraint(context.polygons[1].Edges[3], context.lengthConstraint);
        }

        private static void FinishPredefinedPolygonCreation(Context context)
        {
            List<Vertex> polygon_vertices = new List<Vertex>();
            List<Edge> polygon_edges = new List<Edge>();

            for (int i = context.firstPolygonIndex; i < context.lastPolygonIndex; i++)
            {
                polygon_vertices.Add(context.vertices[i]);
                polygon_edges.Add(context.edges[i]);
            }

            context.polygons.Add(new Polygon(polygon_vertices, polygon_edges));

            context.firstPolygonsVertex.EndEdge = context.edges[context.currentEdgeIndex];

            context.edges[context.currentEdgeIndex].Pen = context.pens[(int)Enums.Pens.SEMI_TRANSPARENT_WHITE_PEN];
            context.edges[context.currentEdgeIndex].EndVertex = context.firstPolygonsVertex;

            Conditions.isPolygonInCreationProcess = false;

            context.verticesCounter = 0;

            context.firstPolygonsVertex.Brush = Brushes.White;
            context.firstPolygonsVertex = null;

            context.firstPolygonIndex = context.lastPolygonIndex;
        }

        private static void AddVertexWithCoordinates(Context context, int x, int y)
        {
            context.verticesCounter++;
            context.lastPolygonIndex++;
            Vertex v = new Vertex(x, y, Brushes.White);
            if (context.verticesCounter == 1) context.firstPolygonsVertex = v;
            context.vertices.Add(v);
            context.edges.Add(new Edge(v, v, context.pens[(int)Enums.Pens.SEMI_TRANSPARENT_WHITE_PEN]));

            context.currentVertexIndex = context.vertices.Count - 1;
            context.currentEdgeIndex = context.edges.Count - 1;

            if (context.currentEdgeIndex > 0)
            {
                context.edges[context.currentEdgeIndex - 1].Pen = context.pens[(int)Enums.Pens.WHITE_PEN];
                if (context.verticesCounter > 1) context.edges[context.currentEdgeIndex - 1].EndVertex = v;
                context.vertices[context.currentVertexIndex].EndEdge = context.edges[context.currentEdgeIndex - 1];
            }
            v.StartEdge = context.edges[context.currentEdgeIndex];
        }


    }
}
