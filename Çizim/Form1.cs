using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Çizim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = 20.ToString();
        }
        Color renk=Color.Red;
        int kalınlık = 1;
        double değer = 0;
        int[] x = new int[3];
        int[] y = new int[3];
        int[] xx = new int[2];
        int[] yy = new int[2];

        int indis = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult basılan = cd.ShowDialog();
            if (basılan == DialogResult.OK)
            {
                renk = cd.Color;
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            kalınlık = Convert.ToInt32(numericUpDown1.Value);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            değer = Convert.ToDouble(textBox1.Text);
            Graphics çiz = panel1.CreateGraphics();
            Pen kalem = new Pen(renk, kalınlık);
            if (radioButton1.Checked == true)
            {
                çiz.DrawEllipse(kalem,(float) (e.X-(değer/2)), (float)(e.Y-(değer/2)),(float) değer,(float)değer );
            }
            if (radioButton2.Checked == true)
            {
                çiz.DrawRectangle(kalem, (float)(e.X - (değer / 2)), (float)(e.Y - (değer / 2)),(float)değer,(float)değer);
            }
           
            if (radioButton3.Checked == true)
            {
                x[indis] = e.X;
                y[indis] = e.Y;
                indis++;
                if (indis == 3)
                {
                    çiz.DrawLine(kalem,x[0], y[0], x[1], y[1]);
                    çiz.DrawLine(kalem, x[1], y[1], x[2], y[2]);
                    çiz.DrawLine(kalem, x[2], y[2], x[0], y[0]);
                    indis = 0;
                }
            }
            if (radioButton4.Checked == true)
            {
                xx[indis] = e.X;
                yy[indis] = e.Y;
                indis++;
                if (indis == 2)
                {
                    çiz.DrawLine(kalem, xx[0], yy[0], xx[1], yy[1]);
                    indis = 0;
                }
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            değer = Convert.ToDouble(textBox1.Text);
            label3.Text = e.X + "," + e.Y;
            if (radioButton5.Checked == true)
            {
                Graphics çiz = panel1.CreateGraphics();
                Pen kalem = new Pen(renk, kalınlık);
                çiz.DrawEllipse(kalem, (float)(e.X - (değer / 2)), (float)(e.Y - (değer / 2)), (float)değer, (float)değer);
            }
        }
    }
}
