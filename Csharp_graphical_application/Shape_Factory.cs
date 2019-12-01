using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_graphical_application
{
    class Shape_Factory
    {
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
            return null;
        }
    }
}
