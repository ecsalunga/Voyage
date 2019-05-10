using System;
using System.Collections.Generic;
using System.Text;
using Voyage.Entity;

namespace Voyage.Core
{
    public class Operator
    {
        public Container Container { get; set; }

        public Operator(Container container)
        {
            this.Container = container;
        }

        public void TryGetSeed(Plant plant)
        {
            if (Helper.Rand.Next(1, 21) == 7)
            {
                StorageItem item = this.Container.Storage.GetSeedStorage(plant);
                item.Count++;
            }
        }

        public void Harvest(Plant plant)
        {
            this.TryGetSeed(plant);

            if (plant.Food > 0)
            {
                StorageItem item = this.Container.Storage.GetFoodStorage(plant);
                item.Count += plant.Food;
                plant.Food = 0;
            }

            if (plant.Wood > 0)
            {
                this.Container.Storage.Wood += plant.Wood;
                plant.Wood = 0;
            }
        }

        public void Eat(StorageItem item)
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
            if (Helper.Full > character.Energy + add)
            {
                character.Energy += add;
                return;
            }
            else
                character.Energy = Helper.Full;
        }
    }
}
