using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocos
{
    public enum ObjectType
    {
        OBSTACLE,
        CAR
    }
    public abstract class RaceObject
    {
        private string? _name = string.Empty;
        private double _position;
        protected bool Enabled;
        protected int DisabledTurns;

        public string? Name
        {
            get { return _name; }
        }

        public double Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public RaceObject(string? name, double position)
        {
            _name = name;
            Position = position;
            Enabled = true;
            DisabledTurns = 0;
        }

        public abstract ObjectType GetObjectType();
        public abstract void Simulate(IRace race);
        public abstract bool IsEnable();
        public virtual void Disable(int turns) 
        {
            Enabled = false;
            DisabledTurns += turns;
        }

        //public void DecrementDisabledTurns()
        //{
        //    if (Enabled)
        //    {
        //        DisabledTurns--;
        //        if (DisabledTurns <= 0)
        //            Enabled = false;

        //    }
        //}
    }
}
