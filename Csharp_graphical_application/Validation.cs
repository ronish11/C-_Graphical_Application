using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp_graphical_application
{

    public class Validation
    {
        /// <summary>The sobj</summary>
        Shape_Factory sobj = new Shape_Factory();

        public int x = 0, y = 0, width, height, radius;

        /// <summary>Resets this instance.</summary>
        public void reset()
        {
            x = 0;
            y = 0;
        }
        /// <summary>Moves to.</summary>
        /// <param name="toX">To x.</param>
        /// <param name="toY">To y.</param>
        public void MoveTo(int toX, int toY)
        {
            x = toX;
            y = toY;
        }
        /// <summary>Runs the and execute.</summary>
        /// <param name="g">The g.</param>
        /// <param name="input">The input.</param>
        public void run_and_execute(Graphics g, string input)
        {
            string command = input.ToLower();

            string[] commandline = command.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int k = 0; k < commandline.Length; k++)
            {

                string[] cmd = commandline[k].Split(' ');
                if (cmd.Length != 2)
                {
                    MessageBox.Show("Incorrect Parameter");
                }
                if (cmd[0].Equals("moveto") == true)
                {
                    string[] param = cmd[1].Split(',');

                    if (param.Length != 2)
                    {
                        MessageBox.Show("Incorrect Parameter");

                    }
                    else
                    {

                        Int32.TryParse(param[0], out x);
                        Int32.TryParse(param[1], out y);
                        MoveTo(x, y);
                    }


                }

                else if (cmd[0].Equals("drawto") == true)
                {
                    string[] param = cmd[1].Split(',');
                    int toX = 0, toY = 0;
                    if (param.Length != 2)
                    {
                        MessageBox.Show("Incorrect Parameter");

                    }
                    else
                    {
                        Int32.TryParse(param[0], out toX);
                        Int32.TryParse(param[1], out toY);
                        Shape line = sobj.Getshape("line");
                        line.SetParam(x, y, toX, toY);
                        line.Draw(g);
                        x = toX;
                        y = toY;
                    }

                }

                else if (cmd[0].Equals("circle") == true)
                {
                    if (cmd.Length != 2)
                    {
                        MessageBox.Show("Incorrect Parameter");

                    }
                    else
                    {

                        Int32.TryParse(cmd[1], out radius);
                        Shape circle = sobj.Getshape("circle");
                        Circle c = new Circle();
                        c.SetParam(x, y, radius, 0);
                        c.Draw(g);
                       

                    }

                }
                else if (cmd[0].Equals("rectangle") == true)
                {
                    if (cmd.Length < 2)
                    {
                        MessageBox.Show("Invalid Parameter ");
                    }
                    else
                    {
                        string[] param = cmd[1].Split(',');
                        if (param.Length < 2)
                        {
                            MessageBox.Show("Invalid Parameter ");
                        }
                        else
                        {
                            Int32.TryParse(param[0], out width);
                            Int32.TryParse(param[1], out height);
                            Shape circle = sobj.Getshape("rectangle");
                            Rectangle r = new Rectangle();
                            r.SetParam(x, y, width, height);
                            r.Draw(g);
                            x += width;
                            y += height;
                        }
                    }
                }
                else if (cmd[0].Equals("trangle") == true)
                {
                    string[] param = cmd[1].Split(',');
                    if (param.Length != 2)
                    {
                        MessageBox.Show("Incorrect Parameter");

                    }
                    else
                    {

                        Int32.TryParse(param[0], out width);
                        Int32.TryParse(param[1], out height);
                        Shape circle = sobj.Getshape("trangle");
                        Trangle r = new Trangle();
                        r.SetParam(x, y, width, height);
                        r.Draw(g);
                        x += width;
                        y += height;
                    }

                }

            }
        }
    }
}
               