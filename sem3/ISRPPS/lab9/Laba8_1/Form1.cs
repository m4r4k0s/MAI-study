using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba8_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {   }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Enabled = false;
            MessageBox.Show("Leave");
        }
        private void label1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("You have clicked twice");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void Button1_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MessageBox.Show("Нажатие левой кнопкой мыши");
            }
            else if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("Нажатие правой кнопкой мыши");
            }
            else MessageBox.Show("Нажатие кнопкой" + e.Button.ToString());

        }
    }
}
