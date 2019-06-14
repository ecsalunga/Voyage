using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Voyage.Entity
{
    public class Helper
    {
        public static Random Rand = new Random();
        public static string Path { get; set; } = AppContext.BaseDirectory;
        public static int Full = Config.Full;

        public static string ToDuration(int seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return time.ToString(@"hh\:mm\:ss");
        }

        public static int AddWithLimit(int current, int add, int limit)
        {
            current = (current + add > limit) ? limit : current + add;
            return current > 0 ? current : 0;
        }

        public static List<Area> GenerateRandomArea()
        {
            List<Area> items = new List<Area>();

            for (int x = 0; x < Config.AreaCount; x++)
            {
                Area item = new Area();
                item.Name = "Area " + x;
                item.Level = Rand.Next(1, Config.AreaMaxLevel + 1);
                items.Add(item);
            }

            return items;
        }

        public static List<Plant> GenerateRandomPlants(int limit)
        {
            int count = Rand.Next(0, (limit > Config.InitialPlantMaxLevel ? Config.InitialPlantMaxLevel : limit));
            List <Plant> items = new List<Plant>();
            for (int x = 0; x < count; x++)
            {
                Plant item = new Plant(GetRandomPlantType());
                int level = Rand.Next(1, count + 1);
                item.Update(level);
                if(item.PlantType.Food > 0)
                    item.Food = Rand.Next(0, ((item.Level * 100) / 4) + 1);
                if (item.PlantType.Material > 0)
                    item.Material = Rand.Next(0, ((item.Level * item.PlantType.Material * 100) / 4) + 1);

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
                    LoadData();

                return _plantTypes;
            }
        }

        private static Dictionary<string, Price> _seedPrices;
        public static Dictionary<string, Price> SeedPrices
        {
            get
            {
                if (_seedPrices == null)
                    LoadData();

                return _seedPrices;
            }
        }

        private static Dictionary<string, Price> _foodPrices;
        public static Dictionary<string, Price> FoodPrices
        {
            get
            {
                if (_foodPrices == null)
                    LoadData();

                return _foodPrices;
            }
        }

        private static Dictionary<string, Price> _itemPrices;
        public static Dictionary<string, Price> ItemPrices
        {
            get
            {
                if (_itemPrices == null)
                    LoadData();

                return _itemPrices;
            }
        }

        public static void LoadData()
        {
            string json = File.ReadAllText(Path + "\\Data\\plant.json");
            List<Data> data = JsonConvert.DeserializeObject<List<Data>>(json);

            _plantTypes = new List<PlantType>();
            var seedPrices = new List<Price>();
            var foodPrices = new List<Price>();
            var itemPrices = new List<Price>();

            foreach (Data item in data)
            {
                _plantTypes.Add(new PlantType() { Name = item.Name, Food = item.Food, Material = item.Material, Interval = item.Interval });
                seedPrices.Add(new Price() { Name = item.Name, Buy = item.SeedPrice + Rand.Next(1, (item.SeedPrice * Config.PriceSpread/100) + Config.PriceMargin), Sell = item.SeedPrice });

                if(item.Food > 0)
                    foodPrices.Add(new Price() { Name = item.Name, Buy = item.Price + Rand.Next(1, (item.Price * Config.PriceSpread / 100) + Config.PriceMargin), Sell = item.Price });
            }

            _seedPrices = seedPrices.ToDictionary(k => k.Name, i => i);
            _foodPrices = foodPrices.ToDictionary(k => k.Name, i => i);

            itemPrices.Add(new Price() { Name = Config.Material, Buy = Config.MaterialPrice + Rand.Next(1, (Config.MaterialPrice * Config.PriceSpread / 100) + Config.PriceMargin), Sell = Config.MaterialPrice});
            _itemPrices = itemPrices.ToDictionary(k => k.Name, i => i);
        }

        #endregion Constants
    }
}
