using System;
using System.Collections.Generic;
using System.Text;

namespace Voyage.Entity
{
    public class Shop
    {
        public int Current { get; set; }
        public int Interval { get; set; }

        public List<Item> Foods { get; set; }
        public List<Item> Seeds { get; set; }
        public List<Item> Items { get; set; }

        public Shop()
        {
            this.Interval = Config.IntervalShop + Helper.Rand.Next(0, Convert.ToInt32(Config.IntervalShop * 0.5) + 1);
            this.Current = this.Interval;
            this.RefreshItems();
        }

        public void Cycle()
        {
            this.Current--;
            if (this.Current < 1)
            {
                this.Current = this.Interval;
                this.RefreshItems();
            }
        }

        private void RefreshItems()
        {
            this.Items = new List<Item>() { new Item() { Name = Config.Wood, Count = Helper.Rand.Next(1, Config.WoodSellCount + 1) } };

            this.Foods = new List<Item>();
            int count = Helper.Rand.Next(1, Config.SellFoodCount + 1);
            for (int x = 0; x < count ; x++)
            {
                PlantType plant = Helper.GetRandomPlantType();
                while(plant.Food < 1)
                    plant = Helper.GetRandomPlantType();

                Foods.Add(new Item() { Name = plant.Name, Count = Helper.Rand.Next(1, Config.FoodSellCount + 1) });
            }

            this.Seeds = new List<Item>();
            count = Helper.Rand.Next(1, Config.SellSeedCount + 1);
            for (int x = 0; x < count; x++)
            {
                PlantType plant = Helper.GetRandomPlantType();
                Seeds.Add(new Item() { Name = plant.Name, Count = Helper.Rand.Next(1, Config.SeedSellCount + 1) });
            }
        }
    }
}
