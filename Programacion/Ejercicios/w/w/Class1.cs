using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w
{
    public enum Escuderia
    {
        MCLAREN,
        FERRARI,

    }

    public class Car
    {
        public Escuderia Escuderia;
        private readonly List<Wheel> _wheels = new();
        //public int color;

        public void AddWheel(Wheel wheel)
        {
            if (wheel == null)
                return;
            var owner = wheel.OwnerCar;
                if (owner != null)
                    owner.RemoveWheel(wheel);
                owner = this;
                _wheels.Add(wheel);
        }

        private void RemoveWheel(Wheel wheel)
        {
            for (int i = 0; i < _wheels.Count; i++)
            {
                if (_wheels[i] == wheel)
                {
                    wheel.OwnerCar = null;
                    _wheels.RemoveAt(i);
                    break;
                }
            }
        }
    }
    public enum WheelType
    {

    }
    public class Wheel
    {
        public double Radius;
        public double With;
        public WheelType type;
        private WeakReference<Car>? _ownerCar;
        //weak es una refenrecia intermedia a un objeto, empieza siendo fuerte a una caja intermedia, y luego sale una weak al objeto.

        public Car? OwnerCar
        {
            get
            {
                if (_ownerCar is null)
                    return null;
                //me creo una variable tipo strong
                Car? car;
                //tengo que probar que si no tiene referencias apuntando fuertes, poder eliminarlo, si si que las tiene devolvera false.
                if (_ownerCar.TryGetTarget(out car))
                {
                    return car;
                }
                return null;
            }
            set
            {
                if (value == null)
                    _ownerCar = null;
                else
                    _ownerCar = new WeakReference<Car>(value);
            }
        }

    }
    internal class Class1
    {
        public static int GetCarColor(Wheel wheel)
        {
            if (wheel.OwnerCar == null)
                return -1;
            return wheel.OwnerCar.color;
        }
    }
}
