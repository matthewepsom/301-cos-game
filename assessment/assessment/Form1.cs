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
        List<rocket> rocket = new List<rocket>();
        Graphics g; //declare a graphics object called g
                    // declare space for an array of 7 objects called planet 
        ape[] ape = new ape[7];
        bigman[] bigman = new bigman[7];
        Random yspeed = new Random();
        tonk tonk = new tonk();
        Rectangle tonkRectangle;
        bool left, right;
        int score, lives;
        string move;
        string playerCallsign;

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 7; i++)
            {
                int x = 10 + (i * 75);
                ape[i] = new ape(x);
            }
            InitializeComponent();
            for (int i = 0; i < 7; i++)
            {
                int x = 10 + (i * 75);
                bigman[i] = new bigman(x);
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
            for (int i = 0; i < 7; i++)
            {
                // generate a random number from 5 to 20 and put it in rndmspeed
                int rndmspeed = yspeed.Next(5, 20);
                bigman[i].y += rndmspeed;

                //call the Planet class's drawPlanet method to draw the images
                bigman[i].drawbigman(g);
            }
            foreach (rocket m in rocket)
            {
                m.drawrocket(g);
                m.moverocket(g);
            }

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

        private void tmrbigman_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                score += bigman[i].score;// get score from Planet class (in movePlanet method)
                lblScore.Text = score.ToString();// display score
                bigman[i].movebigman();
                if (tonk.tonkRec.IntersectsWith(bigman[i].bigmanRec))
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

        private void pnlGallery_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                rocket.Add(new rocket(tonk.tonkRec, 270)); // creates a new bullet which is fired from the f14 when ever it is clicked
            }
        }

        private void tmrShoot_Tick(object sender, EventArgs e)
        {
            foreach (ape p in ape) // when u shoot a helo
            {

                foreach (rocket m in rocket)
                {
                    if (p.apeRec.IntersectsWith(m.rocketRec))
                    {
                        score += 1; // adds a 1 score when bullet hits helo
                        p.x = -20;// relocate enemy to the left side of the panel
                        rocket.Remove(m); // removes bullet when in contact with helo
                        break;
                    }
                }
                foreach (bigman p in bigman) // when u shoot a helo
                {

                    foreach (rocket m in rocket)
                    {
                        if (p.bigmanRec.IntersectsWith(m.rocketRec))
                        {
                            score += 1; // adds a 1 score when bullet hits helo
                            p.x = -20;// relocate enemy to the left side of the panel
                            rocket.Remove(m); // removes bullet when in contact with helo
                            break;
                        }
                    }

                }
            }
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
        private void checkScorelv2() // checks the score and if it is at a certian score or above it increases the timers speed/intervals
        {
            for (int i = 0; i < 7; i++)
            {
                if (score >= 10 && score < 20) // if the score is greater than 10 and left than 20 this class will speed up
                {
                    LblMessage.Text = "Level 2"; // displays and says what level you are one

                    ape[i].x += 5; //  the speed will increase to this
                }
            }
        }
    }
}





































