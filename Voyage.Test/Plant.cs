using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voyage.Entity;

namespace Voyage.Test
{
    [TestClass]
    public class PlantTest
    {
        [TestMethod]
        public void Harvest()
        {
            Plant plant = new Plant();
            plant.PlantType = PlantType.Food;
            plant.Name = Helper.GetRandomName(PlantType.Food);
            plant.Food = 10;

            Storage storage = new Storage();
            Assert.AreEqual(storage.Foods.Count, 0);

            storage.Harvest(plant);
            Assert.AreEqual(storage.Foods[0].Count, 10);
            Assert.AreEqual(plant.Food, 0);
        }
    }
}
