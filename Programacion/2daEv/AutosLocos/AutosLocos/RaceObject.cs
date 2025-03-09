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
        CAR,
        DRIVER
    }
    public abstract class RaceObject
    {
        private string? _name = string.Empty;
        private double _position;
        private bool _isDisabled;
        private int _disabledTurns;

        public RaceObject(string? name, double position)
        {
            _name = name;
            Position = position;
            _isDisabled = false;
            _disabledTurns = 0;
        }

        public string? Name
        {
            get { return _name; }
        }

        public double Position
        {
            get
            {
                return _position;
            }
            protected set
            {
                _position = value;
            }
        }

        public abstract bool IsAlive { get; }
        public bool IsDisabled => _isDisabled;

        public abstract ObjectType GetObjectType();
        public virtual void Disable(int turns) 
        {
            _isDisabled = true;
            _disabledTurns = turns;
        }

        public virtual void Simulate(IRace race)
        {

        }
        
        protected void DecrementDisabledTurns()
        {
            if (_isDisabled)
            {
                _disabledTurns--;
                if (_disabledTurns <= 0)
                    _isDisabled = false;

            }
        }
    }
}
