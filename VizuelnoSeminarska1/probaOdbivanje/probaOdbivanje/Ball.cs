using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace probaOdbivanje
{
    class Ball
    {
        public float X { get; set; } 
        public float Y { get; set; }
        public float Radius { get; set; }
        public float Velocity { get; set; }
        public float Angle { get; set; }
        public Rectangle Bounds;
        public float velocityX { get; set; }
        public float velocityY {get;set;}

        double direction = 0;
        
        public double Direction
        {
            get
            {
                return direction;
            }
            set
            {
                direction = value;
                direction = direction % (Math.PI * 2.0);
                while (direction < 0)
                    direction += Math.PI * 2;
            }
        }


        public Ball(float x, float y, float radius, float velocity, float angle) 
        {   
            X = x;
            Y = y;
            Radius = radius;
            Velocity = velocity; 
            Angle = angle;
            velocityX = (float)Math.Cos(Angle) * Velocity;
            velocityY = (float)Math.Sin(Angle) * Velocity; 
        }

      
        public void Move(Rectangle r) { 
          
            float nextX = X + velocityX; 
            float nextY = Y + velocityY; 
            
            if (nextX - Radius <= Bounds.Left || (nextX + Radius >= Bounds.Right))
            { velocityX = -velocityX; } 
            
            if (nextY - Radius <= Bounds.Top || (nextY + Radius >= Bounds.Bottom))
            { velocityY = -velocityY; }
       

             if (nextY + Radius >= r.Top && nextY + Radius <= r.Bottom - Radius && nextX >= r.Left - Radius && nextX <= r.Right + Radius)
            {
              velocityY = -velocityY;
                
            }

            else if (nextY - Radius <= r.Bottom && nextY - Radius >= r.Top + Radius && nextX >= r.Left - Radius && nextX <= r.Right + Radius)
            {
               
                velocityY = -velocityY;
               
            }
              if ( nextX + Radius >= r.Left  && nextX + Radius <= r.Left + Radius &&nextY >= r.Top - Radius && nextY <= r.Bottom + Radius)
              {  
                 
                 velocityY = -velocityY;
                  velocityX =  -velocityX;
              }

          else if (nextX - Radius<= r.Right && nextX - Radius  >= r.Right - Radius && nextY >= r.Top - Radius && nextY <= r.Bottom + Radius)
              {
                
                  velocityY = -velocityY;
                  velocityX = -velocityX;
     
              }
          
            X += velocityX;
            Y += velocityY;
           
        }

        public void Draw(Brush brush, Graphics g)
        { 
            g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2); 
        }

    
    }
}
