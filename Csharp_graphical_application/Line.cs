using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_graphical_application
{
    public class Line : Shape
    {
        public int x, y, width, height;
        /// <summary>Draws the specified g.</summary>
        /// <param name="g">The g.</param>
        public void Draw(Graphics g)
        {
            try
            {
                Pen p = new Pen(Color.Black);
                g.DrawLine(p, x,y, width, height);
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
