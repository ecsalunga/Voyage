using System;
using System.Collections.Generic;
using System.Text;

namespace Voyage.Entity
{
    public class Plant
    {
        public PlantType PlantType { get; set; }
        public int Food { get; set; }
        public int Wood { get; set; }

        public int Level { get; set; }
  
        public int Current { get; set; }
        public int Interval { get; set; }

        public Plant(PlantType plantType)
        {
            this.PlantType = plantType;
        }

        public void Update(int level)
        {
            this.Level = level;
            this.Interval = (level * this.PlantType.Interval);
            this.Interval = this.Interval + Helper.Rand.Next(0, this.Interval / 5);
            this.Current = this.Interval;
        }

        public void Cycle()
        {
            this.Current--;

            if (this.Current < 1)
            {
                this.Current = this.Interval;

                if (this.PlantType.Food > 0)
                    this.Food = Helper.AddWithLimit(this.Food, this.Level, this.Level * 100);

                if(this.PlantType.Wood > 0)
                    this.Wood = Helper.AddWithLimit(this.Wood, this.Level * this.PlantType.Wood, (this.Level * this.PlantType.Wood) * 100);
            }
        }
    }

    public class PlantType
    {
        public string Name { get; set; }
        public int Food { get; set; }
        public int Wood { get; set; }
        public int Interval { get; set; }
    }
}
