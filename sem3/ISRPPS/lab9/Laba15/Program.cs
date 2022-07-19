using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba15
{
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SimpleClock());
        }
    }

    class SimpleClock : Form
    {
        public SimpleClock()
        {
            Text = "Simple Clock";
            BackColor = SystemColors.Window;
            ForeColor = SystemColors.WindowText;

            Timer timer = new Timer();
            timer.Tick += new EventHandler(TimerOnTick);
            timer.Interval = 1000;
            timer.Start();
        }

        private void TimerOnTick(object sender, EventArgs ea)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pea)
        {
            base.OnPaint(pea);
            StringFormat stfrmt = new StringFormat();
            stfrmt.Alignment = StringAlignment.Center;
            stfrmt.LineAlignment = StringAlignment.Center;

            pea.Graphics.DrawString(DateTime.Now.ToString("F"), Font, new SolidBrush(ForeColor), ClientRectangle, stfrmt);
        }
    }
}
