using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voyage.Core;
using Voyage.Entity;

namespace Voyage.Test
{
    [TestClass]
    public class Character_Test
    {
        [TestMethod]
        public void Cycle()
        {
            Manager manager = new Manager();
            Character character = manager.Container.Character;

            Assert.AreEqual(character.Food, Config.Full);

            character.Cycle();
            Assert.AreEqual(character.Food, Config.Full - 1);

            character.Health = 50;
            character.Energy = 50;
            character.Cycle();

            Assert.AreEqual(character.Health, 51);
            Assert.AreEqual(character.Energy, 51);
        }
    }
}
