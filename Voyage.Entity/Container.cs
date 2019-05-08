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

        public Container(Character character, List<Area> areas)
        {
            this.Character = character;
            this.Areas = areas;
            this.Storage = new Storage();
        }

        public void Cycle()
        {
            this.Character.Cycle();
            foreach(Area item in this.Areas)
            {
                item.Cycle();
            }
        }
    }
}
