using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba7_Chain_responsibility
{
    public partial class Form1 : Form
    {
        ChainofResponsibility chr = new ChainofResponsibility();
        public class ChainofResponsibility
        {
            Handler h1 = new Handler1();
            Handler h2 = new Handler2();
            Handler h3 = new Handler3();
            Handler h4 = new Handler3();

            public ChainofResponsibility()
            {
                h1.next = h2;
                h2.next = h3;
                h3.next = null;
            }
            public void run(int request)
            {
                h1.HandlerRequest(request);
            }
        }

        abstract public class Handler
        {
            public Handler next { set; get; }
            abstract public void HandlerRequest(int request);
        }

        /// <summary>
        /// Обработчик, проверяющий число на > 0
        /// </summary>
        public class Handler1 : Handler
        {
            public override void HandlerRequest(int request)
            {

                if (request < 0)
                {
                    MessageBox.Show("Обработчик 1: Введенное число меньше 0");
                    MessageBox.Show("Обработчик 1 не вызвал след обработчик");
                }
                else
                {
                    if (next != null)
                    {
                        MessageBox.Show("Обработчик 1 вызвал след обработчик");
                        next.HandlerRequest(request);
                    }
                    else
                    {
                        MessageBox.Show("Обработчику 1 нечего вызывать");
                    }
                }
            }
        }
        /// <summary>
        /// Обработчик, проверяющий число на нечетность
        /// </summary>
        public class Handler2 : Handler
        {
            public override void HandlerRequest(int request)
            {
                if (request % 2 != 0)
                {
                    MessageBox.Show("Обработчик 2: Введенное число нечетное");
                    MessageBox.Show("Обработчик 2 не вызвал след обработчик");
                }
                else
                {
                    if (next != null)
                    {
                        MessageBox.Show("Обработчик 2 вызвал след обработчик");
                        next.HandlerRequest(request);
                    }
                    else
                    {
                        MessageBox.Show("Обработчику 2 нечего вызвать");
                    }
                }
            }
        }

        public class Handler3 : Handler
        {
            public override void HandlerRequest(int request)
            {
                if (request % 3 == 0) { MessageBox.Show("Число " + request.ToString() + " делится на 6"); }
                else
                {
                    if (next != null)
                    {
                        MessageBox.Show("Обработчик 3 вызвал след обработчик");
                        next.HandlerRequest(request);
                    }
                    else
                    {
                        MessageBox.Show("Обработчику 3 нечего вызвать");
                    }
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try {
                chr.run(Convert.ToInt32(textBox1.Text));
            }
            catch (FormatException)
            {
                MessageBox.Show("ВВЕДИТЕ ЧИСЛО");
            }
            }

        
    }
}