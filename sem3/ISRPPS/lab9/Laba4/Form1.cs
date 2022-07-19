using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4
{
    public partial class Form1 : Form
    {
        NvidiaGPU Nvid { set; get; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbstractFactory factory1 = new AMD_Factory();
            Client client1 = new Client(factory1);
            button1.Enabled = false;
            button2.Enabled = false;
            MessageBox.Show("GPU и CPU от АМД");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbstractFactory factory2 = new Intel_Factory();
            Client client2 = new Client(factory2);
            button1.Enabled = false;
            button2.Enabled = false;
            MessageBox.Show("GPU и CPU от Intel");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Nvid = NvidiaGPU.getInstance();
        }
    }


    class NvidiaGPU
    {
        private static NvidiaGPU instance;

        private NvidiaGPU()
        {
        }

        public static NvidiaGPU getInstance()
        {
            if (instance == null)
            {
                instance = new NvidiaGPU();
                MessageBox.Show("Видеокарта Nvidia");
            }
            else MessageBox.Show("Карты закончились");

            return instance;
        }
    }

    abstract class AbstractFactory
    {
        public abstract AbstractCPU CreateCPU();
        public abstract AbstractGPU CreateGPU();
    }
    
    /// Класс фабрики №1
    class AMD_Factory : AbstractFactory
    {
        public override AbstractCPU CreateCPU()
        {
            return new AMD_CPU();
        }
        public override AbstractGPU CreateGPU()
        {
            return new AMD_GPU();
        }
    }

    /// Класс фабрики №2
    class Intel_Factory : AbstractFactory
    {
        public override AbstractCPU CreateCPU()
        {
            return new Intel_CPU();
        }
        public override AbstractGPU CreateGPU()
        {
            return new Intel_GPU();
        }
    }

    /// Абстрактный класс продукта А
    abstract class AbstractCPU
    {
    }

    /// Абстрактный класс продукта В
    abstract class AbstractGPU
    {
    }


    /// Первый класс продукта типа А
    class AMD_CPU : AbstractCPU
    {
        public string message1 = "Процессор АМД";
    }

    /// Первый класс продукта типа В
    class AMD_GPU : AbstractGPU
    {
        public string message2 = "Видеокарта АМД";
    }

    /// Второй класс продукта типа А
    class Intel_CPU : AbstractCPU
    {
        public string message3 = "Процессор Интел";
    }

    /// Второй класс продукта типа В
    class Intel_GPU : AbstractGPU
    {
        public string message4 = "Видеокарта Интел";
    }

    /// Класс клиента, в котором происходит взаимодействие между объектами
    class Client 
    {
        private AbstractCPU  abstractCPU;
        private AbstractGPU  abstractGPU;
        // Конструктор
        public Client(AbstractFactory factory)
        {
            abstractGPU = factory.CreateGPU();
            abstractCPU = factory.CreateCPU();
        }
    }
}
