using System;
using System.Collections.Generic;
using System.Text;

namespace Voyage.Entity
{
    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Energy { get; set; }
        public int Food { get; set; }

        public int Interval { get; set; }
        public int Current { get; set; }

        public Character(string name, int interval)
        {
            this.Name = name;
            this.Health = Config.Full;
            this.Energy = Config.Full;
            this.Food = Config.Full;

            this.Interval = interval;
            this.Current = interval;
        }

        public void Cycle()
        {
            this.Current--;

            if (this.Current < 1)
            {
                this.Current = this.Interval;

                if (this.Food > 0)
                    this.Food--;

                int add = (this.Food > 0) ? 1 : -1;
                this.Health = Helper.AddWithLimit(this.Health, add, Helper.Full);
                this.Energy = Helper.AddWithLimit(this.Energy, add, Helper.Full);

                Console.WriteLine("Character Health: {0}, Energy: {1}. Food: {2}", this.Health, this.Energy, this.Food);
            }
        }
    }
}
