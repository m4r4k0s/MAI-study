using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Date
    {
        private int day = 31;
        private int month = 1;
        private int year = 1970;

        public int Day
        {
            set
            {
                if ((value < 1) || (value > 31))
                    throw new ArgumentOutOfRangeException("День");
                else
                    day = value;
            }
            get { return day; }
        }

        public int Month
        {
            set
            {
                if ((value < 1) || (value > 12))
                    throw new ArgumentOutOfRangeException("Месяц");
                else
                    month = value;
            }
            get { return month; }
        }

        public int Year
        {
            set
            {
                if ((value < 1000) || (value > 3000))
                    throw new ArgumentOutOfRangeException("Год");
                else
                    year = value;
            }
            get { return year; }
        }

        public Date() { }
        public Date(int day, int month, int year)
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }

        public void WhatData()
        {
            Console.WriteLine("Дата: " + Day + "." + Month + "." + Year + ".");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bool {0} байт", sizeof(bool));
            Console.WriteLine("Int {0} байт", sizeof(int));
            Console.WriteLine("Short {0} байт", sizeof(short));
            Console.WriteLine("Float {0} байт", sizeof(float));
            Console.WriteLine("Double {0} байт", sizeof(double));
            Console.WriteLine("Decimal {0} байт", sizeof(decimal));
            Console.WriteLine("Char {0} байт", sizeof(char));

            Console.WriteLine();

            float[] mass;
            mass = new float[4] { 5.4f, 134.45E-2f, 3.11E+1f, 7 };
            foreach (float element in mass)
            {
                Console.Write(element);
                Console.Write("  ");
            }

            Console.WriteLine();
            Console.WriteLine();

            Date today = new Date();
            today.WhatData();

            Console.WriteLine("Введите дату");
            try
            {
                Console.Write("День = ");
                today.Day = Convert.ToInt32(Console.ReadLine());
                Console.Write("Месяц = ");
                today.Month = Convert.ToInt32(Console.ReadLine());
                Console.Write("Год = ");
                today.Year = Convert.ToInt32(Console.ReadLine());

                today.WhatData();
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Ошибка! Неверный формат ввода!");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Блок finally");
            }
            Console.ReadLine();
        }
    }
}