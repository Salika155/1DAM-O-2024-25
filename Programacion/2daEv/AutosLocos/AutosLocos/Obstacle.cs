using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocos
{
    
    public class Obstacle : RaceObject
    {

        //protected double _activationRange;
        //protected bool _isActivated;

        public Obstacle(string? name, double position)
            : base(name, position)
        {
            //_activationRange = activationRange;
            //_isActivated = true;
        }
        public override ObjectType GetObjectType()
        {
            return ObjectType.OBSTACLE;
        }

        //public bool IsActivated => _isActivated;
        public override bool IsEnable()
        {
            return Enabled;
        }
        //public void Disable()
        //{
        //    _isActivated = false;
        //}

        public override void Simulate(IRace race)
        {
        }

        

        //// ✅ Propiedad abstracta para que las clases hijas definan su tipo
        //public abstract ObstacleType Type { get; }
    }
}
