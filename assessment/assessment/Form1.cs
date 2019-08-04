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
        Random yspeed = new Random();
        tonk tonk = new tonk();
        bool left, right;
        int score, lives;
        string move;


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
            lives = int.Parse(txtLives.Text);// pass lives entered from textbox to lives variable
            MessageBox.Show("Yikes");
            txtCallsign.Focus();

        }

        private void pnlGallery_Paint(object sender, PaintEventArgs e)
        {
            //get the graphics used to paint on the panel control
            g = e.Graphics;
            //call the Planet class's DrawPlanet method to draw the image planet1 
            for (int i = 0; i < 7; i++)
            {
                // generate a random number from 5 to 20 and put it in rndmspeed
                int rndmspeed = yspeed.Next(5, 20);
                ape[i].y += rndmspeed;

                //call the Planet class's drawPlanet method to draw the images
                ape[i].drawape(g);
            }
            tonk.drawtonk(g);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = true; }
            if (e.KeyData == Keys.Right) { right = true; }


        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = false; }
            if (e.KeyData == Keys.Right) { right = false; }

        }

        private void tmrtonk_Tick(object sender, EventArgs e)
        {
            if (right) // if right arrow key pressed
            {
                move = "right";
                tonk.movetonk(move);
            }
            if (left) // if left arrow key pressed
            {
                move = "left";
                tonk.movetonk(move);
            }

        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            score = 0;
            lblScore.Text = score.ToString();
            lives = int.Parse(txtLives.Text);// pass lives entered from textbox to lives variable
            tmrApe.Enabled = true;
            tmrtonk.Enabled = true;

        }

        private void mnuStop_Click(object sender, EventArgs e)
        {
            tmrApe.Enabled = false;
            tmrtonk.Enabled = false;

        }

        private void tmrApe_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                score += ape[i].score;// get score from Planet class (in movePlanet method)
                lblScore.Text = score.ToString();// display score
                ape[i].moveape();
                if (tonk.tonkRec.IntersectsWith(ape[i].apeRec))
                {
                    //reset tonk[i] back to top of panel
                    ape[i].y = 30; // set  y value of tonkRec
                    lives -= 1;// lose a life
                    txtLives.Text = lives.ToString();// display number of lives
                    checkLives();
                }

            }
            pnlGallery.Invalidate();//makes the paint event fire to redraw the panel
        }
        private void checkLives()
        {
            if (lives == 0)
            {
                tmrApe.Enabled = false;
                tmrtonk.Enabled = false;
                MessageBox.Show("You Failed to Defend!");

            }
        }

    }
}





































