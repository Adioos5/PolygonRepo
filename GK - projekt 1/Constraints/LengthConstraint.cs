using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK___projekt_1
{
    public class LengthConstraint : Constraint
    {
        public int mode = 1;
        public double length;
        public List<Edge> edgesCoveredWithConstraint;

        public LengthConstraint()
        {
            edgesCoveredWithConstraint = new List<Edge>();
        }

        public void AddEdgeToConstraint(Edge edge, ParallelismConstraint p, int value=-1)
        {
            if (edgesCoveredWithConstraint.Count == 0)
            {
                if (value == -1)
                {
                    using (var form = new SetLengthForm())
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            length = form.LengthValue;
                        }
                    }
                }
                else length = value;
                //length = Math.Sqrt(Math.Pow(Math.Abs(edge.EndVertex.X 
                //    - edge.StartVertex.X), 2) + Math.Pow(Math.Abs(edge.EndVertex.Y 
                //    - edge.StartVertex.Y), 2));

                edgesCoveredWithConstraint.Add(edge);
            }
            else
            {
                edgesCoveredWithConstraint.Add(edge);
            }
            p.StartRotationProcess();
            p.RefreshConstraint();
            p.StopRotationProcess();
            RefreshConstraint();
        }

        public void RefreshConstraint()
        {
            foreach (Edge edge in edgesCoveredWithConstraint)
            {
                double m = ((double)(edge.EndVertex.Y - edge.StartVertex.Y)) / ((double)(edge.EndVertex.X - edge.StartVertex.X));
                int pivotX = (edge.EndVertex.X + edge.StartVertex.X) / 2;
                int pivotY = (edge.EndVertex.Y + edge.StartVertex.Y) / 2;

                double alfa = Math.Atan(m);
                int dy = (int)(length * Math.Sin(alfa) / 2);
                int dx = (int)(length * Math.Cos(alfa) / 2);

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
                {                     edge.EndVertex.X = pivotX + dx;
                    edge.EndVertex.Y = pivotY + dy;
                    edge.StartVertex.X = pivotX - dx;
                    edge.StartVertex.Y = pivotY - dy;
                }

            }
        }
    }
}

