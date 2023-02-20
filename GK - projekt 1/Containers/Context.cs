using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK___projekt_1
{
    public class Context
    {
        public int insertedVertexX;
        public int insertedVertexY;

        public Polygon? lastHoveredPolygon;
        public int clickedPolygonIndex = -1;
        public int firstPolygonIndex, lastPolygonIndex;

        public Vertex? movedVertex;
        public Vertex? firstPolygonsVertex;
        public int currentVertexIndex;
        public int verticesCounter;

        public Edge? movedEdge;
        public Edge? lastHoveredEdge;
        public int movedEdgeStartXDiff;
        public int movedEdgeStartYDiff;
        public int movedEdgeEndXDiff;
        public int movedEdgeEndYDiff;
        public int currentEdgeIndex;

        public List<Pen> pens;
        public List<Polygon> polygons;
        public List<Vertex> vertices;
        public List<Edge> edges;
        public List<Image> edgeIcons;
        public List<Point> movedPolygonVertexDiffs;

        public ParallelismConstraint parallelismConstraint;
        public LengthConstraint lengthConstraint;

        public RectangleF srcRect;
        public GraphicsUnit units;
        public Bitmap drawArea;
        public SolidBrush semiTransBrush;
        public int thickness;

        public Font font;

        public Context(PictureBox canvas)
        {
            FontFamily fontFamily = new FontFamily("Arial");
            font = new Font(
               fontFamily,
               20,
               FontStyle.Bold,
               GraphicsUnit.Pixel);
            srcRect = new RectangleF(0.0F, 0.0F, 50, 50);
            units = GraphicsUnit.Pixel;
            drawArea = new Bitmap(canvas.Size.Width, canvas.Size.Height);
            canvas.Image = drawArea;
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                g.Clear(Color.DarkBlue);
            }

            Image img0 = Image.FromFile("C:\\Users\\adria\\source\\repos\\GK - projekt 1\\GK - projekt 1\\Images\\length_blue.png");
            Image img1 = Image.FromFile("C:\\Users\\adria\\source\\repos\\GK - projekt 1\\GK - projekt 1\\Images\\length_pink.png");
            Image img2 = Image.FromFile("C:\\Users\\adria\\source\\repos\\GK - projekt 1\\GK - projekt 1\\Images\\length_red.png");
            Image img3 = Image.FromFile("C:\\Users\\adria\\source\\repos\\GK - projekt 1\\GK - projekt 1\\Images\\length_yellow.png");
            Image img4 = Image.FromFile("C:\\Users\\adria\\source\\repos\\GK - projekt 1\\GK - projekt 1\\Images\\parallel_blue.png");
            Image img5 = Image.FromFile("C:\\Users\\adria\\source\\repos\\GK - projekt 1\\GK - projekt 1\\Images\\parallel_pink.png");
            Image img6 = Image.FromFile("C:\\Users\\adria\\source\\repos\\GK - projekt 1\\GK - projekt 1\\Images\\parallel_red.png");
            Image img7 = Image.FromFile("C:\\Users\\adria\\source\\repos\\GK - projekt 1\\GK - projekt 1\\Images\\parallel_yellow.png");

            edgeIcons = new List<Image>();
            edgeIcons.Add(ResizeImage(img0, Constants.ICON_SIZE, Constants.ICON_SIZE));
            edgeIcons.Add(ResizeImage(img1, Constants.ICON_SIZE, Constants.ICON_SIZE));
            edgeIcons.Add(ResizeImage(img2, Constants.ICON_SIZE, Constants.ICON_SIZE));
            edgeIcons.Add(ResizeImage(img3, Constants.ICON_SIZE, Constants.ICON_SIZE));
            edgeIcons.Add(ResizeImage(img4, Constants.ICON_SIZE, Constants.ICON_SIZE));
            edgeIcons.Add(ResizeImage(img5, Constants.ICON_SIZE, Constants.ICON_SIZE));
            edgeIcons.Add(ResizeImage(img6, Constants.ICON_SIZE, Constants.ICON_SIZE));
            edgeIcons.Add(ResizeImage(img7, Constants.ICON_SIZE, Constants.ICON_SIZE));

            pens = new List<Pen>();
            pens.Add(new Pen(Brushes.White, Constants.LINE_WIDTH));
            pens.Add(new Pen(Brushes.Orange, Constants.LINE_WIDTH));
            pens.Add(new Pen(Brushes.GreenYellow, Constants.LINE_WIDTH));
            pens.Add(new Pen(Color.FromArgb(128, 255, 255, 255), Constants.LINE_WIDTH));

            semiTransBrush = new SolidBrush(Color.FromArgb(128, 255, 255, 255));

            parallelismConstraint = new ParallelismConstraint();
            lengthConstraint = new LengthConstraint();

            polygons = new List<Polygon>();
            edges = new List<Edge>();
            vertices = new List<Vertex>();

            insertedVertexX = -1;
            insertedVertexY = -1;
            verticesCounter = 0;
            firstPolygonsVertex = null;

            movedPolygonVertexDiffs = new List<Point>();
            firstPolygonIndex = 0;
            lastPolygonIndex = 0;
        }

        // Method ResizeImage is mainly used for resizing constraints' icons to the right size
        private static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
