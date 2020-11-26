using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lesson6.Task2;


namespace Lesson6
{
    // Описываем делегат.

    public delegate double Fun(double x);
    class Program
    {
        // Создаем метод, который принимает делегат
        public static void Table(Fun F, double x, double b)
        {


            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        // Создаем метод для передачи его в качестве параметра в Table
        public static double MyFunc(double x, double a)
        {
            return a * x * x;
        }
        public static double Sinus(double x, double a)
        {
            return a * Math.Sin(x);
        }

         private static void Main()
        {
            //Вызов первой задачи

            Console.WriteLine("Таблица функции a*x^2:");
            
            Table(delegate (double x) { double a = 0; return a * x * x; }, 0, 3);
            Console.WriteLine("Таблица функции a*sin(x):");
            Table(delegate (double x) { double a = 0; return a * Math.Sin(x); }, 0, 3);
            Console.ReadLine();

            //Вызов второй задачи

            function[] F = { F1, F2 };
            Console.WriteLine("Сделайте выбор: 1 - функция F1, 2 - функция F2");
            int index = int.Parse(Console.ReadLine());
            SaveFunc("data.bin", -100, 100, 0.5, F[index - 1]);
            Console.WriteLine(Load("data.bin"));
            Console.ReadKey();


        }

    }
}