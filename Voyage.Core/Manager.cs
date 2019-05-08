using System.Collections.Generic;
using Voyage.Entity;

namespace Voyage.Core
{
    public class Manager
    {
        System.Timers.Timer _timer;
        public Container Container { get; set; }
        public Config Config { get; set; }

        public Manager(Config config)
        {
            this.Config = config;
            this._timer = new System.Timers.Timer(config.Interval);
            this._timer.Elapsed += _timer_Elapsed;

            Character ch = new Character(this.Config.Name, this.Config.IntervalCharacter, this.Config.Initial);
            List<Area> areas = Helper.GenerateRandomArea(this.Config.AreaCount, this.Config.AreaMaxLevel);
            foreach(Area item in areas)
                item.Plants = Helper.GenerateRandomPlants(Helper.Rand.Next(0, (item.Level > 4 ? 4 : item.Level)), this.Config.PlantInterval);

            this.Container = new Container(ch, areas);
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Container.Cycle();
        }

        public void Start()
        {
            this._timer.Start();
        }
    }
}
