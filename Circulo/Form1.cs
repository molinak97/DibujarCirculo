using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Circulo
{
    public partial class Form1 : Form
    {
        int p = 0;//contador puntos
        int Xc = 0;
        int Yc = 0;
        int Xr = 0;
        int Yr = 0;
        double r = 0;
        double a = 0;
        double b = 0;

        Pen pen = new Pen(Color.Green, 3);//DDA
        Pen pen1 = new Pen(Color.Red, 3);//MDP
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            p++;
            int x, y;
            x = e.X;
            y = e.Y;
            panel1.CreateGraphics().DrawEllipse(pen, x, y, 5, 5);
            if(p - 1 == 0)
            {
                Xc = x;
                Yc = y;
            }
            else if(p - 2 == 0)
            {
                Xr = x;
                Yr = y;
                CirculoDDA(Xc, Yc, Xr, Yr);
                CirculoMDP(Xc, Yc, Xr, Yr);
                p = 0;
            }

        }
        private void CirculoDDA(int Xc, int Yc, int Xr, int Yr)
        {

            double Yk=10;
            int y;
            a = (Yr - Yc);
            b = (Xr - Xc);
            a = Math.Pow(a, 2);
            b = Math.Pow(b, 2);
            r = Math.Sqrt(Math.Abs(a) + Math.Abs(b));//Math.Pow(variable,potencia)
            for (int Xk=0; Xk<Yk; Xk++)
            {

                Yk = Math.Sqrt(Math.Pow(r, 2)- Math.Pow(Xk, 2));

                panel1.CreateGraphics().DrawEllipse(pen, Convert.ToInt64(Yk) + Xc, Xk + Yc, 5, 5);//(y,x)           8 Octante
                panel1.CreateGraphics().DrawEllipse(pen, Xk + Xc, Convert.ToInt64(Yk) + Yc, 5, 5);//(x,y)           7 Octante
                panel1.CreateGraphics().DrawEllipse(pen, -(Xk)+Xc, Convert.ToInt64(Yk) + Yc, 5, 5);//(-x,y)         6 Octante
                panel1.CreateGraphics().DrawEllipse(pen, -(Convert.ToInt64(Yk)) + Xc , Xk + Yc, 5, 5);//(-y,x)      5 Octante
                panel1.CreateGraphics().DrawEllipse(pen, -(Convert.ToInt64(Yk)) + Xc, -(Xk) + Yc, 5, 5);//(-y,-x)   4 Octante
                panel1.CreateGraphics().DrawEllipse(pen, -(Xk) + Xc, -(Convert.ToInt64(Yk)) + Yc, 5, 5);//(-x,-y)   3 Octante
                panel1.CreateGraphics().DrawEllipse(pen, Xk + Xc , -(Convert.ToInt64(Yk)) + Yc, 5, 5);//(x,-y)      2 Octante
                panel1.CreateGraphics().DrawEllipse(pen, Convert.ToInt64(Yk) + Xc, -(Xk) + Yc, 5, 5);//(y,-x)       1 Octante
            }
        }
        private void CirculoMDP(int Xc, int Yc, int Xr, int Yr)
        {
            double x;
            int y = 0;
            int e = 0;
            x = r;
            while(y<=x)
            {
                panel1.CreateGraphics().DrawEllipse(pen1, y + Xc, Convert.ToInt64(x) + Yc, 5, 5);//(y,x)         8 Octante
                panel1.CreateGraphics().DrawEllipse(pen1, Convert.ToInt64(x) + Xc, y + Yc, 5, 5);//(x,y)         7 Octante
                panel1.CreateGraphics().DrawEllipse(pen1, -(Convert.ToInt64(x)) + Xc, y + Yc, 5, 5);//(-x,y)     6 Octante
                panel1.CreateGraphics().DrawEllipse(pen1, -y + Xc, Convert.ToInt64(x) + Yc, 5, 5);//(-y,x)       5 Octante
                panel1.CreateGraphics().DrawEllipse(pen1, -y + Xc, -(Convert.ToInt64(x)) + Yc, 5, 5);//(-y,-x)   4 Octante
                panel1.CreateGraphics().DrawEllipse(pen1, -(Convert.ToInt64(x)) + Xc, -y + Yc, 5, 5);//(-x,-y)   3 Octante
                panel1.CreateGraphics().DrawEllipse(pen1, Convert.ToInt64(x) + Xc, -(y) + Yc, 5, 5);//(x,-y)     2 Octante
                panel1.CreateGraphics().DrawEllipse(pen1, y + Xc, -(Convert.ToInt64(x)) + Yc, 5, 5);//(y,-x)     1 Octante
                e = e + (2*y) + 1;
                y = y + 1;
                if((2*e)>(2*x-1))
                {
                    x = x - 1;
                    e =(e - (2 * e) + 1);
                }
            }

        }
    }
}
