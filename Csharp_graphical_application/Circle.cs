using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_graphical_application
{
    public class Circle : Shape
    {
        public int x, y, radius;
        /// <summary>Draws the specified g.</summary>
        /// <param name="g">The g.</param>
        public void Draw(Graphics g)
        {
            try
            {
                Pen p = new Pen(Color.Black);
                g.DrawEllipse(p, x, y, radius*2, radius*2);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>Sets the parameter.</summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="_">The .</param>
        public void SetParam(int x, int y, int radius, int _)
        {
            try
            {
                this.x = x;
                this.y = y;
                this.radius = radius;
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
