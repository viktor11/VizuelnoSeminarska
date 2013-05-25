using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace probaOdbivanje
{
    public partial class Form1 : Form
    {
        Ball ball;
        int prevX;
        Timer timer;
        Brush boja;
        Rectangle kvadrat;
        Bitmap doublebuffer;
        Graphics graphics;
        CiglaDoc cigli, pomosna;
        Rectangle bounds;
       
       
        static readonly int BRZINA = 30; 
        

        public Form1()
        {
            InitializeComponent();
            novaIgra();
         
        }

        public  void novaIgra() {

            cigli = new CiglaDoc();
            pomosna = new CiglaDoc();
            doublebuffer = new Bitmap(Width, Height);
            graphics = CreateGraphics();
            boja = new SolidBrush(Color.Green);
            ball = new Ball(200, 200, 5,20, (float)(Math.PI / 4));
            bounds = new Rectangle(0, 0, this.Width, this.Height);
            ball.Bounds = bounds;
            kvadrat = new Rectangle(this.Width / 2 - 100, this.Height - 100, 200, 30);

            prevX = kvadrat.X + kvadrat.Width / 2;
          
            Show();

           
            iscrtaj(graphics);         
            
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000 / BRZINA;
            timer.Start();              
        }



        void timer_Tick(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(doublebuffer);
            g.Clear(Color.White);
            g.DrawRectangle(new Pen(new SolidBrush(Color.Red)), ball.Bounds);
            g.FillRectangle(new SolidBrush(Color.RoyalBlue), kvadrat);
       
            cigli.drawAll(g);
            if (gotovo())
            {
                timer.Stop();
              DialogResult result = MessageBox.Show("Играта заврши. Нова игра ?", "Нова игра ?", MessageBoxButtons.YesNo , MessageBoxIcon.Question); 
                
                if (result == DialogResult.No) 
                { Application.Exit();}
                if (result == DialogResult.Yes) {
                    novaIgra();
                }

            }
            else if (cigli.lstCigli.Count == 0)
            {
                cigli = new CiglaDoc();
                pomosna = new CiglaDoc();
                iscrtaj(g);


            }

            proverka(ball);
       
            ball.Draw(boja, g);
            ball.Move(kvadrat);
            
            graphics.DrawImageUnscaled(doublebuffer, 0, 0);
        }

        public bool gotovo() {
            bool flag = false;

            if (ball.Y + ball.Radius >= this.Height - 70 )
                flag = true;

            return flag;
        
        }

        public void iscrtaj(Graphics g)
        {

            Random rnd = new Random();

            for (int i = 5; i <= this.Width-30; i += 35)
            {
                for (int j = 0; j <= 150; j += 21)
                {

                   if (rnd.Next(10) < 6)
                    {
                        Color boja = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                        Brush b = new SolidBrush(boja);

                        Rectangle r = new Rectangle(i, j, 30, 20);
                        Cigla c = new Cigla(r, b);

                        cigli.lstCigli.Add(c);
                        pomosna.lstCigli.Add(c);
                    }
                  
                }
            }

        }


        void proverka(Ball b)
        {

            foreach (Cigla item in cigli.lstCigli)
            {
                if (item.pogodok(b))
                {
                    pomosna.brisi(item);

                }
            }
            cigli.lstCigli.Clear();
           
            foreach (Cigla item in pomosna.lstCigli)
            {
                cigli.lstCigli.Add(item);
            }
        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int dx = e.X - prevX;
            prevX = e.X;
            
            kvadrat.X += dx;

            if (kvadrat.Left < 0)
                kvadrat.X = 0;
            if (kvadrat.Right >= Width)
                kvadrat.X = Width - kvadrat.Width;

        }
    }
}







