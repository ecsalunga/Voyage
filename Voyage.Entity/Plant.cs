using System;
using System.Collections.Generic;
using System.Text;

namespace Voyage.Entity
{
    public class Plant
    {
        public string Name { get; set; }
        public int Food { get; set; }
        public int Wood { get; set; }

        public int Level { get; set; }
        public PlantType PlantType { get; set; }

        public int Current { get; set; }
        public int Interval { get; set; }

        public void Cycle()
        {
            this.Current--;

            if (this.Current < 1)
            {
                if(this.PlantType == PlantType.Food)
                    this.Food = Helper.AddWithLimit(this.Food, this.Level, this.Level * 100);
                else if (this.PlantType == PlantType.Wood)
                    this.Wood = Helper.AddWithLimit(this.Wood, this.Level, this.Level * 100);
                else
                {
                    this.Food = Helper.AddWithLimit(this.Food, this.Level, this.Level * 100);
                    this.Wood = Helper.AddWithLimit(this.Wood, this.Level, this.Level * 100);
                }
                this.Current = this.Interval;
            }
        }
    }

    public enum PlantType
    {
        Food = 1,
        Wood,
        Both
    }
}
