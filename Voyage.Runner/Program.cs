using System;
using Voyage.Core;
using Voyage.Entity;

namespace Voyage.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Manager m = new Manager();
            m.Start();

            Console.Read();
        }
    }
}
