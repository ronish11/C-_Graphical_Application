using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_graphical_application
{
    class Polygon : Shape
    {
        public int x, y, width, height;
        private object e;
        private object pictureBox1;

        public void Draw(Graphics g)
        {
            try
            {
                Pen p = new Pen(Color.Black);
                //jj
                 //new Point(y,x), , ,
                //, , };

                // draw the shading background:
                //List<Point> shadePoints = new List<Point>();
                //shadePoints.Add(new Point(0,x));
                //shadePoints.Add(new Point(22,y));
                //shadePoints.Add(new Point(33,height));

                //g.FillPolygon(Brushes.LightGray, shadePoints.ToArray());

                // scale the drawing larger:
                using (Matrix m = new Matrix())
                {
                    m.Scale(2, 2);
                    g.Transform = m;

                    List<Point> polyPoints = new List<Point>();
                    polyPoints.Add(new Point(x, y));
                    polyPoints.Add(new Point(y, width));
                    polyPoints.Add(new Point(width, height));
                    polyPoints.Add(new Point(height, x));
                    polyPoints.Add(new Point(x, width));
                    polyPoints.Add(new Point(y, height));
                    polyPoints.Add(new Point(height, y));
                    polyPoints.Add(new Point(width, y));
                    polyPoints.Add(new Point(y, x));
                    polyPoints.Add(new Point(height, width));
                    polyPoints.Add(new Point(x, height));
                    polyPoints.Add(new Point(width, x));


                    g.DrawPolygon(Pens.DarkBlue, polyPoints.ToArray());

                    foreach (Point pp in polyPoints)
                    {
                       g.FillEllipse(Brushes.Red,new RectangleF(pp.X - 2, pp.Y - 2, 4, 4));
                    }
                }

                //g.DrawPolygon(p, a);



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //Polygon 3,4,5,6,6
        public void SetParam(int x, int y, int width, int height)
        {
            try
            {
                this.x = x;
                this.y = y;
                this.width = width;
                this.height = height;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        //public void set(params int[] list)
    } 
}
