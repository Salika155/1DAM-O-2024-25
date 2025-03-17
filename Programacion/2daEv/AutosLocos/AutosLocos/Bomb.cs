using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocos
{
    class Bomb : Obstacle
    {
        public int _turns;
        public Bomb(int turns, double position) : base("Bomba", position)
        {
            _turns = turns;
        }

        public override void Simulate(IRace race)
        { 
            if (_turns == 0)
            {
                foreach (RaceObject r in race.GetRacers())
                {
                    if (r.Position <= this.Position + 50)
                    {
                        r.Position += 50;
                    }
                    else if (r.Position >= this.Position - 50)
                    {
                        r.Position -= 50;
                    }
                }
            }
            _turns--;
            if (_turns <= 0)
                Enabled = false;
        }
    }
}
