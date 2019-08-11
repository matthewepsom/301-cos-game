using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace assessment
{
    class bigman

    {
        // declare fields to use in the class
        public int x, y, width, height;//variables for the rectangle
        public Image bigmanImage;//variable for the planet's image 
        public Rectangle bigmanRec;//variable for a rectangle to place our image in
        public int score;
        //Create a constructor (initialises the values of the fields)
        // Methods for the Planet class
        public void drawbigman(Graphics g)
        {
            bigmanRec = new Rectangle(x, y, width, height);
            g.DrawImage(bigmanImage, bigmanRec);

        }

        //Create a constructor (initialises the values of the fields)
        public bigman(int spacing)
        {
            x = spacing;
            y = 10;
            width = 20;
            height = 20;
            bigmanImage = Image.FromFile("monsterman.png");
            bigmanRec = new Rectangle(x, y, width, height);
        }
        public void movebigman()
        {
            y += 10;

            bigmanRec.Location = new Point(x, y);
            if (bigmanRec.Location.Y > 400)
            {
                score += 1;// add 1 to score when bigman reaches bottom of panel
                y = 20;
                bigmanRec.Location = new Point(x, y);
            }

        }

    }
}








