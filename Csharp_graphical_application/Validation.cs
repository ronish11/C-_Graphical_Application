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

        String[] a = { };
        /// <summary>The sobj</summary>
        Shape_Factory sobj = new Shape_Factory();


        public int x = 0, y = 0, width, height, radius;

        /// <summary>Resets this instance.</summary>
        public void reset() // moves the pen position to given x and y co-ordinate
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
        /// <param name="input">Th
        public void run_and_execute(Graphics g, string input)
        {
            /*
            string command = input.ToLower(); // Cirlce 50 = circle 50

            //drawto 50 - first element
            //circle 50 - second element
            string[] commandline = command.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            string check_speling = command.Split(' ')[0] .ToLower();

            

            string[] a = { "circle", "trangle", "moveto", "drawto", "rectangle","polygon"};
                if (!a.Contains(check_speling))
                {

                 MessageBox.Show("error");
                return;
                }
            


            for (int k = 0; k < commandline.Length; k++)
            {
                string[] cmd = commandline[k].Split(' '); //drawto - first element // 50 - second element
                if (cmd.Length != 2)
                {
                    MessageBox.Show("Incorrect Parameter");
                }
                if (cmd[0].Equals("moveto") == true) // moveto 50,60
                {
                    string[] param = cmd[1].Split(',');// 50 60

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

                    bool valid = false;
                    foreach (var item in param)
                    {

                        valid = Int32.TryParse(item, out _); //converts to integer
                    }

                    if (!valid)
                    {
                        MessageBox.Show("Error: Invalid Parameter");
                    }

                    else if (param.Length != 2)
                    {
                        MessageBox.Show("Error: parimeter on lenght & breath");

                    }                
                   
                    else
                    {
                        //validaton
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
                    string[] param = cmd[1].Split(',');
                    bool valid = false;
                    foreach (var item in param)
                    {

                        valid = Int32.TryParse(item, out _); //converts to integer
                    }

                    if (!valid)
                    {
                        MessageBox.Show("Error: Invalid Parameter");
                    }

                    else if (param.Length != 1)
                    {
                        MessageBox.Show("Error: parimeter on lenght & breath");

                    }
                    
                    else
                    {

                        Int32.TryParse(cmd[1], out radius);
                        Shape c = sobj.Getshape("circle");
                        //Circle c = new Circle();
                        c.SetParam(x, y, radius, 0);
                        c.Draw(g);
                       

                    }

                }
                else if (cmd[0].Equals("rectangle") == true)
                {

                    string[] param = cmd[1].Split(',');
                    bool valid = false;
                    foreach (var item in param)
                    {

                        valid = Int32.TryParse(item, out _); //converts to integer
                    }

                    if (!valid)
                    {
                        MessageBox.Show("Error: Invalid Parameter");
                    }

                    else if (param.Length != 2)
                    {
                        MessageBox.Show("Error: parimeter on lenght & breath");

                    }

                    else
                    {
                        Int32.TryParse(param[0], out width);
                        Int32.TryParse(param[1], out height);
                        Shape r = sobj.Getshape("rectangle");
                        //Rectangle r = new Rectangle();
                        r.SetParam(x, y, width, height);
                        r.Draw(g);
                        x += width;
                        y += height;
                    }

                    }
                
                else if (cmd[0].Equals("trangle") == true)
                {
                    string[] param = cmd[1].Split(',');
                    int toX = 0, toY = 0;

                    bool valid = false;
                    foreach (var item in param)
                    {

                        valid = Int32.TryParse(item, out _); //converts to integer
                    }

                    if (!valid)
                    {
                        MessageBox.Show("Error: Invalid Parameter");
                    }

                    else if (param.Length != 3)
                    {
                        MessageBox.Show("Error: parimeter on lenght & breath");

                    }

                    else
                    {
                        Int32.TryParse(param[0], out width);
                        Int32.TryParse(param[1], out height);
                        Shape t = sobj.Getshape("trangle");
                        //Trangle r = new Trangle();
                        t.SetParam(x, y, width, height);
                        t.Draw(g);
                        x += width;
                        y += height;
                    }

                }
                else if (cmd[0].Equals("polygon") == true)
                {

                    string[] param = cmd[1].Split(',');
                    bool valid = false;
                    foreach (var item in param)
                    {

                        valid = Int32.TryParse(item, out _); //converts to integer
                    }

                    if (!valid)
                    {
                        MessageBox.Show("Error: Invalid Parameter");
                    }

                    else if (param.Length != 12)
                    {
                        MessageBox.Show("Error: parimeter on lenght & breath");

                    }

                    else
                    {
                        Int32.TryParse(param[0], out width);
                        Int32.TryParse(param[1], out height);
                        Shape r = sobj.Getshape("polygon");
                        r.SetParam(x, y, width, height);
                        r.Draw(g);
                        x += width;
                        y += height;
                    }

                }

            }
        }
        //////
        ///
        */
        }
    }
}
               