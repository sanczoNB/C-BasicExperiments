#if DEBUG
#warning Kompilacja "debug"
#endif

using System;
using System.Windows.Forms;
namespace C_BasicExperiments
{
    class Program
    {
        delegate int DInc(int n);

        delegate bool DIsEqual(double x, double y);

        delegate void DShow(int x);

        private enum Numbers : byte
        {
            Two = 1,
            Tree,
            Six = 6,
            Seven = 7
        }

        private static dynamic obiekt = 1; // pole zaincjonowane typem int

        enum Typ
        {
            Int,
            Long,
            String,
            Float,
            Double,
            DividedByZeroException,
            Field,
            ClassInstance
        }

        private dynamic DynamicObject // właściwość
        {
            get { return ReturnDynamicObject(); }

            set { obiekt = value; }
        }

        static void Main(string[] args)
        {

            HowExceptionWorks(2);
            Console.WriteLine();
            HowExceptionWorks(0);

            Console.ReadKey();
        }

        private static int? HowExceptionWorks(int dzielnik)
        {
            try
            {
                int y = 10/dzielnik;
                return y;

            }
            catch (ArithmeticException exc)
            {
                ConsoleColor currentColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dzielenie przez zero ({0})", exc.Message);
                Console.ForegroundColor = currentColor;
                return null;
            }
            finally
            {
                ConsoleColor currentColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Finally ");
                Console.ForegroundColor = currentColor;
                //w bloku finally nie może być returnu
            }
        }

        private static dynamic ReturnDynamicObject(Typ whichType = Typ.Int)
        {
            dynamic value;
            switch (whichType)
            {
                case Typ.Int:
                    value = 5;
                    break;
                case Typ.Long:
                    value = 5L;
                    break;
                case Typ.String:
                    value = "Helion";
                    break;
                case Typ.Float:
                    value = 1.0f;
                    break;
                case Typ.Double:
                    value = 1.0;
                    break;
                case Typ.DividedByZeroException:
                    value = new DivideByZeroException();
                    break;
                case Typ.Field:
                    value = obiekt;
                    break;
                case Typ.ClassInstance:
                    value = new Klasa();
                    break;
                default:
                    value = null;
                    break;
            }
            return value;
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
