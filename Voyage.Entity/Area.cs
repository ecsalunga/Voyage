using System;
using System.Collections.Generic;
using System.Linq;

namespace Voyage.Entity
{
    public class Area
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public List<Plant> Plants { get; set; }

        public void Cycle()
        {
            foreach(Plant item in this.Plants)
            {
                item.Cycle();
            }

            Console.WriteLine("{0}, Food: {1}. Wood: {2}", this.Name, this.Plants.Sum(i => i.Food), this.Plants.Sum(i => i.Wood));
        }
    }
}
