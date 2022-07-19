using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace wmp
{
    public partial class Form1 : Form, IObserver
    {
        private controller controller;
        private model model;
        delegate void InvokeC();
        private int size;
        public Form1(model model)
        {
            InitializeComponent();
            this.model = model;
            model.Register(this);
            attachController(makeController());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DockBottom.Visible = false;
            DockLeft.Visible = false;
            DockRight.Visible = false;
            DockTop.Visible = false;
            size = 8;
        }

        //MVC паттерн 
        public void attachController(controller controller)
        {
            this.controller = controller;
        }

        //MVC паттерн 
        protected controller makeController()
        {
            return new controller(this, model);
        }

        //курсор попал в активную зону и кнопка зажата так что можно начать следить за ним
        private void moovingP_MouseDown(object sender, MouseEventArgs e)
        {
            moovingP.Size = new Size(groupBox1.Size.Width, moovingP.Size.Height);
            DockBottom.Visible = true;
            DockLeft.Visible = true;
            DockRight.Visible = true;
            DockTop.Visible = true;
            controller.mooving_start();
            //timerM.Enabled = true;
        }

        //кнопку отпустили, прекращаем слежку 
        private void moovingP_MouseUp(object sender, MouseEventArgs e)
        {
            controller.mooving_stop();
            moovingP.Size = new Size(groupBox1.Size.Width, moovingP.Size.Height);
            DockBottom.Visible = false;
            DockLeft.Visible = false;
            DockRight.Visible = false;
            DockTop.Visible = false;
            controller.CheckCon(ref groupBox1, ref moovingP, PointToClient(Cursor.Position), DockBottom.Location, DockBottom.Size, DockLeft.Location, DockLeft.Size, DockTop.Location, DockTop.Size, DockRight.Location);
        }

        //реализуем метод для оновления наблюдателя
        public void UpdateState()
        {
            if (controller != null)
            {
                BeginInvoke(new InvokeC(WindowWorc));//вукидываем обработку в другой поток иначе будет лагать отрисовка 
            }
        }

        //двигаем всякое 
        public void WindowWorc()
        {
            if (model.moov) //двигаем само окошко (такая запись нужна т.к. вызов идет из другого потока)
            {
                Point pos = new Point(0, 0);
                this.Invoke(new Action(() => groupBox1.Dock = System.Windows.Forms.DockStyle.None));
                this.Invoke(new Action(() => pos = PointToClient(Cursor.Position)));
                this.Invoke(new Action(() => groupBox1.Location = new System.Drawing.Point(pos.X - 15, pos.Y - 15)));
            }
            if (model.right) //тянем за правую границу
            {
                Point posM = new Point(0, 0);
                Point posG = new Point(0, 0);
                Size size = new Size(0, 0);
                this.Invoke(new Action(() => posM = PointToClient(Cursor.Position)));
                this.Invoke(new Action(() => posG = groupBox1.Location));
                this.Invoke(new Action(() => size = groupBox1.Size));
                if (posM.X - posG.X > 100)
                {
                    this.Invoke(new Action(() => groupBox1.Size = new Size(posM.X - posG.X, size.Height)));
                    this.Invoke(new Action(() => moovingP.Size = new Size(posM.X - posG.X, moovingP.Size.Height)));

                }
            }
            if (model.left)//тянем за левую границу
            {
                Point posM = new Point(0, 0);
                Point posG = new Point(0, 0);
                Size size = new Size(0, 0);
                this.Invoke(new Action(() => posM = PointToClient(Cursor.Position)));
                this.Invoke(new Action(() => posG = groupBox1.Location));
                this.Invoke(new Action(() => size = groupBox1.Size));
                if (size.Width + posG.X - posM.X > 100)
                {
                    this.Invoke(new Action(() => groupBox1.Size = new Size(size.Width + posG.X - posM.X, size.Height)));
                    this.Invoke(new Action(() => moovingP.Size = new Size(moovingP.Size.Width + posG.X - posM.X, moovingP.Size.Height)));
                    this.Invoke(new Action(() => groupBox1.Location = new System.Drawing.Point(posM.X, posG.Y)));
                }
            }
            if (model.down) //тянем за нижнюю границу
            {
                Point posM = new Point(0, 0);
                Point posG = new Point(0, 0);
                Size size = new Size(0, 0);
                this.Invoke(new Action(() => posM = PointToClient(Cursor.Position)));
                this.Invoke(new Action(() => posG = groupBox1.Location));
                this.Invoke(new Action(() => size = groupBox1.Size));
                if (posM.Y - posG.Y > 100)
                {
                    this.Invoke(new Action(() => groupBox1.Size = new Size(size.Width, posM.Y - posG.Y)));
                }
            }
        }

        //зажали кнопку на правой границе 
        private void sizeR_MouseDown(object sender, MouseEventArgs e)
        {
            controller.rigth_start();
        }
        //отпустили кнопку на правой границе 
        private void sizeR_MouseUp(object sender, MouseEventArgs e)
        {
            controller.right_stop();
        }
        //смотри 2 пердидущих комментария(с поправкой на границу)
        private void sizeL_MouseDown(object sender, MouseEventArgs e)
        {
            controller.left_start();
        }

        private void sizeL_MouseUp(object sender, MouseEventArgs e)
        {
            controller.left_stop();
        }

        private void sizeD_MouseDown(object sender, MouseEventArgs e)
        {
            controller.down_start();
        }

        private void sizeD_MouseUp(object sender, MouseEventArgs e)
        {
            controller.down_stop();
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] s = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string a in s)
                {
                    textBox1.Text += a + "\r\n";
                }
            }
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            groupBox1.Size = new Size(212, 350);
            moovingP.Size = new Size(212, 25);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w')
            {
                groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            }
            if (e.KeyChar == 'a')
            {
                groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            }
            if (e.KeyChar == 's')
            {
                groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            }
            if (e.KeyChar == 'd')
            {
                groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            }
        }
        private void textBox1_MouseWheel(object sender, MouseEventArgs e)
        {

            if (e.Delta > 0)
            {
                size++;
            }

            if (e.Delta < 0 && size > 1)
            {
                size--;
            }
            textBox1.Font = new Font("Microsoft Sans Serif", size);
        }

    }
}
