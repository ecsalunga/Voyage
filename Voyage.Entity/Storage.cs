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

        public StorageItem GetSeedStorage(Plant plant)
        {
            return GetStorageItem(plant, this.Seeds);
        }

        public StorageItem GetFoodStorage(Plant plant)
        {
            return GetStorageItem(plant, this.Foods);
        }

        private StorageItem GetStorageItem(Plant plant, List<StorageItem> items)
        {
            StorageItem item = items.FirstOrDefault(p => p.Name == plant.PlantType.Name);
            if (item == null)
            {
                item = new StorageItem() { Name = plant.PlantType.Name };
                items.Add(item);
            }

            return item;
        }
    }

    public class StorageItem
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
