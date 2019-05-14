using System;
using System.Collections.Generic;
using System.Text;

namespace Voyage.Entity
{
    public class Container
    {
        public Character Character { get; set; }
        public List<Area> Areas { get; set; }
        public Storage Storage { get; set; }
        public Shop Shop { get; set; }

        public Container(List<Area> areas)
        {
            this.Character = new Character(Config.Name, Config.IntervalCharacter);
            this.Areas = areas;
            this.Storage = new Storage();
            this.Shop = new Shop();
        }

        public void Cycle()
        {
            this.Shop.Cycle();
            this.Character.Cycle();
            foreach(Area item in this.Areas)
            {
                item.Cycle();
            }
        }
    }
}
