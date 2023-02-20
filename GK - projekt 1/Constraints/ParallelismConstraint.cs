using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK___projekt_1
{
    public class ParallelismConstraint : Constraint
    {

        private double m;
        private List<double> lengths;

        public ParallelismConstraint()
        {
            edgesCoveredWithConstraint = new List<Edge>();
            lengths = new List<double>();
        }

        public void AddEdgeToConstraint(Edge edge, LengthConstraint l)
        {
            if(edgesCoveredWithConstraint.Count == 0) {
                m = ((double)(edge.EndVertex.Y - edge.StartVertex.Y)) / ((double)(edge.EndVertex.X - edge.StartVertex.X));
                edgesCoveredWithConstraint.Add(edge);
            } else
            {
                edgesCoveredWithConstraint.Add(edge);
            }
            l.RefreshConstraint();
            StartRotationProcess();
            RefreshConstraint(edge, true);
            StopRotationProcess();
        }

        //private void RotateEdge(Edge edge, int pivotX, int pivotY, double m)
        //{
        //    if (Math.Abs(((double)(edge.EndVertex.Y - edge.StartVertex.Y) / (double)(edge.EndVertex.X - edge.StartVertex.X)) - m) < 0.015 ||
        //        Math.Abs(((double)(edge.StartVertex.X - edge.EndVertex.X) / (double)(edge.StartVertex.Y - edge.EndVertex.Y)) - (1 / m)) < 0.015) 
        //        return; // Avoiding unwanted edges' length change

        //    double length = Math.Sqrt(Math.Pow(Math.Abs(edge.EndVertex.X-edge.StartVertex.X),2) + Math.Pow(Math.Abs(edge.EndVertex.Y - edge.StartVertex.Y), 2));
        //    length = Math.Max(length, 50);

        //    double alfa = Math.Atan(m);
        //    int dy = (int)(length * Math.Sin(alfa) / 2);
        //    int dx = (int)(length * Math.Cos(alfa) / 2);

        //    (Edge? nEdge1, Edge? nEdge2) = NeighbouringParallelEdges(edge);

        //    if (nEdge1 != null && nEdge2 == null) {
        //        dy = (int)(length * Math.Sin(alfa));
        //        dx = (int)(length * Math.Cos(alfa));
        //        if (edge.EndVertex.Y <= edge.StartVertex.Y && m <= 0)
        //        {
        //            edge.EndVertex.X = edge.StartVertex.X + dx;
        //            edge.EndVertex.Y = edge.StartVertex.Y + dy;

        //        }
        //        else if (edge.EndVertex.Y <= edge.StartVertex.Y && m > 0)
        //        {
        //            edge.EndVertex.X = edge.StartVertex.X - dx;
        //            edge.EndVertex.Y = edge.StartVertex.Y - dy;
        //        }
        //        else if (edge.EndVertex.Y > edge.StartVertex.Y && m <= 0)
        //        {
        //            edge.EndVertex.X = edge.StartVertex.X - dx;
        //            edge.EndVertex.Y = edge.StartVertex.Y - dy;
        //        }
        //        else
        //        {
        //            edge.EndVertex.X = edge.StartVertex.X + dx;
        //            edge.EndVertex.Y = edge.StartVertex.Y + dy;
        //        }
        //        return;
        //    } else if (nEdge1 == null && nEdge2 != null)
        //    {
        //        dy = (int)(length * Math.Sin(alfa));
        //        dx = (int)(length * Math.Cos(alfa));
        //        if (edge.EndVertex.Y <= edge.StartVertex.Y && m <= 0)
        //        {
        //            edge.StartVertex.X = edge.EndVertex.X - dx;
        //            edge.StartVertex.Y = edge.EndVertex.Y - dy;
        //        }
        //        else if (edge.EndVertex.Y <= edge.StartVertex.Y && m > 0)
        //        {
        //            edge.StartVertex.X = edge.EndVertex.X + dx;
        //            edge.StartVertex.Y = edge.EndVertex.Y + dy;
        //        }
        //        else if (edge.EndVertex.Y > edge.StartVertex.Y && m <= 0)
        //        {
        //            edge.StartVertex.X = edge.EndVertex.X + dx;
        //            edge.StartVertex.Y = edge.EndVertex.Y + dy;
        //        }
        //        else
        //        {
        //            edge.StartVertex.X = edge.EndVertex.X - dx;
        //            edge.StartVertex.Y = edge.EndVertex.Y - dy;
        //        }
        //        return;
        //    } else if(nEdge1 != null && nEdge2 != null)
        //    {
        //        // nie wolno 
        //        return;
        //    }

        //    if (edge.EndVertex.Y <= edge.StartVertex.Y && m <= 0)
        //    {
        //        edge.EndVertex.X = pivotX + dx;
        //        edge.EndVertex.Y = pivotY + dy;
        //        edge.StartVertex.X = pivotX - dx;
        //        edge.StartVertex.Y = pivotY - dy;
        //    }
        //    else if (edge.EndVertex.Y <= edge.StartVertex.Y && m > 0)
        //    {
        //        edge.StartVertex.X = pivotX + dx;
        //        edge.StartVertex.Y = pivotY + dy;
        //        edge.EndVertex.X = pivotX - dx;
        //        edge.EndVertex.Y = pivotY - dy;
        //    }
        //    else if (edge.EndVertex.Y > edge.StartVertex.Y && m <= 0)
        //    {
        //        edge.StartVertex.X = pivotX + dx;
        //        edge.StartVertex.Y = pivotY + dy;
        //        edge.EndVertex.X = pivotX - dx;
        //        edge.EndVertex.Y = pivotY - dy;
        //    }
        //    else
        //    {
        //        edge.EndVertex.X = pivotX + dx;
        //        edge.EndVertex.Y = pivotY + dy;
        //        edge.StartVertex.X = pivotX - dx;
        //        edge.StartVertex.Y = pivotY - dy;
        //    }
        //}

        private (Edge?, Edge?) NeighbouringParallelEdges(Edge edge)
        {
            (Edge?, Edge?) result = (null, null);

            foreach (Edge e in edgesCoveredWithConstraint)
            {
                if (e == edge) break;
                if (edge.StartVertex == e.StartVertex || edge.StartVertex == e.EndVertex)
                {
                    result.Item1 = e;
                }
                else if (edge.EndVertex == e.StartVertex || edge.EndVertex == e.EndVertex)
                {
                    result.Item2 = e;
                }
            }
            return result;
        }

        private void RotateEdge(Edge edge, int pivotX, int pivotY, double m)
        {
            double length = lengths[edgesCoveredWithConstraint.IndexOf(edge)];

            double alfa = Math.Atan(m);
            int dx, dy;
            
            (Edge? nEdge1, Edge? nEdge2) = NeighbouringParallelEdges(edge);

            if (nEdge1 != null && nEdge2 == null)
            {
                dy = (int)(length * Math.Sin(alfa));
                dx = (int)(length * Math.Cos(alfa));
                if (edge.EndVertex.Y <= edge.StartVertex.Y && m <= 0)
                {
                    edge.EndVertex.X = edge.StartVertex.X + dx;
                    edge.EndVertex.Y = edge.StartVertex.Y + dy;

                }
                else if (edge.EndVertex.Y <= edge.StartVertex.Y && m > 0)
                {
                    edge.EndVertex.X = edge.StartVertex.X - dx;
                    edge.EndVertex.Y = edge.StartVertex.Y - dy;
                }
                else if (edge.EndVertex.Y > edge.StartVertex.Y && m <= 0)
                {
                    edge.EndVertex.X = edge.StartVertex.X - dx;
                    edge.EndVertex.Y = edge.StartVertex.Y - dy;
                }
                else
                {
                    edge.EndVertex.X = edge.StartVertex.X + dx;
                    edge.EndVertex.Y = edge.StartVertex.Y + dy;
                }
                return;
            }
            else if (nEdge1 == null && nEdge2 != null)
            {
                dy = (int)(length * Math.Sin(alfa));
                dx = (int)(length * Math.Cos(alfa));
                if (edge.EndVertex.Y <= edge.StartVertex.Y && m <= 0)
                {
                    edge.StartVertex.X = edge.EndVertex.X - dx;
                    edge.StartVertex.Y = edge.EndVertex.Y - dy;
                }
                else if (edge.EndVertex.Y <= edge.StartVertex.Y && m > 0)
                {
                    edge.StartVertex.X = edge.EndVertex.X + dx;
                    edge.StartVertex.Y = edge.EndVertex.Y + dy;
                }
                else if (edge.EndVertex.Y > edge.StartVertex.Y && m <= 0)
                {
                    edge.StartVertex.X = edge.EndVertex.X + dx;
                    edge.StartVertex.Y = edge.EndVertex.Y + dy;
                }
                else
                {
                    edge.StartVertex.X = edge.EndVertex.X - dx;
                    edge.StartVertex.Y = edge.EndVertex.Y - dy;
                }
                return;
            }

            dy = (int)(length * Math.Sin(alfa) / 2);
            dx = (int)(length * Math.Cos(alfa) / 2);
            if (edge.EndVertex.Y <= edge.StartVertex.Y && m <= 0)
            {
                edge.EndVertex.X = pivotX + dx;
                edge.EndVertex.Y = pivotY + dy;
                edge.StartVertex.X = pivotX - dx;
                edge.StartVertex.Y = pivotY - dy;
            }
            else if (edge.EndVertex.Y <= edge.StartVertex.Y && m > 0)
            {
                edge.StartVertex.X = pivotX + dx;
                edge.StartVertex.Y = pivotY + dy;
                edge.EndVertex.X = pivotX - dx;
                edge.EndVertex.Y = pivotY - dy;
            }
            else if (edge.EndVertex.Y > edge.StartVertex.Y && m <= 0)
            {
                edge.StartVertex.X = pivotX + dx;
                edge.StartVertex.Y = pivotY + dy;
                edge.EndVertex.X = pivotX - dx;
                edge.EndVertex.Y = pivotY - dy;
            }
            else
            {
                edge.EndVertex.X = pivotX + dx;
                edge.EndVertex.Y = pivotY + dy;
                edge.StartVertex.X = pivotX - dx;
                edge.StartVertex.Y = pivotY - dy;
            }
        }

        public void StartRotationProcess()
        {
            foreach(Edge edge in edgesCoveredWithConstraint)
            {
                lengths.Add(Math.Sqrt(Math.Pow(Math.Abs(
                    edge.EndVertex.X - edge.StartVertex.X), 2) +
                    Math.Pow(Math.Abs(edge.EndVertex.Y - 
                    edge.StartVertex.Y), 2)));
            }
        }

        public void StopRotationProcess()
        {
            lengths.Clear();
        }

        public void RefreshConstraint(Edge rotatedEdge, bool newEdgeAdded=false)
        {
            if (edgesCoveredWithConstraint.Count == 0) return;

            double m;
            if (newEdgeAdded)
            {
                m = ((double)(edgesCoveredWithConstraint[0].EndVertex.Y -
                    edgesCoveredWithConstraint[0].StartVertex.Y)) /
                    ((double)(edgesCoveredWithConstraint[0].EndVertex.X -
                    edgesCoveredWithConstraint[0].StartVertex.X));
            }
            else if (edgesCoveredWithConstraint.Contains(rotatedEdge)) {
                m = ((double)(rotatedEdge.EndVertex.Y - rotatedEdge.StartVertex.Y)) /
                    ((double)(rotatedEdge.EndVertex.X - rotatedEdge.StartVertex.X));
            } else if(edgesCoveredWithConstraint.Contains(rotatedEdge.StartVertex.EndEdge))
            {
                m = ((double)(rotatedEdge.StartVertex.EndEdge.EndVertex.Y -
                    rotatedEdge.StartVertex.EndEdge.StartVertex.Y)) /
                    ((double)(rotatedEdge.StartVertex.EndEdge.EndVertex.X -
                    rotatedEdge.StartVertex.EndEdge.StartVertex.X));
            } else if (edgesCoveredWithConstraint.Contains(rotatedEdge.EndVertex.StartEdge))
            {
                m = ((double)(rotatedEdge.EndVertex.StartEdge.EndVertex.Y -
                    rotatedEdge.EndVertex.StartEdge.StartVertex.Y)) /
                    ((double)(rotatedEdge.EndVertex.StartEdge.EndVertex.X -
                    rotatedEdge.EndVertex.StartEdge.StartVertex.X));
            } else
            {
                m = ((double)(edgesCoveredWithConstraint[0].EndVertex.Y - 
                    edgesCoveredWithConstraint[0].StartVertex.Y)) /
                    ((double)(edgesCoveredWithConstraint[0].EndVertex.X - 
                    edgesCoveredWithConstraint[0].StartVertex.X));
            }

            foreach (Edge edge in edgesCoveredWithConstraint)
            {
                int edgeMiddleX = (edge.EndVertex.X + edge.StartVertex.X) / 2;
                int edgeMiddleY = (edge.EndVertex.Y + edge.StartVertex.Y) / 2;

                RotateEdge(edge, edgeMiddleX, edgeMiddleY, m);
            }
        }

        public void RefreshConstraint()
        {
            if (edgesCoveredWithConstraint.Count == 0) return;

            double m = ((double)(edgesCoveredWithConstraint[edgesCoveredWithConstraint.Count-1].EndVertex.Y -
                    edgesCoveredWithConstraint[edgesCoveredWithConstraint.Count - 1].StartVertex.Y)) /
                    ((double)(edgesCoveredWithConstraint[edgesCoveredWithConstraint.Count - 1].EndVertex.X -
                    edgesCoveredWithConstraint[edgesCoveredWithConstraint.Count - 1].StartVertex.X));

            foreach (Edge edge in edgesCoveredWithConstraint)
            {
                int edgeMiddleX = (edge.EndVertex.X + edge.StartVertex.X) / 2;
                int edgeMiddleY = (edge.EndVertex.Y + edge.StartVertex.Y) / 2;

                RotateEdge(edge, edgeMiddleX, edgeMiddleY, m);
            }
        }

        public void RefreshConstraint(Vertex movedVertex, Vertex pivot, Edge rotatedEdge)
        {
            if (edgesCoveredWithConstraint.Count == 0) return;

            double m = ((double)(pivot.Y - movedVertex.Y)) / ((double)(pivot.X - movedVertex.X));

            foreach (Edge edge in edgesCoveredWithConstraint)
            {
                if (edge == rotatedEdge) continue;
                int edgeMiddleX = (edge.EndVertex.X + edge.StartVertex.X) / 2;
                int edgeMiddleY = (edge.EndVertex.Y + edge.StartVertex.Y) / 2;

                RotateEdge(edge, edgeMiddleX, edgeMiddleY, m);
            }
        } 

    }
}
