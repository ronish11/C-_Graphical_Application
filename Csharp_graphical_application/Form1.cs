using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
    }
}
