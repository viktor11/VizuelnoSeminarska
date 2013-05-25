using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace probaOdbivanje
{
    class Cigla
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Brush boja;
        public Rectangle forma;


        public Cigla(int x, int y, Brush b)
        {
            X = x;
            Y = y;
            boja = b;

        }

        public Cigla(Rectangle r, Brush b)
        {
            forma = r;
            boja = b;
        }

        public void draw(Graphics g)
        {

            g.FillRectangle(boja, forma.X, forma.Y, forma.Width, forma.Height);
            //g.Dispose();
           
        }

        public bool pogodok(Ball topka)
        {
  
            if (topka.Y + topka.Radius >= forma.Top && topka.Y + topka.Radius <= forma.Bottom - topka.Radius && topka.X >= forma.Left - topka.Radius && topka.X <= forma.Right + topka.Radius)
            {
                topka.velocityY = -topka.velocityY;
                return true;
            }

            else if (topka.Y - topka.Radius <= forma.Bottom && topka.Y - topka.Radius >= forma.Top + topka.Radius && topka.X >= forma.Left - topka.Radius && topka.X <= forma.Right + topka.Radius)
            {
                topka.velocityY = -topka.velocityY;
                return true;
            }

            else if (topka.X + topka.Radius >= forma.Left && topka.X + topka.Radius <= forma.Left + topka.Radius && topka.Y >= forma.Top - topka.Radius && topka.Y <= forma.Bottom + topka.Radius)
            {
                topka.velocityY = -topka.velocityY;
                topka.velocityX = -topka.velocityX;
                return true;
            }

            else if (topka.X - topka.Radius <= forma.Right && topka.X - topka.Radius >= forma.Right - topka.Radius && topka.Y >= forma.Top - topka.Radius && topka.Y <= forma.Bottom + topka.Radius)
            {
                topka.velocityY = -topka.velocityY;
                topka.velocityX = -topka.velocityX;
                return true;
            }
             
            return false;

        }

    }

}
