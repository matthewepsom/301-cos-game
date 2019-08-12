using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace assessment
{
    class rocket
    {
        public int x, y, width, height;
        public int rocketRotated;
        public double xSpeed, ySpeed;
        public Image Rocket;//variable for the bullets image
        public Rectangle rocketRec;//variable for a rectangle to place our image in
        public Matrix matrixrocket;//matrix to enable us to rotate bullet in the same angle as the f14
        Point centrerocket;//centre of bullet
                           // in the following constructor we pass in the values of f14Rec and the rotation angle of the f14
                           // this gives us the position of the f14 which we can then use to place the

        //bullet where the f14 is located and at the correct angl


        public rocket(Rectangle tonkRec, int rocketRotate)
        {
            width = 20; // width of bullet
            height = 30; // height of bullet
            Rocket = Image.FromFile("rocket.png"); // image location and file 
            rocketRec = new Rectangle(x, y, width, height);

            //this code works out the speed of the bullet to be used in the movebullet method
            xSpeed = 30 * (Math.Cos((rocketRotate - 90) * Math.PI / 180));
            ySpeed = 30 * (Math.Sin((rocketRotate + 90) * Math.PI / 180));
            //calculate x,y to move bullet to middle of f14 in drawbullet method
            x = rocketRec.X + rocketRec.Width / 2;
            y = rocketRec.Y + rocketRec.Height / 2;
            //pass bulletRotate angle to bulletRotated so that it can be used in the drawbullet method
            rocketRotated = rocketRotate;

        }



        public void drawBullet(Graphics g)
        {
            //centre bullet
            centrerocket = new Point(x, y);
            //instantiate a Matrix object called matrixbullet
            matrixrocket = new Matrix();
            //rotate the matrix (in this case bulletRec) about its centre
            matrixrocket.RotateAt(rocketRotated, centrerocket);
            //Set the current draw location to the rotated matrix point i.e. where bulletRec is now
            g.Transform = matrixrocket;
            //Draw the bullet
            g.DrawImage(Rocket, rocketRec);

        }
        public void moverocket(Graphics g)
        {
            x += (int)xSpeed;//cast double to an integer value
            y -= (int)ySpeed;
            rocketRec.Location = new Point(x, y);//bullet new location
        }

    }

}


