using System;
using System.Collections.Generic;
using System.Text;

namespace Voyage.Entity
{
    public class Plant
    {
        public PlantType PlantType { get; set; }
        public int Food { get; set; }
        public int Material { get; set; }

        public int Level { get; set; }
  
        public int Current { get; set; }
        public int Interval { get; set; }

        public Plant(PlantType plantType)
        {
            this.PlantType = plantType;
        }

        public void Update(int level)
        {
            int interval = (level * this.PlantType.Interval);
            this.Interval = interval + Helper.Rand.Next(0, interval / 5);
            this.Current = this.Interval;
            this.Level = level;
        }

        public void Cycle()
        {
            this.Current--;

            if (this.Current < 1)
            {
                this.Current = this.Interval;

                if (this.PlantType.Food > 0)
                    this.Food = Helper.AddWithLimit(this.Food, this.Level, this.Level * 100);

                if(this.PlantType.Material > 0)
                    this.Material = Helper.AddWithLimit(this.Material, this.Level * this.PlantType.Material, (this.Level * this.PlantType.Material) * 100);
            }
        }
    }
}
