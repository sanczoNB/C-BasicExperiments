using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace C_BasicExperiments
{
    class Program
    {
        delegate int DInc(int n);

        delegate bool DIsEqual(double x, double y);

        delegate void DShow(int x);

        private enum Numbers:byte
        {
           Two=1, Tree, Six=6, Seven=7
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Wyrażenia Lambda:\n");

            DInc Inc = (int n) => n + 1;
            Console.WriteLine("Inc(1)=" + Inc(1));

            DIsEqual IsEqual = (x, y) => x == y;
            int a = 10;
            int b = 20;
            Console.WriteLine("Czy równe a={0} i b={1} ? {2}",a,b,(IsEqual(a,b) ? "Tak" : "Nie"));
            Console.WriteLine("Czy równe a={0} i a={1} ? {2}", a, a, (IsEqual(a, a) ? "Tak" : "Nie"));

            DShow Show = n => { Console.WriteLine(n.ToString()); };
            Show(new int());

            Console.ReadKey();
        }

        private static void object_MethodEnded(object sender, DateTime timeOfMethodEnded)
        {
            Console.WriteLine("Zakończona metoda obiektu typu " + sender.GetType().Name + " (czas: " + timeOfMethodEnded + ")");
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

        private static void Metoda() // głowa metody, sygnatura
        {
            Console.WriteLine("Hello World!"); // ciało metody
        }

        //przeciążenie(overload) metody Metoda()
        private static void Metoda(string text, ConsoleColor color = ConsoleColor.Blue)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = currentColor;
        }

        private static int Kwadrat(int args)
        {
            return args*args;
        }

        private static void DoubleRange(double min, double max)
        {
            min = double.MinValue;
            max = double.MaxValue;
            Console.WriteLine("Liczby double mogą należęć do przedziału (" + min +","+max+")");
        }

        private static void DoubleRange(out double min, out double max)
        {
            min = double.MinValue;
            max = double.MaxValue;
            Console.WriteLine("Liczby double mogą należęć do przedziału (" + min + "," + max + ")");
        }
    }
}
