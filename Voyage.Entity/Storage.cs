using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Voyage.Entity
{
    public class Storage
    {
        public List<StorageItem> Seeds { get; set; }
        public List<StorageItem> Foods { get; set; }
        public int Wood { get; set; }

        public Storage()
        {
            this.Seeds = new List<StorageItem>();
            this.Foods = new List<StorageItem>();
        }

        public void Harvest(Plant plant)
        {
            if(plant.PlantType == PlantType.Food)
                this.HarvestFood(plant);
            else if (plant.PlantType == PlantType.Wood)
            {
                this.Wood += plant.Wood;
                plant.Wood = 0;
            }
            else
            {
                this.HarvestFood(plant);
                this.Wood += plant.Wood;
                plant.Wood = 0;
            }
        }

        private void HarvestFood(Plant plant)
        {
            StorageItem item = this.Foods.FirstOrDefault(p => p.Name == plant.Name);
            if (item == null)
            {
                item = new StorageItem() { Name = plant.Name };
                this.Foods.Add(item);
            }

            item.Count += plant.Food;
            plant.Food = 0;
        }
    }

    public class StorageItem
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
