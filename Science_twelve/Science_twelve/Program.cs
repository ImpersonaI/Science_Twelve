using System;

namespace Science_twelve
{
    class Program
    {
        static void Main(string[] args)
        {
            double result= 0.0000001;
            //n - точность (кол-во прямоугольников)
            //a и b - границы отрезка, на котором происходит интегрирование
            //func - подынтегральная функция
            void Rectangle(double n, double a, double b)
            {
                double x, h, s, y;
                h = (b - a) / n; //шаг
                s = 0;
                for (x = a + h / 2; x < b; x += h)
                {
                    y = x * x - 0.25;// подинтегральная функция
                    s += y * h; // Элементарное приращение
                }
                Console.WriteLine("Ответ методом треугольников = " + s);
                result += s;
            }

            static double Trapezium(Func<double, double> func, double n, double a, double b)
            {
                double x, h, s;
                h = (b - a) / n;
                s = (func(a) + func(b)) / 2;
                for (x = a + h; x < b; x += h)
                {
                    s += func(x);
                }
                return s * h;
            }

            Rectangle(10, -0.5, 0.5);
            Console.WriteLine("Ответ методом Симпсона = " + result);

            double a = -0.5, b = 0.5, h, s = 0, n = 10, k, f;
            h = (b - a) / n;
            for (double x1 = 0, x = a; x <= b; x += h)
            {
                if (x < b)
                {
                    x1 = x + h / 2;
                    if (x1 >= 2)
                        continue;
                    f = x * x - 0.25;
                    s += f;
                }

            }
            k = Math.Abs(Math.PI - s * h);
            Console.WriteLine("**********************************");
            Console.WriteLine("Ответ методом прямоугольников: {0:0.0000}", s * h);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
