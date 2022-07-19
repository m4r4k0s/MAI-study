using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace wmp
{
    public class model
    {
        private System.Timers.Timer timer;
        private ArrayList listeners;
        public bool moov, left, right, down;

        public model()
        {
            listeners = new ArrayList();
            moov = false;
            left = false;
            right = false;
            down = false;

            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(lurking);
            timer.Interval = 20;
        }

        //запускаем таймер и выбираем нужный тип действия 
        public void mooving_start()
        {
            moov = true;
            timer.Enabled = true;
        }

        public void mooving_stop()
        {
            moov = false;
            timer.Enabled = false;
        }

        public void left_start()
        {
            left = true;
            timer.Enabled = true;
        }

        public void left_stop()
        {
            left = false;
            timer.Enabled = false;
        }

        public void right_start()
        {
            right = true;
            timer.Enabled = true;
        }

        public void right_stop()
        {
            right = false;
            timer.Enabled = false;
        }

        public void down_start()
        {
            down = true;
            timer.Enabled = true;
        }

        public void down_stop()
        {
            down = false;
            timer.Enabled = false;
        }

        //таймер вызывающий обновление наблюдателей 
        public void lurking(object sender, ElapsedEventArgs e)
        {
            UpdateObservers();
        }

        //тут мы смотрим в какой зоне находится окошко когда мы его отпустили и крепим его к нужной грани 
        public void CheckCon(ref GroupBox gb, ref Panel pl, Point CursorPos, Point DockBottomL, Size DockBottomS, Point DockLeftL, Size DockLeftS, Point DockTopL, Size DockTopS, Point DockRightL)
        {
            if (CursorPos.Y < DockBottomL.Y - DockBottomS.Height && CursorPos.X < DockLeftL.X + DockLeftS.Width && CursorPos.Y > DockTopL.Y + DockTopS.Height)
            {
                gb.Dock = System.Windows.Forms.DockStyle.Left;
            }
            else if (CursorPos.Y < DockBottomL.Y - DockBottomS.Height && CursorPos.X > DockRightL.X && CursorPos.Y > DockTopL.Y + DockTopS.Height)
            {
                gb.Dock = System.Windows.Forms.DockStyle.Right;
            }
            else if (CursorPos.Y < DockTopL.Y + DockTopS.Height)
            {
                gb.Dock = System.Windows.Forms.DockStyle.Top;
                pl.Size = new Size(gb.Size.Width, pl.Size.Height);
            }
            else if (CursorPos.Y > DockBottomL.Y - DockBottomS.Height)
            {
                gb.Dock = System.Windows.Forms.DockStyle.Bottom;
                pl.Size = new Size(gb.Size.Width, pl.Size.Height);
            }
        }

        //паттерн наблюдателя
        public void Register(IObserver o)
        {
            listeners.Add(o);
            o.UpdateState();
        }

        //паттерн наблюдателя 
        public void Deregister(IObserver o)
        {
            listeners.Remove(o);
        }

        //паттерн наблюдателя 
        public void UpdateObservers()
        {
            foreach (IObserver ob in listeners)
            {
                ob.UpdateState();
            }
        }
    }
}
