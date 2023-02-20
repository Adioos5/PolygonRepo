using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace GK___projekt_1
{
    public partial class Form1 : Form
    {

        private Context context; // Object containing all variables except boolean ones responsible for app's work

        public Form1()
        {
            InitializeComponent();
            
            context = new Context(Canvas);

            //PredefinedSceneGenerator.GeneratePredefinedScene(context);
        }

        // Method InsideCircle checks if point "(x,y)" is inside of a circle with radius "r" and center "(xc, yc)"
        private static bool InsideCircle(int xc, int yc, int r, int x, int y)
        {
            int dx = xc - x;
            int dy = yc - y;
            return dx * dx + dy * dy <= r * r;
        }

        // Method IsOnLine checks if point "p" is inside of a line with endings in "p1" and "p2" and width equal to "width"
        private bool IsOnLine(Point p1, Point p2, Point p, int width = 1)
        {
            using (var path = new GraphicsPath()) 
            {
                using (var pen = new Pen(Brushes.Black, width))
                {
                    path.AddLine(p1, p2);
                    return path.IsOutlineVisible(p, pen);
                }
            }
        }

        // Method IsHoverOnEdge, if point "p" hovers any of the edges, returns the hovered edge's index. Otherwise returns "-1"
        private int IsHoverOnEdge(Point p)
        {
            for(int i = 0;i< context.edges.Count;i++)
            {
                if(IsOnLine(new Point(context.edges[i].StartVertex.X, context.edges[i].StartVertex.Y), 
                    new Point(context.edges[i].EndVertex.X, context.edges[i].EndVertex.Y), p, Constants.LINE_WIDTH))
                {
                    return i;
                }
            }

            return -1;
        }

        // Method BresenhamLine draws a line from point "(x,y)" to point "(x2,y2)" with a "color" color
        private void BresenhamLine(int x, int y, int x2, int y2, Color color)
        {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                context.drawArea.SetPixel(x, y, color);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }

        // Method Repaint is responsible for refreshing the Canvas in case of its update
        private void Repaint(int mouseX = 0, int mouseY = 0)
        {
            using (Graphics g = Graphics.FromImage(context.drawArea))
            {
                g.Clear(Color.DarkBlue);
                if (!Conditions.isPolygonInCreationProcess && Conditions.editionMode && !Conditions.hovering) 
                    g.FillEllipse(context.semiTransBrush, mouseX - Constants.RADIUS, mouseY - Constants.RADIUS, 
                        Constants.RADIUS * 2, Constants.RADIUS * 2);
            }

            foreach (Edge edge in context.edges)
            {
                using (Graphics g = Graphics.FromImage(context.drawArea))
                {
                    if (Conditions.drawLinesUsingLibrary)
                        g.DrawLine(edge.Pen, new Point(edge.StartVertex.X, edge.StartVertex.Y),
                        new Point(edge.EndVertex.X, edge.EndVertex.Y));

                    else if (Conditions.drawLinesUsingBresenham)
                    {
                        BresenhamLine(edge.StartVertex.X, edge.StartVertex.Y, edge.EndVertex.X, edge.EndVertex.Y, Color.White);
                    }
                    else if (Conditions.drawLinesUsingXiaolinWu)
                    {
                        WuLine.draw(edge.StartVertex.X, edge.StartVertex.Y, edge.EndVertex.X,
                            edge.EndVertex.Y, Color.White, 128, 128, context.drawArea);
                    }

                    if (context.parallelismConstraint.edgesCoveredWithConstraint.Contains(edge) && !Conditions.polygonMovementMode)
                    {
                        int edgeMiddleX = (edge.EndVertex.X + edge.StartVertex.X) / 2;
                        int edgeMiddleY = (edge.EndVertex.Y + edge.StartVertex.Y) / 2;
                        g.DrawImage(context.edgeIcons[(int)Enums.EdgeIcons.PARALLELISM_RED], edgeMiddleX-Constants.ICON_SIZE/2, 
                            edgeMiddleY- Constants.ICON_SIZE / 2, context.srcRect, context.units);
                    }
                    else if (context.lengthConstraint.edgesCoveredWithConstraint.Contains(edge) && !Conditions.polygonMovementMode)
                    {
                        int edgeMiddleX = (edge.EndVertex.X + edge.StartVertex.X) / 2;
                        int edgeMiddleY = (edge.EndVertex.Y + edge.StartVertex.Y) / 2;

                        int width;
                        if (context.lengthConstraint.length.ToString().Length == 0) width = 10;
                        else if (context.lengthConstraint.length.ToString().Length == 1) width = 20;
                        else if (context.lengthConstraint.length.ToString().Length == 2) width = 30;
                        else if (context.lengthConstraint.length.ToString().Length == 3) width = 40;
                        else width = 60;

                        g.FillRectangle(Brushes.Red, new Rectangle(edgeMiddleX - 20, edgeMiddleY - 20, width, 25));
                        g.DrawString(context.lengthConstraint.length.ToString(),
                            context.font, Brushes.White, edgeMiddleX - 20, edgeMiddleY - 20);
                    }
                }
            }

            foreach(Vertex vertex in context.vertices)
            {
                using (Graphics g = Graphics.FromImage(context.drawArea)) 
                {
                    g.FillEllipse(vertex.Brush, vertex.X - Constants.RADIUS, vertex.Y - Constants.RADIUS, Constants.RADIUS * 2, 
                        Constants.RADIUS * 2);
                }
            }

            if (Conditions.vertexInsertionMode && Conditions.shallAPreviewOfVertexOnEdgeBeDrawn)
            {
                using (Graphics g = Graphics.FromImage(context.drawArea))
                {
                    g.FillEllipse(context.semiTransBrush, context.insertedVertexX - Constants.RADIUS, 
                        context.insertedVertexY - Constants.RADIUS, Constants.RADIUS * 2, Constants.RADIUS * 2);
                }
            }

            Canvas.Refresh();
        } 

        // Launches when left or right mouse button is clicked
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            int idx;
         
            if(e.Button == MouseButtons.Left)
            {
                if (Conditions.vertexInsertionMode && IsHoverOnEdge(new Point(e.X, e.Y)) == -1)
                {
                    return;
                }
                if (Conditions.parallelismMode && (idx = IsHoverOnEdge(new Point(e.X, e.Y))) != -1)
                {
                    Logic.ManageParallelismConstraintEdgeAddition(ref context.parallelismConstraint, ref context.lengthConstraint, context.edges, idx);
                    return;
                }
                else if (Conditions.parallelismMode && IsHoverOnEdge(new Point(e.X, e.Y)) == -1) return;

                if (Conditions.lengthMode && (idx = IsHoverOnEdge(new Point(e.X, e.Y))) != -1)
                {
                    Logic.ManageLengthConstraintEdgeAddition(ref context.lengthConstraint, ref context.parallelismConstraint, context.edges, idx);
                    return;
                }
                else if(Conditions.lengthMode && IsHoverOnEdge(new Point(e.X, e.Y)) == -1) return;

                if (Conditions.vertexInsertionMode && Conditions.shallAPreviewOfVertexOnEdgeBeDrawn && Conditions.editionMode && 
                    !context.parallelismConstraint.edgesCoveredWithConstraint.Contains(context.lastHoveredEdge) && 
                    !context.lengthConstraint.edgesCoveredWithConstraint.Contains(context.lastHoveredEdge))
                {
                    Logic.PutVertexOnEdge(context.insertedVertexX, context.insertedVertexY, 
                        context.lastHoveredEdge, context.lastHoveredPolygon, context.edges, context.vertices, 
                        context.pens[(int)Enums.Pens.WHITE_PEN]);
                    Repaint();
                    return;
                }
                if (Conditions.polygonMovementMode && Conditions.polygonMovementReady)
                {
                    Logic.StopMovingAPolygon(context.polygons, context.movedPolygonVertexDiffs, ref context.clickedPolygonIndex, 
                        ref Conditions.polygonMovementReady, context.pens[(int)Enums.Pens.WHITE_PEN]);
                    Repaint();
                    return;
                }
                if (context.firstPolygonsVertex != null && InsideCircle(context.firstPolygonsVertex.X, 
                    context.firstPolygonsVertex.Y, Constants.RADIUS, e.X, e.Y) && 
                    Conditions.isPolygonInCreationProcess && Conditions.editionMode)
                {
                    Logic.FinishPolygonCreation(ref context.firstPolygonsVertex, ref context.firstPolygonIndex, context.lastPolygonIndex,
                        context.currentEdgeIndex, context.edges, context.polygons, context.vertices, 
                        context.pens[(int)Enums.Pens.WHITE_PEN], ref Conditions.isPolygonInCreationProcess, 
                        ref context.verticesCounter);
                    return;
                } 
                if (Conditions.edgeMovementMode && !Conditions.vertexMovementMode)
                {
                    Conditions.edgeMovementMode = false;
                    context.parallelismConstraint.StopRotationProcess();
                    return;
                } 
                else if(!Conditions.isPolygonInCreationProcess && !Conditions.vertexMovementMode)
                { 
                    if ((idx = IsHoverOnEdge(new Point(e.X, e.Y))) != -1)
                    {
                        Logic.StartEdgeMovement(Conditions.polygonMovementMode, ref Conditions.polygonMovementReady, 
                            ref Conditions.edgeMovementMode, context.polygons, ref context.clickedPolygonIndex,
                            idx, context.movedPolygonVertexDiffs, context.edges, ref context.movedEdge,
                            ref context.movedEdgeStartXDiff, ref context.movedEdgeStartYDiff, ref context.movedEdgeEndXDiff, 
                            ref context.movedEdgeEndYDiff, e, context.parallelismConstraint, Conditions.parallelismMode);
                        return;
                    }
                }
                if (Conditions.vertexMovementMode && !Conditions.edgeMovementMode)
                {
                    Conditions.vertexMovementMode = false;
                    context.parallelismConstraint.StopRotationProcess(); 
                    return;
                } else if(!Conditions.edgeMovementMode)
                {
                    foreach(Vertex v in context.vertices)
                    {
                        if (InsideCircle(v.X, v.Y, Constants.RADIUS, e.X, e.Y))
                        {
                            Logic.StartVertexMovement(ref Conditions.vertexMovementMode, ref Conditions.polygonMovementReady, 
                                Conditions.polygonMovementMode,
                                context.polygons, ref context.clickedPolygonIndex, ref context.movedVertex, 
                                context.movedPolygonVertexDiffs, v, e, context.parallelismConstraint);
                            return;
                        }
                    }
                }

                if (Conditions.editionMode) Conditions.isPolygonInCreationProcess = true;               
                
                if (Conditions.isPolygonInCreationProcess && Conditions.editionMode)
                {
                    Logic.AddNewVertex(ref context.verticesCounter, ref context.lastPolygonIndex, e, ref context.firstPolygonsVertex,
                        context.vertices, context.edges, context.pens[(int)Enums.Pens.SEMI_TRANSPARENT_WHITE_PEN], 
                        context.pens[(int)Enums.Pens.WHITE_PEN], ref context.currentVertexIndex, ref context.currentEdgeIndex);
                }
                Repaint();

            }
        }

        // Launches when mouse is moved
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {

            if (Conditions.isPolygonInCreationProcess)
            {
                Logic.RefreshOpaqueEdgePosition(context.edges, context.currentEdgeIndex, 
                    context.pens[(int)Enums.Pens.SEMI_TRANSPARENT_WHITE_PEN], e);
            }
            else if (Conditions.edgeMovementMode)
            {
                Logic.MoveEdge(context.vertices, context.movedEdge, context.movedEdgeStartXDiff, context.movedEdgeStartYDiff,
                    context.movedEdgeEndXDiff, context.movedEdgeEndYDiff,
                    context.parallelismConstraint, context.lengthConstraint, e, Conditions.parallelismMode, Conditions.lengthMode);
            }
            else if (Conditions.vertexMovementMode)
            {
                Logic.MoveVertex(context.movedVertex, context.parallelismConstraint, context.lengthConstraint, e);
            } else if (Conditions.polygonMovementMode && Conditions.polygonMovementReady)
            {
                Logic.MovePolygon(context.polygons, context.clickedPolygonIndex, 
                    context.pens[(int)Enums.Pens.ORANGE_PEN], context.movedPolygonVertexDiffs, e);
            } else
            {
                bool onAnyEdge, onAnyVertex;

                Logic.HandleEdgeHover(context.edges, out onAnyEdge, ref context.lastHoveredEdge, ref context.lastHoveredPolygon,
            context.polygons, ref context.insertedVertexX, ref context.insertedVertexY, Conditions.polygonMovementMode, IsOnLine,
            context.pens[(int)Enums.Pens.GREEN_PEN], context.pens[(int)Enums.Pens.WHITE_PEN], e, Constants.LINE_WIDTH);

                Logic.HandleVertexHover(context.vertices, out onAnyVertex, Conditions.polygonMovementMode, InsideCircle, e, Constants.RADIUS);

                if (onAnyEdge)
                {
                    Conditions.shallAPreviewOfVertexOnEdgeBeDrawn = true;
                }
                else
                {
                    Conditions.shallAPreviewOfVertexOnEdgeBeDrawn = false;
                }

                if (onAnyVertex || onAnyEdge)
                {
                    Conditions.hovering = true;
                }
                else
                {
                    Conditions.hovering = false;
                }
            }
            
            if (context.firstPolygonsVertex != null && InsideCircle(context.firstPolygonsVertex.X, 
                context.firstPolygonsVertex.Y, Constants.RADIUS, e.X, e.Y))
            {
                context.firstPolygonsVertex.Brush = Brushes.Red;
            }
            else if(context.firstPolygonsVertex != null)
            {
                context.firstPolygonsVertex.Brush = Brushes.White;
            }

            Repaint(e.X, e.Y);
        }

        // Launches when MovementRadioButton changes its state
        private void MovementRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MovementRadioButton.Checked)
            {
                Conditions.polygonMovementMode = true;
                if (Conditions.vertexInsertionMode)
                {
                    Conditions.vertexInsertionMode = false;
                    VertexInsertionCheckBox.Checked = false;
                }
                if (Conditions.parallelismMode)
                {
                    Conditions.parallelismMode = false;
                    ParallelismCheckBox.Checked = false;
                }

                VertexInsertionCheckBox.Enabled = false;
                ParallelismCheckBox.Enabled = false;
                LengthCheckBox.Enabled = false;

            } else
            {
                VertexInsertionCheckBox.Enabled = true;
                Conditions.polygonMovementMode = false;
            }
            Repaint();
        }

        // Launches when VertexInsertionCheckBox changes its state
        private void VertexInsertionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (VertexInsertionCheckBox.Checked)
            {
                Conditions.vertexInsertionMode = true;
                if (ParallelismCheckBox.Checked)
                {
                    ParallelismCheckBox.Checked = false;
                    Conditions.parallelismMode = false;
                }
                if (LengthCheckBox.Checked)
                {
                    LengthCheckBox.Checked = false;
                    Conditions.lengthMode = false;
                }
            } else
            {
                Conditions.vertexInsertionMode = false;
            }
            Repaint();
        }

        // Launches when ParallelismCheckBox changes its state
        private void ParallelismCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ParallelismCheckBox.Checked)
            {
                Conditions.parallelismMode = true;
                if (VertexInsertionCheckBox.Checked)
                {
                    VertexInsertionCheckBox.Checked = false;
                    Conditions.vertexInsertionMode = false;
                }
                if (LengthCheckBox.Checked)
                {
                    LengthCheckBox.Checked = false;
                    Conditions.lengthMode = false;
                }
            }
            else
            {
                Conditions.parallelismMode = false;
            }
            Repaint();
        }

        // Launches when LengthCheckBox changes its state
        private void LengthCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LengthCheckBox.Checked)
            {
                Conditions.lengthMode = true;
                if (VertexInsertionCheckBox.Checked)
                {
                    VertexInsertionCheckBox.Checked = false;
                    Conditions.vertexInsertionMode = false;
                }
                if (ParallelismCheckBox.Checked)
                {
                    ParallelismCheckBox.Checked = false;
                    Conditions.parallelismMode = false;
                }
            }
            else
            {
                Conditions.lengthMode = false;
            }
            Repaint();
        }

        // Launches when LibraryRadioButton changes its state
        private void LibraryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (LibraryRadioButton.Checked)
            {
                Conditions.drawLinesUsingLibrary = true;
            }
            else Conditions.drawLinesUsingLibrary = false;

            Repaint();
        }

        // Launches when BresenhamRadioButton changes its state
        private void BresenhamRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (BresenhamRadioButton.Checked)
            {
                Conditions.drawLinesUsingBresenham = true;
            }
            else Conditions.drawLinesUsingBresenham = false;

            Repaint();
        }
        private void XiaolinWuRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (XiaolinWuRadioButton.Checked)
            {
                Conditions.drawLinesUsingXiaolinWu = true;
            }
            else Conditions.drawLinesUsingXiaolinWu = false;

            Repaint();
        }

        // Launches when EditionRadioButton changes its state
        private void EditionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (EditionRadioButton.Checked)
            {
                VertexInsertionCheckBox.Enabled = true;
                ParallelismCheckBox.Enabled = true;
                LengthCheckBox.Enabled = true;
                Conditions.editionMode = true;
            }
            else
            {
                VertexInsertionCheckBox.Enabled = false;
                ParallelismCheckBox.Enabled = false;
                LengthCheckBox.Enabled = false;
                Conditions.editionMode = false;
            }
            Repaint();
        }

        // Launches when a key on keyboard is pressed
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete && Conditions.vertexMovementMode)
            {
                foreach(Vertex v in context.vertices)
                    if(v.StartEdge == context.movedVertex.EndEdge)
                    {
                        v.StartEdge = context.movedVertex.StartEdge;
                        break;
                    }

                context.movedVertex.StartEdge.StartVertex = context.movedVertex.EndEdge.StartVertex;
                
                if (context.parallelismConstraint.edgesCoveredWithConstraint.Contains(context.movedVertex.StartEdge))
                    context.parallelismConstraint.edgesCoveredWithConstraint.Remove(context.movedVertex.StartEdge);

                if (context.parallelismConstraint.edgesCoveredWithConstraint.Contains(context.movedVertex.EndEdge))
                    context.parallelismConstraint.edgesCoveredWithConstraint.Remove(context.movedVertex.EndEdge);
                
                if (context.lengthConstraint.edgesCoveredWithConstraint.Contains(context.movedVertex.StartEdge))
                    context.lengthConstraint.edgesCoveredWithConstraint.Remove(context.movedVertex.StartEdge);

                if (context.lengthConstraint.edgesCoveredWithConstraint.Contains(context.movedVertex.EndEdge))
                    context.lengthConstraint.edgesCoveredWithConstraint.Remove(context.movedVertex.EndEdge);

                context.movedVertex.StartEdge.Pen = context.pens[(int)Enums.Pens.WHITE_PEN];

                context.edges.Remove(context.movedVertex.EndEdge);
                context.vertices.Remove(context.movedVertex);
                context.firstPolygonIndex--;
                context.lastPolygonIndex--;
                Conditions.vertexMovementMode = false;
                Repaint();
            }
        }

    }
}