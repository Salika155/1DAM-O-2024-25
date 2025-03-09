using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocos
{
    public enum ObstacleType
    {
        ROCK,
        PUDDLE,
        BOMB
    }
    public abstract class Obstacle : RaceObject
    {

        protected double _activationRange;
        protected bool _isActivated;

        public Obstacle(string? name, double position, double activationRange)
            : base(name, position)
        {
            _activationRange = activationRange;
            _isActivated = true;
        }

        public bool IsActivated => _isActivated;

        public void Disable()
        {
            _isActivated = false;
        }

        public override void Simulate(IRace race)
        {
        }

        public override ObjectType GetObjectType()
        {
            return ObjectType.OBSTACLE;
        }

        // ✅ Propiedad abstracta para que las clases hijas definan su tipo
        public abstract ObstacleType Type { get; }
    }
}
