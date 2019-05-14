using System.Collections.Generic;
using Voyage.Entity;

namespace Voyage.Core
{
    public class Manager
    {
        System.Timers.Timer _timer;
        public Container Container { get; set; }
        public Operator Operator { get; set; }

        public Manager()
        {
            this._timer = new System.Timers.Timer(Config.Interval);
            this._timer.Elapsed += _timer_Elapsed;

            List<Area> areas = Helper.GenerateRandomArea();
            foreach(Area item in areas)
                item.Plants = Helper.GenerateRandomPlants(item.Level);
            
            this.Container = new Container(areas);
            this.Operator = new Operator(this.Container);
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
