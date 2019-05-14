using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Voyage.Entity
{
    public class Storage
    {
        public List<Item> Seeds { get; set; }
        public List<Item> Foods { get; set; }
        public List<Item> Items { get; set; }
        public int Gold { get; set; }

        public Storage()
        {
            this.Seeds = new List<Item>();
            this.Foods = new List<Item>();
            this.Items = new List<Item>();
        }

        public Item GetSeedStorage(string name)
        {
            return GetStorageItem(name, this.Seeds);
        }

        public Item GetFoodStorage(string name)
        {
            return GetStorageItem(name, this.Foods);
        }

        public Item GetItemStorage(string name)
        {
            return GetStorageItem(name, this.Items);
        }

        private Item GetStorageItem(string name, List<Item> items)
        {
            Item item = items.FirstOrDefault(p => p.Name == name);
            if (item == null)
            {
                item = new Item() { Name = name };
                items.Add(item);
            }

            return item;
        }
    }
}
