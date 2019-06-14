using System;
using System.Collections.Generic;
using System.Text;
using Voyage.Entity;

namespace Voyage.Core
{
    public class Operator
    {
        private Container Container { get; set; }

        public Operator(Container container)
        {
            this.Container = container;
        }

        public void TryGetSeed(Plant plant)
        {
            if (Helper.Rand.Next(1, Config.SeedChance + 1) == 7)
            {
                Item item = this.Container.Storage.GetSeedStorage(plant.PlantType.Name);
                item.Count++;
            }
        }

        public void SellItem(int amount, Item item)
        {
            item.Count -= amount;
            this.Container.Storage.Gold += (amount * Helper.ItemPrices[item.Name].Sell);
        }

        public void SellFood(int amount, Item item)
        {
            item.Count -= amount;
            this.Container.Storage.Gold += (amount * Helper.FoodPrices[item.Name].Sell);
        }

        public void SellSeed(int amount, Item item)
        {
            item.Count -= amount;
            this.Container.Storage.Gold += (amount * Helper.SeedPrices[item.Name].Sell);
        }

        public void BuyItem(int amount, string name)
        {
            Item item = this.Container.Storage.GetItemStorage(name);
            item.Count += amount;
            this.Container.Storage.Gold -= (amount * Helper.ItemPrices[name].Buy);
        }

        public void BuyFood(int amount, string name)
        {
            Item item = this.Container.Storage.GetFoodStorage(name);
            item.Count += amount;
            this.Container.Storage.Gold -= (amount * Helper.FoodPrices[name].Buy);
        }

        public void BuySeed(int amount, string name)
        {
            Item item = this.Container.Storage.GetSeedStorage(name);
            item.Count += amount;
            this.Container.Storage.Gold -= (amount * Helper.SeedPrices[name].Buy);
        }

        public void Harvest(Plant plant)
        {
            this.TryGetSeed(plant);

            if (plant.Food > 0)
            {
                Item item = this.Container.Storage.GetFoodStorage(plant.PlantType.Name);
                item.Count += plant.Food;
                plant.Food = 0;
            }

            if (plant.Material > 0)
            {
                Item item = this.Container.Storage.GetItemStorage(Config.Material);
                item.Count += plant.Material;
                plant.Material = 0;
            }
        }

        public void Eat(Item item)
        {
            if (item.Count < 0)
                return;

            item.Count--;
            int add = Helper.GetPlantType(item.Name).Food;
            Character character = this.Container.Character;

            // try to fill food
            if (Helper.Full > character.Food + add)
            {
                character.Food += add;
                return;
            }
            else
            {
                add = (character.Food + add) - Helper.Full;
                character.Food = Helper.Full;

                if (add < 1)
                    return;
            }

            // try to fill health
            if (Helper.Full > character.Health + add)
            {
                character.Health += add;
                return;
            }
            else
            {
                add = (character.Health + add) - Helper.Full;
                character.Health = Helper.Full;

                if (add < 1)
                    return;
            }

            // try to fill energy
            character.Energy = (Helper.Full > character.Energy + add) ? character.Energy + add : Helper.Full;
        }
    }
}
