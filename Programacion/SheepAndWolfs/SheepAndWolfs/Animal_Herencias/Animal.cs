using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepAndWolfs
{
    public enum AnimalType
    {
        ANIMAL,
        OVEJA,
        LOBO
    }
    public abstract class Animal
    {
        private AnimalType? _type;
        private Coordenada? _coordenada;
        private int _saciedad;
        private int _hidratacion;
        private int _resistencia;
        private int _sueño;
        private string? _nombre;
        private int _velocidad;

        //TODO: esto funciona
        public Animal(int food, int water, int stamina, int sleep, AnimalType type, string? name, int speed)
        {
            this._saciedad = food;
            this._hidratacion = water;
            this._resistencia = stamina;
            this._sueño = sleep;
            this._type = type;
            this._nombre = name;
            this._velocidad = speed;
        }

        public int GetSaciedad() => _saciedad;
        public void SetSaciedad(int value) => _saciedad = value; 
        public int GetHidratacion() => _hidratacion;
        public void SetHidratacion(int value) => _hidratacion = value;
        public int GetResistencia() => _resistencia;
        public void SetResistencia(int value) => _resistencia = value;
        public int GetSueño() => _sueño;
        public void SetSueño(int value) => _sueño = value;
        public string? GetNombre() => _nombre;
        public virtual int GetVelocidad() => _velocidad;
        public virtual AnimalType? GetType() => _type;
        public Coordenada? GetCoordenada() => _coordenada;
        public void SetCoordenada(int x, int y) => _coordenada = new Coordenada(x, y);

        //crearanimales en el constructor

        //animals va a tener los metodos de moverse, pero dudo si deberia tener el metodo de comer animales, ya que eso
        //solo lo haran los lobos, al igual que la hierba las ovejas
        public virtual void Mover()
        {
            Console.WriteLine($"{_nombre} se mueve a una velocidad de {GetVelocidad()}.");
        }
    }
}
