using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task23
{
    class Program
    {
        public static double facMain = 1;
        public static int n;

        static void Main(string[] args)
        {
            Console.WriteLine("Введите число для подсчета факториала: ");
            n = int.Parse(Console.ReadLine());

            Task<double> result = FactorialAsync();

            facMain = result.Result;
            for (int i = 1; i <= n - 1; i++)
            {
                double t = facMain;
                facMain /= i;
                Console.WriteLine($"Доказываю факториал - {t}/{i}={facMain}");
            }

            if (facMain == n)
            {
                Console.WriteLine("Факториал вычислен верно!");
            }
            else
            {
                Console.WriteLine("Факториал вычислен  ошибочно!");
            }
            Console.ReadKey();
        }

        static double Factorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Значение не должно быть отрицательным");
            }

            double fac = 1;
            while (n > 1)
            {
                Console.WriteLine($"Считаю факториал - {fac}");
                fac *= n;
                n--;
            }
            Console.WriteLine($"Факториал числа: {fac}");
            return fac;
        }
        static async Task<double> FactorialAsync()
        {
            Console.WriteLine("Начало вычисления факториала");
            double result = await Task.Run(() => Factorial(n));
            Console.WriteLine("Конец вычисления факториала");
            return result;

        }

    }
}
