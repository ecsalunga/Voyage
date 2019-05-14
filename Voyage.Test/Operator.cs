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
            Storage storage = manager.Container.Storage;
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
            Character character = manager.Container.Character;

            Assert.AreEqual(character.Food, Config.Full);

            op.Harvest(plant);
            Item item = manager.Container.Storage.Foods[0];
            Assert.AreEqual(item.Count, 10);

            character.Food = 50;
            op.Eat(item);
            Assert.AreEqual(item.Count, 9);
            Assert.AreEqual(character.Food, plant.PlantType.Food + 50);
        }

        [TestMethod]
        public void BuySell()
        {
            Manager manager = new Manager();
            Operator op = manager.Operator;
            Storage storage = manager.Container.Storage;
            Item item = manager.Container.Shop.Foods[0];

            storage.Gold = 100;
            op.BuyFood(1, item.Name);
            Assert.IsTrue(storage.Gold < 100);
            Assert.AreEqual(storage.Foods[0].Count, 1);

            int gold = storage.Gold;
            op.SellFood(1, storage.Foods[0]);
            Assert.IsTrue(storage.Gold > gold);
            Assert.AreEqual(storage.Foods[0].Count, 0);
        }
    }
}
