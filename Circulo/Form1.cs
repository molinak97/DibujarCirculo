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

        Pen pen = new Pen(Color.Green, 3);
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
                p = 0;
            }

        }
        private void CirculoDDA(int Xc, int Yc, int Xr, int Yr)
        {

        }
    }
}
