using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_graphical_application
{
    /// <summary>
    ///   <para>this class is inhart from shape class</para>
    ///   <para></para>
    /// </summary>
    /// <seealso cref="Csharp_graphical_application.Shape" />
    public class Trangle : Shape
    {
        public int x, y, width, height;
        /// <summary>Draws the specified g.</summary>
        /// <param name="g">The g.</param>
        public void Draw(Graphics g)
        {
            try
            {
                Pen pen = new Pen(Color.Black);
                Point[] p = new Point[3];
                p[0].X = x;
                p[0].Y = y + height;

                p[1].X = x + width;
                p[1].Y = y + height;

                p[2].X = x+width;
                p[2].Y = y;
                g.DrawPolygon(pen, p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>Sets the parameter.</summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
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
    }
}
