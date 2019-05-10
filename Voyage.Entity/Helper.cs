using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Voyage.Entity
{
    public class Helper
    {
        public static Random Rand = new Random();
        public static int Full;

        public static int AddWithLimit(int current, int add, int limit)
        {
            current = (current + add > limit) ? limit : current + add;
            return current > 0 ? current : 0;
        }

        public static List<Area> GenerateRandomArea(int count, int maxLevel)
        {
            List<Area> items = new List<Area>();

            for (int x = 0; x < count; x++)
            {
                Area item = new Area();
                item.Name = "Area " + x;
                item.Level = Rand.Next(1, maxLevel + 1);
                items.Add(item);
            }

            return items;
        }

        public static List<Plant> GenerateRandomPlants(int count)
        {
            int level = Rand.Next(2, 4);
            List<Plant> items = new List<Plant>();
            for (int x = 0; x < count; x++)
            {
                Plant item = new Plant(GetRandomPlantType());

                item.Update(level);
                if(item.PlantType.Food > 0)
                    item.Food = Rand.Next(0, ((item.Level * 100) / 4) + 1);
                if (item.PlantType.Wood > 0)
                    item.Wood = Rand.Next(0, ((item.Level * item.PlantType.Wood * 100) / 4) + 1);

                items.Add(item);
            }
            return items;
        }

        public static PlantType GetRandomPlantType()
        {
            return PlanTypes[Rand.Next(0, PlanTypes.Count)];
        }

        public static PlantType GetPlantType(string name)
        {
            return PlanTypes.FirstOrDefault(i => i.Name == name);
        }

        #region Constants

        private static List<PlantType> _plantTypes;
        public static List<PlantType> PlanTypes
        {
            get
            {
                if (_plantTypes == null)
                {
                    _plantTypes = new List<PlantType>()
                    {
                        new PlantType() { Name = "Narra", Wood = 5, Interval = 28},
                        new PlantType() { Name = "Acacia", Wood = 4, Interval = 25},
                        new PlantType() { Name = "Mahogany", Wood = 3, Interval = 18},
                        new PlantType() { Name = "Banana", Food = 5, Interval = 14},
                        new PlantType() { Name = "Pineapple", Food = 4, Interval = 12},
                        new PlantType() { Name = "Grapes", Food = 3, Interval = 10},
                        new PlantType() { Name = "Strawberry", Food = 2, Interval = 8},
                        new PlantType() { Name = "Apple", Food = 3, Wood = 4, Interval = 42},
                        new PlantType() { Name = "Mango", Food = 3, Wood = 5, Interval = 35},
                        new PlantType() { Name = "Guava", Food = 1, Wood = 2, Interval = 32},
                        new PlantType() { Name = "Coconut", Food = 3, Wood = 3, Interval = 38},
                    };
                }

                return _plantTypes;
            }
        }

        #endregion Constants
    }
}
