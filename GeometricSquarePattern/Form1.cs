using System.Drawing;
using System.Drawing.Drawing2D;


namespace GeometricSquarePattern
{
    public partial class GeometricSquare : Form
    {
        public GeometricSquare()
        {
            InitializeComponent();
        }
        // Owner from: https://youtu.be/W4yDUEpn4k4
        private void GeometricSquare_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias; // Delete bit around pixel for Up Value Smoothing!
            //Point t1, t2;

            Pen penBlack = new Pen(Color.Black, 2);
            Pen penPink = new Pen(Color.DeepPink, 2);
            Pen penRed = new Pen(Color.Red, 2);
            Pen penGreen = new Pen(Color.Green, 2);


            //graphics.DrawRectangle(pen, 50, 50, 400, 400);

            //findlinecordinates(new point(50, 50), new point(50, 450), 10, out t1);//line a-b
            //findlinecordinates(new point(50, 450), new point(450, 450), 10, out t2);//line b-c

            //graphics.drawline(pen, t1, t2);

            //findlinecordinates(new point(50, 450), new point(450, 450), 10, out t1);//line b-c
            //findlinecordinates(new point(450, 450), new point(450, 50), 10, out t2);//line c-d

            //graphics.drawline(pen, t1, t2);

            //findlinecordinates(new point(450, 450), new point(450, 50), 10, out t1);//line c-d
            //findlinecordinates(new point(450, 50), new point(50, 50), 10, out t2);//line d-a

            //graphics.drawline(pen, t1, t2);

            //findlinecordinates(new point(450, 50), new point(50, 50), 10, out t1);//line d-a
            //findlinecordinates(new point(50, 50), new point(50, 450), 10, out t2);//line a-b

            //graphics.drawline(pen, t1, t2);

            Point a = new Point(25, 25);
            int width = 400;
            int count = 28;
            int distance = 15;
            drawRectangle(a, width, distance, graphics, count, penBlack, penPink, penRed, penGreen); 
        }

        // To find the co-ordinates in a line from starting point: distance from starting point is given
        public void findLineCordinates(Point a, Point b, int distance, out Point t)
        {
            double lineLength = 0, distanceRatio = 0;
            // https://www.mathsisfun.com/quadrilaterals.html
            lineLength = Math.Sqrt( ((b.X - a.X) * (b.X - a.X)) + ((b.Y - a.Y) * (b.Y - a.Y)) );
            distanceRatio = distance / lineLength;

            t = new Point( (int) (((1 - distanceRatio) * a.X) + (distanceRatio * b.X)), (int) (((1 - distanceRatio) * a.Y) + (distanceRatio * b.Y)) );
        }

        //To draw the Reacangle/Square
        public void drawRectangle(Point a, int width, int distance, Graphics graphics, int count, Pen penBlack, Pen penPink, Pen penRed, Pen penGreen)
        {
            Point t, temp;
            Point k = new Point(a.X, a.Y);
            Point l = new Point(a.X, a.Y + width);
            Point m = new Point(a.X + width, a.Y + width);
            Point n = new Point(a.X + width, a.Y);

            //System.Threading.Thread.Sleep(sleepTime);

            // Outer Rectangle
            {
                graphics.DrawLine(penBlack, new Point(a.X, a.Y), new Point(a.X, a.Y + width));
                graphics.DrawLine(penPink, new Point(a.X, a.Y + width), new Point(a.X + width, a.Y + width));
                graphics.DrawLine(penRed, new Point(a.X + width, a.Y + width), new Point(a.X + width, a.Y));
                graphics.DrawLine(penGreen, new Point(a.X + width, a.Y), new Point(a.X, a.Y));
            }

            // Drawing Inner Rectangles...
            for (int i = 0; i < count; i++)
            {
                findLineCordinates(k, l, distance, out t);
                temp = k;
                k = t;
                findLineCordinates(l, m, distance, out t);
                l = t;
                findLineCordinates(m, n, distance, out t);
                m = t;
                findLineCordinates(n, temp, distance, out t);
                n = t;

                // Inner Rectangle
                graphics.DrawLine(penBlack, k, l);
                graphics.DrawLine(penPink, l, m);
                graphics.DrawLine(penRed, m, n);
                graphics.DrawLine(penGreen, n, k);

            }
        }
    }
}