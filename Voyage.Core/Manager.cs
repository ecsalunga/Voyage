using System.Collections.Generic;
using Voyage.Entity;

namespace Voyage.Core
{
    public class Manager
    {
        System.Timers.Timer _timer;
        private Container _container;
        public Operator Operator { get; set; }

        public Manager()
        {
            this._timer = new System.Timers.Timer(Config.Interval);
            this._timer.Elapsed += _timer_Elapsed;

            Helper.Full = Config.Full;

            List<Area> areas = Helper.GenerateRandomArea(Config.AreaCount, Config.AreaMaxLevel);
            foreach(Area item in areas)
                item.Plants = Helper.GenerateRandomPlants(Helper.Rand.Next(0, (item.Level > 4 ? 4 : item.Level)));

            Character character = new Character(Config.Name, Config.IntervalCharacter, Config.Initial);
            this._container = new Container(character, areas);

            this.Operator = new Operator(this._container);
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this._container.Cycle();
        }

        public void Start()
        {
            this._timer.Start();
        }
    }
}
