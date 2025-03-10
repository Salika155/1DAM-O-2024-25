using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocos
{
    class Puddle : Obstacle
    {
        public Puddle(string? name, double position) : base("Charco", position)
        {
        }

        public override void Simulate(IRace race)
        {
            foreach(RaceObject r in race.GetRacers())
            {
                if (r.Position < this.Position + 20 || 
                    r.Position >= this.Position - 20)
                {
                    DisableObject(r);
                }
            }
        }

        public void DisableObject(RaceObject r)
        {
            if (Utils.Probability(20))
            {
                int turns = (int)Utils.RandomRange(0.0, 3.0);
                r.Disable(turns);
            }
        }
    }
}
