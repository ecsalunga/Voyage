using System;
using System.Collections.Generic;
using System.Text;

namespace Voyage.Entity
{
    public class Helper
    {
        public static Random Rand = new Random();
        public static string[] WoodNames = { "Acacia", "Mahogany", "Narra" };
        public static string[] FoodNames = { "Banana", "Grapes", "Strawberry", "Pineapple"};
        public static string[] BothNames = { "Apple", "Mango", "Star Apple", "Guava", "Coconut"};

        public static int AddWithLimit(int current, int add, int limit)
        {
            current = (current + add > limit) ? limit : current + add;
            return current > 0 ? current : 0;
        }

        public static List<Area> GenerateRandomArea(int count, int maxLevel)
        {
            List<Area> items = new List<Area>();

            for(int x = 0; x < count; x++)
            {
                Area item = new Area();
                item.Name = "Area " + x;
                item.Level = Rand.Next(1, maxLevel+1);
                items.Add(item);
            }

            return items;
        }

        public static List<Plant> GenerateRandomPlants(int count, int interval)
        {
            int level = Rand.Next(2, 4);
            List<Plant> items = new List<Plant>();
            for(int x = 0; x < count; x++)
            {
                Plant item = new Plant();
                item.PlantType = GetPlantType(Rand.Next(1, 4));
                item.Name = GetRandomName(item.PlantType);
                item.Level = Rand.Next(1, level);
                if(item.PlantType == PlantType.Food)
                    item.Food = Rand.Next(0, 3);
                else if(item.PlantType == PlantType.Wood)
                    item.Wood = Rand.Next(0, 5);
                else
                {
                    item.Food = Rand.Next(0, 3);
                    item.Wood = Rand.Next(0, 5);
                }
                item.Interval = Rand.Next(interval, (interval * 2) + 1);
                item.Current = item.Interval;
                items.Add(item);
            }
            return items;
        }

        public static PlantType GetPlantType(int num)
        {
            if (num == 1)
                return PlantType.Food;
            else if (num == 2)
                return PlantType.Wood;

            return PlantType.Both;
        }

        public static string GetRandomName(PlantType plantType)
        {
            string[] names;
            if (plantType == PlantType.Food)
                names = FoodNames;
            else if (plantType == PlantType.Wood)
                names = WoodNames;
            else
                names = BothNames;

            return names[Rand.Next(0, names.Length)];
        }
    }
}
