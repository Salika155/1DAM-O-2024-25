using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocos
{
    class Car : RaceObject
    {
        protected double Finetunning;
        protected double Speed;
        public List<Driver> _driverList;

        public Car(string? name, double finetunning, double speed, List<Driver> driverList) 
            : base(name, 0)
        {
            Finetunning = finetunning;
            Speed = speed;
            _driverList = driverList;
        }

        public override ObjectType GetObjectType()
        {
            return ObjectType.CAR;
        }

        public override bool IsEnable()
        {
            return Enabled;
        }

        public override void Simulate(IRace race)
        {
            if (DisabledTurns > 0)
            {
                DisabledTurns -= 1;  // Reducimos el tiempo de desactivación
            }
            else
            {
                Position += Speed + Finetunning; // Solo se mueve si no está deshabilitado
            }
        }
    }
}
