using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Übung_Delegaten
{
    interface IRun
    {
        void Run();
    }

    public class Aufgabe1 : IRun
    {
        delegate int F(int a, int b);

        public int Add(int a, int b)
        {
            return a + b;
        }
        // (a, b) => a + b;

        public void Run()
        {
            F add = (z1, z2) => z1 + z2;
            F mul = (z1, z2) => z1 * z2;
            F x = Add;

            Console.WriteLine("10+20:" + add(10, 20));
            Console.WriteLine("10*20:" + mul(10, 20));
            Console.WriteLine("10+20:" + x(10, 20));
        }
    }
    public class Aufgabe2 : IRun
    {
        List<Func<double, double>> FListe;
        Func<double, double>[] FArray =
        {
            (x) => x,
            Math.Sin,
            (x)=>Math.Cos(x),
            (x)=>Math.Tan(x)
        };

        public void Run()
        {
            for (int i = 0; i <= 20; i++)
            {
                double x = Math.PI * i / 10.0; // Schrittweite 0.1
                foreach (var f in FArray)
                {
                    Console.Write("| {0,10:0.00} ", f(x));
                }
                Console.WriteLine("|");
            }
        }
    }
    public class Aufgabe3 : IRun
    {
        public void Run()
        {
            Func<double, double, double, double> f1 = (a, b, c) => a + b + c;
            Func<int, int, int, bool> f2 = (x, a, b) => x >= a && x <= b;
            Console.WriteLine(f1(10, 20, 30)); // 10+20+30
            Console.WriteLine(f2(10, 5, 20)); // x=10 in [5,20]
        }
    }
    public class Aufgabe4 : IRun
    {
        public T Eval2<T>(Func<T, T> f, T x)
        {
            return f(x);
        }

        public double Eval(Func<double, double> f, double x)
        {
            return f(x);
        }
        public void Run()
        {
            Console.WriteLine(Eval((x) => x * x, 10));
            Console.WriteLine(Eval(Math.Sin, Math.PI));
            Console.WriteLine(Eval(x => Math.Pow(2, x), 10));

            Console.WriteLine(Eval2(x => (int)Math.Pow(2, x), 10));
            Console.WriteLine(Eval2(x => x + x, "10"));

        }
    }
    public class Aufgabe5 : IRun
    {
        public double Newton(Func<double, double> f, Func<double, double> fs)
        {
            double delta = 0.0000001;
            double xn = 2;
            double xns;
            do
            {
                xns = xn - f(xn) / fs(xn);
                Console.WriteLine(xns+":"+xn);
                if(Math.Abs(xn-xns) < delta)
                {
                    return xn;
                }
                xn = xns;
            }
            while (true);
        }

        public void Run()
        {
            double nullstelle = Newton((x) => x * x - 9, (x) => 2 * x);
            Console.WriteLine("NULLSTELLE:" + nullstelle);
            double nullstelle2 = Newton((x) => Math.Sin(x), (x) => Math.Cos(x));
            Console.WriteLine("NULLSTELLE:" + nullstelle2);
        }
    }
}
