using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_graphical_application
{
    class Shape_Factory
    {
        /// <summary>Getshapes the specified shape type.</summary>
        /// <param name="shapeType">Type of the shape.</param>
        /// <returns></returns>
        public Shape Getshape(String shapeType)
        {
            shapeType = shapeType.ToUpper().Trim();

            if (shapeType == null)
            {
                return null;
            }
            else if (shapeType.Equals("LINE"))
            {
                return new Line();
            }
            else if (shapeType.Equals("CIRCLE"))
            {
                return new Circle();

            }
            else if (shapeType.Equals("RECTANGLE"))
            {
                return new Rectangle();

            }
            else if (shapeType.Equals("TRANGLE"))
            {
                return new Trangle();
            }
            else if(shapeType.Equals("POLYGON"))
            {
                return new Polygon();
            }
            return null;
        }
    }
}
