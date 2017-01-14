using System;

namespace C_BasicExperiments
{
    class Klasa
    {
        public delegate void Callback(object sender, DateTime timeOfMethodEnd);

        public Callback DelgateMethodEnded;
        public event Callback EventMethodEnded;

        public void Metoda()
        {
            Console.WriteLine("Metoda - początek");

            //tu długie działanie metody

            Console.WriteLine("Metoda - tuż przed końcem");

            DelgateMethodEnded?.Invoke(this, DateTime.Now);

            EventMethodEnded?.Invoke(this, DateTime.Now);

            Console.WriteLine("Metoda - koniec");
        }
    }
}
