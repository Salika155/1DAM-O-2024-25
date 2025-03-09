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

        public Rock(string? name, double position, double activationRange, double weight)
            : base(name, position, activationRange)
        {
            if (weight < 10 || weight > 30)
                throw new Exception("El peso debe estar entre 10 y 30.");

            _weight = weight;
        }

        public double Weight => _weight;

        public override bool IsAlive => true;  // Define tu propia lógica aquí

        // ✅ Aquí especificamos que este obstáculo es de tipo ROCK
        public override ObstacleType Type => ObstacleType.ROCK;
    }
}
