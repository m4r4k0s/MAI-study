using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = CardforMVS.get_title();
            textBox2.Text = CardforMVS.get_info();

        }

        private void Form1_Load(object sender, EventArgs e)
        {}

        
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = CardforMVS.get_info();
            textBox1.Text = CardforMVS.get_title();
            CardforMVS.reset();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            CardforMVS.ch_title(textBox1.Text);
            CardforMVS.ch_info(textBox2.Text);
            CardforMVS.Save();
        }        
    }

    class Journal
    {
        private static Journal journal = new Journal();

        private string _title;
        private string Text;

        static public string title
        {
            get { return journal._title; }
            set { journal._title = value; }
        }
        static public string info
        {
            get { return journal.Text; }
            set { journal.Text = value; }
        }

        private Journal()
        {
            _title = "Cool article";
            Text = "some info";
        }
    }


    static class CardforMVS
    {
        static string title;
        static string info;

        static public void ch_title(string s)
        {
            title = s;
        }

        static public void ch_info(string s)
        {
            info = s;
        }

        static public void Save()
        {
            Journal.title = title;
            Journal.info = info;
        }

        static public string get_title() { return Journal.title; }
        static public string get_info() { return Journal.info; }

        static public void reset()
        {
            title = String.Empty;
            info = String.Empty;
        }
    }
}
