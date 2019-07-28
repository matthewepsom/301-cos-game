using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace assessment
{
    class ape
    {
        // declare fields to use in the class
        public int x, y, width, height;//variables for the rectangle
        public Image apeImage;//variable for the planet's image 
        public Rectangle apeRec;//variable for a rectangle to place our image in
        public int score;
        //Create a constructor (initialises the values of the fields)
        // Methods for the Planet class
        public void drawape(Graphics g)
        {
            apeRec = new Rectangle(x, y, width, height);
            g.DrawImage(apeImage, apeRec);
            
        }

        //Create a constructor (initialises the values of the fields)
        public ape(int spacing)
        {
            x = spacing;
            y = 10;
            width = 20;
            height = 20;
            apeImage = Image.FromFile("tasty.png");
            apeRec = new Rectangle(x, y, width, height);
        }
        public void moveape()
        {
            y += 5;

            apeRec.Location = new Point(x, y);
        }

    }
}

