using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace assessment
{
    class tonk
    {
        // declare fields to use in the class

        public int x, y, width, height;//variables for the rectangle
        public Image Tonk;//variable for the planet's image
        public int rotationAngle;
        public Matrix matrix;
        Point centre;

        public Rectangle tonkRec;//variable for a rectangle to place our image in

        //Create a constructor (initialises the values of the fields)
        public tonk()
        {
            x = 10;
            y = 360;
            width = 40;
            height = 40;
            Tonk = Image.FromFile("tonk.png");
            tonkRec = new Rectangle(x, y, width, height);

        }
        //methods
        public void drawtonk(Graphics g)
        {
            //find the centre point of spaceRec
            centre = new Point(tonkRec.X + width / 2, tonkRec.Y + width / 2);
            //instantiate a Matrix object called matrix
            matrix = new Matrix();
            //rotate the matrix (spaceRec) about its centre
            matrix.RotateAt(rotationAngle, centre);
            //Set the current draw location to the rotated matrix point
            g.Transform = matrix;
            //draw the spaceship
            g.DrawImage(Tonk, tonkRec);
        }
        public void movetonk(int mouseX, int mouseY)//(string move)
        {

            tonkRec.X = mouseX - (tonkRec.Width / 2);
            tonkRec.Y = mouseY - (tonkRec.Height / 2);
            
            //  tonkRec.Location = new Point(x, y);

          //  if (move == "right")
          //  {
              //  if (tonkRec.Location.X > 450) // is spaceship within 50 of right side
             //   {

                //    x = 450;
               //     tonkRec.Location = new Point(x, y);
              //  }
              //  else
              //  {
             //       x += 5;
             //       tonkRec.Location = new Point(x, y);
             //   }

           // }

          //  if (move == "left")
          //  {
             //   if (tonkRec.Location.X < 10) // is spaceship within 10 of left side
              //  {

               //     x = 10;
               //     tonkRec.Location = new Point(x, y);
             //   }
               // else
               // {
                //    x -= 5;
                //    tonkRec.Location = new Point(x, y);
               // }

        }


        

    }
}