using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK___projekt_1
{
    public static class Logic
    {
        // Method ManageParallelismConstraintEdgeAddition adds an edge to parallelism constraint preserving constraint's rules
        public static void ManageParallelismConstraintEdgeAddition(ref ParallelismConstraint parallelismConstraint, 
            ref LengthConstraint lengthConstraint, List<Edge> edges, int idx)
        {
            if (parallelismConstraint.edgesCoveredWithConstraint.Contains(edges[idx]))
            {
                parallelismConstraint.edgesCoveredWithConstraint.Remove(edges[idx]);
                if (parallelismConstraint.edgesCoveredWithConstraint.Count == 0) parallelismConstraint = new ParallelismConstraint();
            }
            else if (!lengthConstraint.edgesCoveredWithConstraint.Contains(edges[idx])) 
                parallelismConstraint.AddEdgeToConstraint(edges[idx], lengthConstraint);
        }

        // Method ManageLengthConstraintEdgeAddition adds an edge to length constraint preserving constraint's rules
        public static void ManageLengthConstraintEdgeAddition(ref LengthConstraint lengthConstraint, 
            ref ParallelismConstraint parallelismConstraint, List<Edge> edges, int idx)
        {
            if (lengthConstraint.edgesCoveredWithConstraint.Contains(edges[idx]))
            {
                lengthConstraint.edgesCoveredWithConstraint.Remove(edges[idx]);
                if (lengthConstraint.edgesCoveredWithConstraint.Count == 0) lengthConstraint = new LengthConstraint();
            }
            else if (!parallelismConstraint.edgesCoveredWithConstraint.Contains(edges[idx])) 
                lengthConstraint.AddEdgeToConstraint(edges[idx], parallelismConstraint);
        }

        // Method PutVertexOnEdge is responsible for an insertion of vertex on edge
        public static void PutVertexOnEdge(int vertexOnEdgeX, int vertexOnEdgeY, Edge lastHoveredEdge, 
            Polygon lastHoveredPolygon, List<Edge> edges, List<Vertex> vertices, Pen pen)
        {
            Vertex v = new Vertex(vertexOnEdgeX, vertexOnEdgeY, Brushes.White);
            Edge e1 = new Edge(lastHoveredEdge.StartVertex, v, pen);
            Edge e2 = new Edge(v, lastHoveredEdge.EndVertex, pen);

            lastHoveredEdge.StartVertex.StartEdge = e1;
            lastHoveredEdge.EndVertex.EndEdge = e2;
            v.EndEdge = e1;
            v.StartEdge = e2;

            edges.Remove(lastHoveredEdge);
            edges.Add(e1);
            edges.Add(e2);
            vertices.Add(v);

            lastHoveredPolygon.Edges.Remove(lastHoveredEdge);
            lastHoveredPolygon.Edges.Add(e1);
            lastHoveredPolygon.Edges.Add(e2);
            lastHoveredPolygon.Vertices.Add(v);
        }

        // Method StopMovingAPolygon is responsible for stopping a polygon movement
        public static void StopMovingAPolygon(List<Polygon> polygons, List<Point> movedPolygonVertexDiffs, ref int clickedPolygonIndex, 
            ref bool polygonMovementReady, Pen pen)
        {
            foreach (Vertex v in polygons[clickedPolygonIndex].Vertices)
            {
                v.Brush = Brushes.White;
            }
            foreach (Edge edge in polygons[clickedPolygonIndex].Edges)
            {
                edge.Pen = pen;
            }

            polygonMovementReady = false;
            clickedPolygonIndex = -1;

            movedPolygonVertexDiffs.Clear();
        }

        // Method FinishPolygonCreation is responsible for finishing a creation of polygon
        public static void FinishPolygonCreation(ref Vertex firstPolygonsVertex, ref int firstPolygonIndex, int lastPolygonIndex, 
            int currentEdgeIndex, List<Edge> edges, List<Polygon> polygons, List<Vertex> vertices, Pen pen,
            ref bool isPolygonInCreationProcess, ref int verticesCounter)
        {
            List<Vertex> polygon_vertices = new List<Vertex>();
            List<Edge> polygon_edges = new List<Edge>();

            for (int i = firstPolygonIndex; i < lastPolygonIndex; i++)
            {
                polygon_vertices.Add(vertices[i]);
                polygon_edges.Add(edges[i]);
            }

            polygons.Add(new Polygon(polygon_vertices, polygon_edges));

            firstPolygonsVertex.EndEdge = edges[currentEdgeIndex];

            edges[currentEdgeIndex].Pen = pen;
            edges[currentEdgeIndex].EndVertex = firstPolygonsVertex;

            isPolygonInCreationProcess = false;

            verticesCounter = 0;

            firstPolygonsVertex.Brush = Brushes.White;
            firstPolygonsVertex = null;

            firstPolygonIndex = lastPolygonIndex;
        }

        // Method FinishPolygonCreation is responsible for launching a polygon movement
        public static void StartEdgeMovement(bool polygonMovementMode, ref bool polygonMovementReady, ref bool edgeMovementMode, 
            List<Polygon> polygons, ref int clickedPolygonIndex, 
            int idx, List<Point>movedPolygonVertexDiffs, List<Edge> edges, ref Edge movedEdge, 
            ref int movedEdgeStartXDiff, ref int movedEdgeStartYDiff, ref int movedEdgeEndXDiff, ref int movedEdgeEndYDiff,
            MouseEventArgs e, ParallelismConstraint parallelismConstraint, bool parallelismMode)
        {
            if (polygonMovementMode)
            {
                foreach (Polygon p in polygons)
                    if (p.Edges.Contains(edges[idx]))
                    {
                        clickedPolygonIndex = polygons.IndexOf(p);
                        foreach (Vertex v in p.Vertices)
                        {
                            movedPolygonVertexDiffs.Add(new Point(e.X - v.X, e.Y - v.Y));
                        }
                        polygonMovementReady = true;
                        return;
                    }
            }
            parallelismConstraint.StartRotationProcess();
            movedEdge = edges[idx];
            edgeMovementMode = true;
            movedEdgeStartXDiff = movedEdge.StartVertex.X - e.X;
            movedEdgeStartYDiff = movedEdge.StartVertex.Y - e.Y;
            movedEdgeEndXDiff = movedEdge.EndVertex.X - e.X;
            movedEdgeEndYDiff = movedEdge.EndVertex.Y - e.Y;
        }

        // Method StartVertexMovement is responsible for launching a vertex movement
        public static void StartVertexMovement(ref bool vertexMovementMode, ref bool polygonMovementReady, bool polygonMovementMode,
            List<Polygon> polygons, ref int clickedPolygonIndex, ref Vertex movedVertex, List<Point> movedPolygonVertexDiffs, 
            Vertex v, MouseEventArgs e, ParallelismConstraint parallelismConstraint)
        {
            if (polygonMovementMode)
            {
                foreach (Polygon p in polygons)
                    if (p.Vertices.Contains(v))
                    {
                        clickedPolygonIndex = polygons.IndexOf(p);
                        foreach (Vertex ve in p.Vertices)
                        {
                            movedPolygonVertexDiffs.Add(new Point(e.X - ve.X, e.Y - ve.Y));
                        }
                        polygonMovementReady = true;
                        return;
                    }
            }
            parallelismConstraint.StartRotationProcess();
            movedVertex = v;
            vertexMovementMode = true;
        }

        // Method HandleVertexHover is responsible for handling a vertex hover
        public static void HandleVertexHover(List<Vertex> vertices, out bool onAnyVertex,
            bool polygonMovementMode, Func<int, int, int, int, int,bool> InsideCircle,
            MouseEventArgs e, int RADIUS)
        {
            onAnyVertex = false;
            foreach (Vertex v in vertices)
            {
                if (InsideCircle(v.X, v.Y, RADIUS, e.X, e.Y))
                {
                    onAnyVertex = true;
                    if (!polygonMovementMode) v.Brush = Brushes.GreenYellow;
                }
                else
                {
                    v.Brush = Brushes.White;
                }
            }
        }

        // Method HandleVertexHover is responsible for handling an edge hover
        public static void HandleEdgeHover(List<Edge> edges, out bool onAnyEdge, ref Edge lastHoveredEdge, ref Polygon lastHoveredPolygon,
            List<Polygon> polygons, ref int vertexOnEdgeX, ref int vertexOnEdgeY, bool polygonMovementMode, 
            Func<Point, Point, Point, int, bool> IsOnLine,
            Pen edgeHoverPen, Pen pen, MouseEventArgs e, int LINE_WIDTH)
        {
            onAnyEdge = false;
            foreach (Edge ee in edges)
            {
                if (IsOnLine(new Point(ee.StartVertex.X, ee.StartVertex.Y), new Point(ee.EndVertex.X, ee.EndVertex.Y), 
                    new Point(e.X, e.Y), LINE_WIDTH))
                {
                    onAnyEdge = true;
                    lastHoveredEdge = ee;
                    foreach (Polygon p in polygons)
                    {
                        if (p.Edges.Contains(ee))
                        {
                            lastHoveredPolygon = p;
                            break;
                        }
                    }

                    int finalX = (lastHoveredEdge.StartVertex.X + lastHoveredEdge.EndVertex.X) / 2;
                    int finalY = (lastHoveredEdge.StartVertex.Y + lastHoveredEdge.EndVertex.Y) / 2;

                    vertexOnEdgeX = finalX;
                    vertexOnEdgeY = finalY;

                    if (!polygonMovementMode) ee.Pen = edgeHoverPen;
                }
                else
                {
                    ee.Pen = pen;
                }
            }
        }

        // Method MovePolygon is responsible for moving a polygon
        public static void MovePolygon(List<Polygon>polygons, int clickedPolygonIndex, Pen orangePen, List<Point>movedPolygonVertexDiffs, 
            MouseEventArgs e)
        {
            foreach (Vertex v in polygons[clickedPolygonIndex].Vertices)
            {
                v.Brush = Brushes.Orange;
            }
            foreach (Edge ee in polygons[clickedPolygonIndex].Edges)
            {
                ee.Pen = orangePen;
            }

            for (int i = 0; i < polygons[clickedPolygonIndex].Vertices.Count; i++)
            {
                polygons[clickedPolygonIndex].Vertices[i].X = e.X - movedPolygonVertexDiffs[i].X;
                polygons[clickedPolygonIndex].Vertices[i].Y = e.Y - movedPolygonVertexDiffs[i].Y;
            }
        }

        // Method RefreshOpaqueEdgePosition is responsible for setting opaque edge's end to where mouse cursor points
        public static void RefreshOpaqueEdgePosition(List<Edge> edges, int currentEdgeIndex, Pen semi_transparent_pen, MouseEventArgs e)
        {
            edges[currentEdgeIndex].EndVertex = new Vertex(e.X, e.Y, Brushes.White);
            edges[currentEdgeIndex].Pen = semi_transparent_pen;
        }

        // Method MoveVertex is responsible for moving a vertex
        public static void MoveVertex(Vertex movedVertex, ParallelismConstraint parallelismConstraint, LengthConstraint lengthConstraint, 
            MouseEventArgs e)
        {
            movedVertex.X = e.X;
            movedVertex.Y = e.Y;
            movedVertex.EndEdge.EndVertex = movedVertex;
            movedVertex.StartEdge.StartVertex = movedVertex;

            if (parallelismConstraint.edgesCoveredWithConstraint.Contains(movedVertex.StartEdge))
            {
                parallelismConstraint.RefreshConstraint(movedVertex, movedVertex.StartEdge.EndVertex, movedVertex.StartEdge);
            } else if (parallelismConstraint.edgesCoveredWithConstraint.Contains(movedVertex.EndEdge))
            {
                parallelismConstraint.RefreshConstraint(movedVertex, movedVertex.EndEdge.StartVertex, movedVertex.EndEdge);
            }
            
            lengthConstraint.RefreshConstraint();
        }

        // Method MoveVertex is responsible for moving an edge
        public static void MoveEdge(List<Vertex> vertices, Edge movedEdge,
            int movedEdgeStartXDiff, int movedEdgeStartYDiff, int movedEdgeEndXDiff, int movedEdgeEndYDiff,
            ParallelismConstraint parallelismConstraint, LengthConstraint lengthConstraint, MouseEventArgs e, bool parallelismMode, bool lengthMode)
        {
            movedEdge.StartVertex.X = e.X + movedEdgeStartXDiff;
            movedEdge.StartVertex.Y = e.Y + movedEdgeStartYDiff;
            movedEdge.EndVertex.X = e.X + movedEdgeEndXDiff;
            movedEdge.EndVertex.Y = e.Y + movedEdgeEndYDiff;
            movedEdge.StartVertex.EndEdge.EndVertex = movedEdge.StartVertex;
            movedEdge.EndVertex.StartEdge.StartVertex = movedEdge.EndVertex;

            parallelismConstraint.RefreshConstraint(movedEdge);
            lengthConstraint.RefreshConstraint();
        }

        public static void AddNewVertex(ref int verticesCounter, ref int lastPolygonIndex, MouseEventArgs e, 
            ref Vertex firstPolygonsVertex, List<Vertex> vertices, List<Edge> edges, Pen semi_transparent_pen, Pen pen,
            ref int currentVertexIndex, ref int currentEdgeIndex)
        {
            verticesCounter++;
            lastPolygonIndex++;

            Vertex v = new Vertex(e.X, e.Y, Brushes.White);

            if (verticesCounter == 1) firstPolygonsVertex = v;

            vertices.Add(v);
            edges.Add(new Edge(v, v, semi_transparent_pen));

            currentVertexIndex = vertices.Count - 1;
            currentEdgeIndex = edges.Count - 1;

            if (currentEdgeIndex > 0)
            {
                edges[currentEdgeIndex - 1].Pen = pen;
                if (verticesCounter > 1) edges[currentEdgeIndex - 1].EndVertex = v;
                vertices[currentVertexIndex].EndEdge = edges[currentEdgeIndex - 1];
            }
            v.StartEdge = edges[currentEdgeIndex];
        }
    }
}
