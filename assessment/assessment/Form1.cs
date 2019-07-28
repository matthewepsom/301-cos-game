using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assessment
{
    public partial class Form1 : Form
    {
        Graphics g; //declare a graphics object called g
                    // declare space for an array of 7 objects called planet 
        ape[] ape = new ape[7];


        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 7; i++)
            {
                int x = 10 + (i * 75);
                ape[i] = new ape(x);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pnlGallery_Paint(object sender, PaintEventArgs e)
        {
            //get the graphics used to paint on the panel control
            g = e.Graphics;
            //call the Planet class's DrawPlanet method to draw the image planet1 
            for (int i = 0; i < 7; i++)
            {
                //call the Planet class's drawPlanet method to draw the images
                ape[i].drawape(g);
            }


        }

        private void tmrApe_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
               ape[i].moveape();
            }
            pnlGallery.Invalidate();//makes the paint event fire to redraw the panel
        }
    }
}
