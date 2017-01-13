using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace C_BasicExperiments
{
    class Program
    {
        private enum Numbers:byte
        {
           Two=1, Tree, Six=6, Seven=7
        }

        static void Main(string[] args)
        {
            PresentLazyInicialization();

            Console.ReadKey();
        }

        private static void PresentEnum()
        {
            Console.WriteLine("Two to {0}", (byte)Numbers.Two);
            Console.WriteLine("Tree to {0}", (byte)Numbers.Tree);
            Console.WriteLine("Six to {0}", (byte)Numbers.Six);
            Console.WriteLine("Seven to {0}", (byte)Numbers.Seven);
            Console.Write(byte.MaxValue);
        }

        private static void PresentLazyInicialization()
        {
            Lazy<int> li = new Lazy<int>(() => 4); // deklaracja zmiennej i wskazanie funkcji
            Console.WriteLine(li.IsValueCreated.ToString()); // jesszcze niezainicjalizowana
            Console.WriteLine("Odwołanie do zmiennej, li=" + li.Value);// leniwa inicjalizacja
            Console.WriteLine(li.IsValueCreated.ToString()); // już zainicjalizowane
                                                             //Lazy is only to read

            Console.WriteLine("\n*****************\n");

            var lb = new Lazy<Button>(() =>
            {
                var b = new Button
                {
                    Text = "Leniwy przycisk",
                    Left = 100,
                    Top = 100
                };
                return b;
            });
            Console.WriteLine(lb.IsValueCreated.ToString());
            Console.WriteLine("Odwołanie do zmiennej, etykieta przycisku: \"" +
                              lb.Value.Text + "\"");
            Console.WriteLine(lb.IsValueCreated.ToString());
        }
    }
}
