using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp_graphical_application
{
    public partial class Form1 : Form
    {
        Graphics g;
        Validation vobj = new Validation();
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        //one
        /// <summary>
        /// variable to create triangle side
        /// </summary>
        Color btnBorderColor = Color.FromArgb(104, 162, 255);
        Color mainColor = Color.Red;
        int size = 2;
        
        int x, y = -1;
        int mouseX, mouseY = 0;
        Boolean moving = false;
        Pen pen;
        String active = "pen";
        OpenFileDialog openFile = new OpenFileDialog();
        String line = "";
        Validation1 validate;
        int loopCounter = 0;
        Boolean hasDrawOrMoveValue = false;

        public int radius = 0;
        public int width = 0;
        public int height = 0;
        public int dSize = 0;
        public int counter = 0;

        string shape;
        Shape_Factory shapeFactory = new Shape_Factory();
        Shape shapes;


        public int _size1, _size2, _size3, _size4, _size5, _size6, _size7, _size8, _size9, _size10, _size11, _size12;

        private void btn_exec_Click(object sender, EventArgs e)
        {
            hasDrawOrMoveValue = false;
            if (multiline.Text != null && multiline.Text != "")
            {
                validate = new Validation1(multiline);
                if (!validate.isSomethingInvalid)
                {
                    MessageBox.Show("Everything looks good:Enjoy");
                    loadCommand();
                }

            }

        }
        private void loadCommand()
        {
            int numberOfLines = multiline.Lines.Length;

            for (int i = 0; i < numberOfLines; i++)
            {
                String oneLineCommand = multiline.Lines[i];
                oneLineCommand = oneLineCommand.Trim();
                if (!oneLineCommand.Equals(""))
                {
                    Boolean hasDrawto = Regex.IsMatch(oneLineCommand.ToLower(), @"\bdrawto\b");
                    Boolean hasMoveto = Regex.IsMatch(oneLineCommand.ToLower(), @"\bmoveto\b");
                    if (hasDrawto || hasMoveto)
                    {
                        String args = oneLineCommand.Substring(6, (oneLineCommand.Length - 6));
                        String[] parms = args.Split(',');
                        for (int j = 0; j < parms.Length; j++)
                        {
                            parms[j] = parms[j].Trim();
                        }
                        mouseX = int.Parse(parms[0]);
                        mouseY = int.Parse(parms[1]);
                        hasDrawOrMoveValue = true;
                    }
                    else
                    {
                        hasDrawOrMoveValue = false;
                    }
                    if (hasMoveto)
                    {
                        panel1.Refresh();
                    }
                }
            }

            for (loopCounter = 0; loopCounter < numberOfLines; loopCounter++)
            {
                String oneLineCommand = multiline.Lines[loopCounter];
                oneLineCommand = oneLineCommand.Trim();
                if (!oneLineCommand.Equals(""))
                {
                    RunCommand(oneLineCommand);
                }

            }
        }
        /**
		 * The code are executed when the button is clicked
		 */
        private void RunCommand(String oneLineCommand)
        {

            Boolean hasPlus = oneLineCommand.Contains('+');
            Boolean hasEquals = oneLineCommand.Contains("=");
            if (hasEquals)
            {
                oneLineCommand = Regex.Replace(oneLineCommand, @"\s+", " ");
                string[] words = oneLineCommand.Split(' ');
                //removing white spaces in between words
                for (int i = 0; i < words.Length; i++)
                {
                    words[i] = words[i].Trim();
                }
                String firstWord = words[0].ToLower();
                if (firstWord.Equals("if"))
                {
                    Boolean loop = false;
                    if (words[1].ToLower().Equals("radius"))
                    {
                        if (radius == int.Parse(words[3]))
                        {
                            loop = true;
                        }
                    }
                    else if (words[1].ToLower().Equals("width"))
                    {
                        if (width == int.Parse(words[3]))
                        {
                            loop = true;
                        }
                    }
                    else if (words[1].ToLower().Equals("height"))
                    {
                        if (height == int.Parse(words[3]))
                        {
                            loop = true;
                        }

                    }
                    else if (words[1].ToLower().Equals("counter"))
                    {
                        if (counter == int.Parse(words[3]))
                        {
                            loop = true;
                        }
                    }
                    int ifStartLine = (GetIfStartLineNumber());
                    int ifEndLine = (GetEndifEndLineNumber() - 1);

                    loopCounter = ifEndLine;
                    if (loop)
                    {
                        for (int j = ifStartLine; j <= ifEndLine; j++)
                        {
                            string oneLineCommand1 = multiline.Lines[j];
                            oneLineCommand1 = oneLineCommand1.Trim();
                            if (!oneLineCommand1.Equals(""))
                            {
                                RunCommand(oneLineCommand1);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("If Statement is false");
                    }
                }
                else
                {
                    string[] words2 = oneLineCommand.Split('=');
                    for (int j = 0; j < words2.Length; j++)
                    {
                        words2[j] = words2[j].Trim();
                    }
                    if (words2[0].ToLower().Equals("radius"))
                    {
                        radius = int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("width"))
                    {
                        width = int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("height"))
                    {
                        height = int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("counter"))
                    {
                        counter = int.Parse(words2[1]);
                    }
                }
            }
            else if (hasPlus)
            {
                oneLineCommand = System.Text.RegularExpressions.Regex.Replace(oneLineCommand, @"\s+", " ");
                string[] words = oneLineCommand.Split(' ');
                if (words[0].ToLower().Equals("repeat"))
                {
                    counter = int.Parse(words[1]);
                    if (words[2].ToLower().Equals("circle"))
                    {
                        int increaseValue = GetSize(oneLineCommand);
                        radius = increaseValue;
                        for (int j = 0; j < counter; j++)
                        {
                            DrawCircle(radius);
                            radius += increaseValue;
                        }
                    }
                    else if (words[2].ToLower().Equals("rectangle"))
                    {
                        int increaseValue = GetSize(oneLineCommand);
                        dSize = increaseValue;
                        for (int j = 0; j < counter; j++)
                        {
                            DrawRectangle(dSize, dSize);
                            dSize += increaseValue;
                        }
                    }
                    else if (words[2].ToLower().Equals("triangle"))
                    {
                        int increaseValue = GetSize(oneLineCommand);
                        dSize = increaseValue;
                        for (int j = 0; j < counter; j++)
                        {
                            DrawTriangle(dSize, dSize, dSize);
                            dSize += increaseValue;
                        }
                    }
                }
                else
                {
                    string[] words2 = oneLineCommand.Split('+');
                    for (int j = 0; j < words2.Length; j++)
                    {
                        words2[j] = words2[j].Trim();
                    }
                    if (words2[0].ToLower().Equals("radius"))
                    {
                        radius += int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("width"))
                    {
                        width += int.Parse(words2[1]);
                    }
                    else if (words2[0].ToLower().Equals("height"))
                    {
                        height += int.Parse(words2[1]);
                    }
                }
            }
            else
            {
                sendDrawCommand(oneLineCommand);
            }


        }
        /// <summary>
		/// Returns the size of structure
		/// </summary>
		/// <param name="lineCommand"></param>
		/// <returns></returns>
        private int GetSize(string lineCommand)
        {
            int value = 0;
            if (lineCommand.ToLower().Contains("radius"))
            {
                int pos = (lineCommand.IndexOf("radius") + 6);
                int size = lineCommand.Length;
                String tempLine = lineCommand.Substring(pos, (size - pos));
                tempLine = tempLine.Trim();
                String newTempLine = tempLine.Substring(1, (tempLine.Length - 1));
                newTempLine = newTempLine.Trim();
                value = int.Parse(newTempLine);

            }
            else if (lineCommand.ToLower().Contains("size"))
            {
                int pos = (lineCommand.IndexOf("size") + 4);
                int size = lineCommand.Length;
                String tempLine = lineCommand.Substring(pos, (size - pos));
                tempLine = tempLine.Trim();
                String newTempLine = tempLine.Substring(1, (tempLine.Length - 1));
                newTempLine = newTempLine.Trim();
                value = int.Parse(newTempLine);
            }
            return value;
        }
        /**
		 *  Initiate shapes and figure to build shapes
		 */
        private void sendDrawCommand(string lineOfCommand)
        {
            String[] shapes = { "circle", "rectangle", "triangle", "polygon" };
            String[] variable = { "radius", "width", "height", "counter", "size" };

            lineOfCommand = System.Text.RegularExpressions.Regex.Replace(lineOfCommand, @"\s+", " ");
            string[] words = lineOfCommand.Split(' ');
            //removing white spaces in between words
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim();
            }
            String firstWord = words[0].ToLower();
            Boolean firstWordShape = shapes.Contains(firstWord);
            if (firstWordShape)
            {

                if (firstWord.Equals("circle"))
                {
                    Boolean secondWordIsVariable = variable.Contains(words[1].ToLower());
                    if (secondWordIsVariable)
                    {
                        if (words[1].ToLower().Equals("radius"))
                        {
                            DrawCircle(radius);
                        }
                    }
                    else
                    {
                        DrawCircle(Int32.Parse(words[1]));
                    }

                }
                else if (firstWord.Equals("rectangle"))
                {
                    String args = lineOfCommand.Substring(9, (lineOfCommand.Length - 9));
                    String[] parms = args.Split(',');
                    for (int i = 0; i < parms.Length; i++)
                    {
                        parms[i] = parms[i].Trim();
                    }
                    Boolean secondWordIsVariable = variable.Contains(parms[0].ToLower());
                    Boolean thirdWordIsVariable = variable.Contains(parms[1].ToLower());
                    if (secondWordIsVariable)
                    {
                        if (thirdWordIsVariable)
                        {
                            DrawRectangle(width, height);
                        }
                        else
                        {
                            DrawRectangle(width, Int32.Parse(parms[1]));
                        }

                    }
                    else
                    {
                        if (thirdWordIsVariable)
                        {
                            DrawRectangle(Int32.Parse(parms[0]), height);
                        }
                        else
                        {
                            DrawRectangle(Int32.Parse(parms[0]), Int32.Parse(parms[1]));
                        }
                    }
                }
                else if (firstWord.Equals("triangle"))
                {
                    String args = lineOfCommand.Substring(8, (lineOfCommand.Length - 8));
                    String[] parms = args.Split(',');
                    for (int i = 0; i < parms.Length; i++)
                    {
                        parms[i] = parms[i].Trim();
                    }
                    DrawTriangle(Int32.Parse(parms[0]), Int32.Parse(parms[1]), Int32.Parse(parms[2]));
                }
                else if (firstWord.Equals("polygon"))
                {
                    String args = lineOfCommand.Substring(8, (lineOfCommand.Length - 8));
                    String[] parms = args.Split(',');
                    for (int i = 0; i < parms.Length; i++)
                    {
                        parms[i] = parms[i].Trim();
                    }
                    if (parms.Length == 8)
                    {
                        DrawPolygon(Int32.Parse(parms[0]), Int32.Parse(parms[1]), Int32.Parse(parms[2]), Int32.Parse(parms[3]),
                            Int32.Parse(parms[4]), Int32.Parse(parms[5]), Int32.Parse(parms[6]), Int32.Parse(parms[7]));
                    }
                    else if (parms.Length == 10)
                    {
                        DrawPolygon(Int32.Parse(parms[0]), Int32.Parse(parms[1]), Int32.Parse(parms[2]), Int32.Parse(parms[3]),
                            Int32.Parse(parms[4]), Int32.Parse(parms[5]), Int32.Parse(parms[6]), Int32.Parse(parms[7]),
                            Int32.Parse(parms[8]), Int32.Parse(parms[9]));
                    }

                }

            }
            else
            {
                if (firstWord.Equals("loop"))
                {
                    counter = int.Parse(words[1]);
                    int loopStartLine = (GetLoopStartLineNumber());
                    int loopEndLine = (GetLoopEndLineNumber() - 1);
                    loopCounter = loopEndLine;
                    for (int i = 0; i < counter; i++)
                    {
                        for (int j = loopStartLine; j <= loopEndLine; j++)
                        {
                            String oneLineCommand = multiline.Lines[j];
                            oneLineCommand = oneLineCommand.Trim();
                            if (!oneLineCommand.Equals(""))
                            {
                                RunCommand(oneLineCommand);
                            }
                        }
                    }
                }
                else if (firstWord.Equals("if"))
                {
                    Boolean loop = false;
                    if (words[1].ToLower().Equals("radius"))
                    {
                        if (radius == int.Parse(words[1]))
                        {
                            loop = true;
                        }
                    }
                    else if (words[1].ToLower().Equals("width"))
                    {
                        if (width == int.Parse(words[1]))
                        {
                            loop = true;
                        }
                    }
                    else if (words[1].ToLower().Equals("height"))
                    {
                        if (height == int.Parse(words[1]))
                        {
                            loop = true;
                        }

                    }
                    else if (words[1].ToLower().Equals("counter"))
                    {
                        if (counter == int.Parse(words[1]))
                        {
                            loop = true;
                        }
                    }
                    int ifStartLine = (GetIfStartLineNumber());
                    int ifEndLine = (GetEndifEndLineNumber() - 1);
                    loopCounter = ifEndLine;
                    if (loop)
                    {
                        for (int j = ifStartLine; j <= ifEndLine; j++)
                        {
                            String oneLineCommand = multiline.Lines[j];
                            oneLineCommand = oneLineCommand.Trim();
                            if (!oneLineCommand.Equals(""))
                            {
                                RunCommand(oneLineCommand);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
		/// initiates loop 
		/// </summary>
		/// <returns></returns>
        private int GetEndifEndLineNumber()
        {
            int numberOfLines = multiline.Lines.Length;
            int lineNum = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                String oneLineCommand = multiline.Lines[i];
                oneLineCommand = oneLineCommand.Trim();
                if (oneLineCommand.ToLower().Equals("endif"))
                {
                    lineNum = i + 1;

                }
            }
            return lineNum;
        }
        /// <summary>
		/// initiates if there is an if clause
		/// </summary>
		/// <returns></returns>
        private int GetIfStartLineNumber()
        {
            int numberOfLines = multiline.Lines.Length;
            int lineNum = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                String oneLineCommand = multiline.Lines[i];
                oneLineCommand = Regex.Replace(oneLineCommand, @"\s+", " ");
                string[] words = oneLineCommand.Split(' ');
                //removing white spaces in between words
                for (int j = 0; j < words.Length; j++)
                {
                    words[j] = words[j].Trim();
                }
                String firstWord = words[0].ToLower();
                oneLineCommand = oneLineCommand.Trim();
                if (firstWord.Equals("if"))
                {
                    lineNum = i + 1;

                }
            }
            return lineNum;
        }
        /// <summary>
		/// Initiates loops
		/// </summary>
		/// <returns></returns>
        private int GetLoopEndLineNumber()
        {
            try
            {
                int numberOfLines = multiline.Lines.Length;
                int lineNum = 0;

                for (int i = 0; i < numberOfLines; i++)
                {
                    String oneLineCommand = multiline.Lines[i];
                    oneLineCommand = oneLineCommand.Trim();
                    if (oneLineCommand.ToLower().Equals("endloop"))
                    {
                        lineNum = i + 1;

                    }
                }
                return lineNum;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        private int GetLoopStartLineNumber()
        {
            int numberOfLines = multiline.Lines.Length;
            int lineNum = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                String oneLineCommand = multiline.Lines[i];
                oneLineCommand = Regex.Replace(oneLineCommand, @"\s+", " ");
                string[] words = oneLineCommand.Split(' ');
                //removing white spaces in between words
                for (int j = 0; j < words.Length; j++)
                {
                    words[j] = words[j].Trim();
                }
                String firstWord = words[0].ToLower();
                oneLineCommand = oneLineCommand.Trim();
                if (firstWord.Equals("loop"))
                {
                    lineNum = i + 1;

                }
            }
            return lineNum;

        }
        private void DrawPolygon(int v1, int v2, int v3, int v4, int v5, int v6, int v7, int v8)
        {
            Pen myPen = new Pen(mainColor);
            Point[] pnt = new Point[5];

            pnt[0].X = mouseX;
            pnt[0].Y = mouseY;

            pnt[1].X = mouseX - v1;
            pnt[1].Y = mouseY - v2;

            pnt[2].X = mouseX - v3;
            pnt[2].Y = mouseY - v4;

            pnt[3].X = mouseX - v5;
            pnt[3].Y = mouseY - v6;

            pnt[4].X = mouseX - v7;
            pnt[4].Y = mouseY - v8;

            g.DrawPolygon(myPen, pnt);
        }
        /**
		 * Draw Polygon
		 */
        private void DrawPolygon(int v1, int v2, int v3, int v4, int v5, int v6, int v7, int v8, int v9, int v10)
        {
            Pen myPen = new Pen(mainColor);
            Point[] pnt = new Point[6];

            pnt[0].X = mouseX;
            pnt[0].Y = mouseY;

            pnt[1].X = mouseX - v1;
            pnt[1].Y = mouseY - v2;

            pnt[2].X = mouseX - v3;
            pnt[2].Y = mouseY - v4;

            pnt[3].X = mouseX - v5;
            pnt[3].Y = mouseY - v6;

            pnt[4].X = mouseX - v7;
            pnt[4].Y = mouseY - v8;

            pnt[5].X = mouseX - v9;
            pnt[5].Y = mouseY - v10;
            g.DrawPolygon(myPen, pnt);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        /**
* Draws a triangle 
*/
        private void DrawTriangle(int rBase, int adj, int hyp)
        {
            g = panel1.CreateGraphics();
            Pen myPen = new Pen(mainColor);
            Point[] pnt = new Point[3];

            pnt[0].X = mouseX;
            pnt[0].Y = mouseY;

            pnt[1].X = mouseX - rBase;
            pnt[1].Y = mouseY;

            pnt[2].X = mouseX;
            pnt[2].Y = mouseY - adj;
            g.DrawPolygon(myPen, pnt);
        }

        private void DrawRectangle(int width, int height)
        {
            g = panel1.CreateGraphics();
            Pen myPen = new Pen(mainColor);
            g.DrawRectangle(myPen, mouseX - (width / 2), mouseY - (height / 2), width, height);
        }


        private void DrawCircle(int radius)
        {
            g = panel1.CreateGraphics();
            Pen myPen = new Pen(mainColor);
            g.DrawEllipse(myPen, mouseX - radius, mouseY - radius, radius * 2, radius * 2);
        }
        //one
        private void button1_Click(object sender, EventArgs e)
        {
            vobj.run_and_execute(g, textBox1.Text);
        }

        /// <summary>Handles the Click event of the aboutToolStripMenuItem control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("GRAPHIHCAL PROGRAMMING APPLICATION \n YAGYA RAJ SHARMA \n Copyright (c) 2019-2020 ALL RIGHTS RESERVED");

        }

        /// <summary>Handles the Click event of the saveToolStripMenuItem control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sf = new SaveFileDialog()
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            })
            {
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    using (Stream s = File.Open(sf.FileName, FileMode.CreateNew))
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.Write(multiline.Text);
                    }
                }
            }
        }

        /// <summary>Handles the Click event of the loadsToolStripMenuItem control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void loadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                // add open file dialog filter
                if (of.ShowDialog() == DialogResult.OK)
                {
                    var fileName = of.FileName;
                    var fileContent = File.ReadAllText(fileName);
                    multiline.Text = fileContent;
                }
            }
        }

        /// <summary>Handles the Click event of the button4 control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button4_Click(object sender, EventArgs e)
        {

            hasDrawOrMoveValue = false;
            if (multiline.Text != null && multiline.Text != "")
            {
                validate = new Validation1(multiline);
                if (!validate.isSomethingInvalid)
                {
                    MessageBox.Show("Everything looks good:Enjoy");
                    loadCommand();
                }

            }
            int count = multiline.Lines.Count();
            //foreach (var lines in multiline.Lines)
            //{
                vobj.run_and_execute(g, multiline.Text);
            //}
        }

        /// <summary>Handles the Click event of the button2 control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            
        }

        /// <summary>Handles the Click event of the button3 control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void reset(object sender, EventArgs e)
        {
            vobj.reset();
        }

        /// <summary>Handles the Click event of the button5 control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void clear(object sender, EventArgs e)
        {
            multiline.Clear();
            textBox1.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
