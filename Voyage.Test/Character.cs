using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voyage.Entity;

namespace Voyage.Test
{
    [TestClass]
    public class Character_Test
    {
        [TestMethod]
        public void Cycle()
        {
            Character character = new Character("test", 1, 100);
            Assert.AreEqual(character.Food, 100);

            character.Cycle();
            Assert.AreEqual(character.Food, 99);

            character.Health = 50;
            character.Energy = 50;
            character.Cycle();

            Assert.AreEqual(character.Health, 51);
            Assert.AreEqual(character.Energy, 51);
        }
    }
}
