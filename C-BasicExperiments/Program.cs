using System;

namespace C_BasicExperiments
{
    class Program
    {
        private enum Numbers:int
        {
           Two=1, Tree, Six=6, Seven=600
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Two to {0}", (long)Numbers.Two);
            Console.WriteLine("Tree to {0}", (byte)Numbers.Tree);
            Console.WriteLine("Six to {0}", (byte)Numbers.Six);
            Console.WriteLine("Seven to {0}", unchecked ((byte)Numbers.Seven));
            Console.Write(byte.MaxValue);

            Console.ReadKey();
        }
    }
}
