using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocos
{
    class Rock : Obstacle
    {
        private double _weight;

        public Rock(double position) : base("Piedra", position)
        {
            _weight = Utils.RandomRange(10, 30);
        }

        public double Weight => _weight;

        public override void Simulate(IRace race)
        {
            foreach(RaceObject c in race.GetRacers())
            {
                if(c.Position <= this.Position + 20 && 
                    c.Position >= this.Position - 20)
                {
                    if (Utils.Probability(10 + _weight))
                    {
                        c.Position -= 25;
                    }
                }
            }
        }
        //public override bool IsEnable()
        //{
        //    throw new NotImplementedException();
        //}

        //public override bool IsAlive => true;  // Define tu propia lógica aquí

        // ✅ Aquí especificamos que este obstáculo es de tipo ROCK
        //public override ObstacleType Type => ObstacleType.ROCK;
    }
}
