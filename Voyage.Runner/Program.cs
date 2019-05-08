using System;
using Voyage.Core;
using Voyage.Entity;

namespace Voyage.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Config config = new Config();
            Console.WriteLine("Hello World!");
            Manager m = new Manager(config);
            m.Start();

            Console.Read();
        }
    }
}
