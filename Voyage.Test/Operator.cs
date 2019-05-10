using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voyage.Core;
using Voyage.Entity;

namespace Voyage.Test
{
    [TestClass]
    public class Operator_Test
    {
        [TestMethod]
        public void TryGetSeed()
        {
            Plant plant = new Plant(Helper.GetRandomPlantType());

            Manager manager = new Manager();
            Operator op = manager.Operator;
            Storage storage = op.Container.Storage;
            Assert.AreEqual(storage.Seeds.Count, 0);

            for(int x = 0; x < 100; x++)
                op.TryGetSeed(plant);

            Assert.IsTrue(storage.Seeds.Count > 0);
        }

        [TestMethod]
        public void Harvest()
        {
            Plant plant = new Plant(Helper.GetRandomPlantType());
            plant.Food = 10;

            Manager manager = new Manager();
            Operator op = manager.Operator;

            op.Harvest(plant);
            Assert.AreEqual(plant.Food, 0);
        }

        [TestMethod]
        public void Eat()
        {
            Plant plant = new Plant(Helper.GetPlantType("Banana"));
            plant.Food = 10;

            Manager manager = new Manager();
            Operator op = manager.Operator;

            Assert.AreEqual(op.Container.Character.Food, Config.Initial);

            op.Harvest(plant);

            StorageItem item = op.Container.Storage.Foods[0];
            Assert.AreEqual(item.Count, 10);

            op.Eat(item);
            Assert.AreEqual(item.Count, 9);
            Assert.IsTrue(op.Container.Character.Food > Config.Initial);
        }
    }
}
