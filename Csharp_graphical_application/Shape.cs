using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_graphical_application
{
    interface Shape
    {
        void Draw(Graphics g);
        void SetParam(int x, int y, int width, int height); // add color 
    }
}
