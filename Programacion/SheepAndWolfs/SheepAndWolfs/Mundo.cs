using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepAndWolfs
{
    public class Mundo
    {
        //mejor en array
        //private List<Casilla> _casilla;
        //private (int, int)[] _casillas = new (int, int)[] { };
        //private (Coordenada, TerritorioType)[] _casillas = new (Coordenada, TerritorioType)[] { };
        private Casilla[] _casillas = new Casilla[] { };
        //lista de lobos y ovejas obligatorio
        private int _width;
        private int _height;
        private List<Animal> _animals;
        


        public Mundo(int width, int height)
        {
            this._width = width;
            this._height = height;
            //this._casilla = new List<Casilla>();
            this._casillas = new Casilla[width * height];
            this._animals = new List<Animal>();


            CrearCasillas();
        }

        //public void CrearCasillas()
        //{
        //    for (int y = 0; y < _height; y++)
        //    {
        //        for (int x = 0; x < _width; x++)
        //        {
        //            int index = Utils.IndexOfCasilla(x, y, _width);
        //            _casillas[index] = new Casilla(new Coordenada(x, y));
        //        }
        //    }
        //}

        public int GetWidth() => _width;

        public int GetHeight() => _height;

        public Casilla? GetCasillaAt(int x, int y)
        {
            //if ((x < 0 || x >=  _width) || (y < 0 || y >= _height))
            //    return null;
            //for(int i = 0; i < _casilla.Count; i++)
            //{
            //    Casilla? casilla = _casilla[i];
            //    if (casilla.coordenada.EqualsToCoordenada(x, y))
            //        return casilla;
            //return _casilla[IndexOfCasilla(x, y)]; -> esta era la corta buena hasta que movi la funcion indexofcasilla a utils
            //}
            //return null;

            if (!Utils.IsValidCoordinates(x, y, _width, _height))
                return null;

            int index = Utils.IndexOfCasilla(x, y, _width);
            return index >= 0 && index < _casillas.Length ? _casillas[index] : null;
        }


        //public int IndexOfCasilla(int x, int y)
        //{
        //    if (x < 0 || y < 0 || _width <= 0)
        //        return -1;
        //    //for (int i = 0; i < _casilla.Count; ++i)
        //    //{
        //    //    Casilla casilla = _casilla[i];
        //    //    if (casilla.coordenada.EqualsToCoordenada(x, y))
        //    //        return i;
        //    //}
        //    //return -1;
        //    return y * _width + x;
        //    //dado un index para hallar x e y divido el index entre el ancho como divisor y el cociente sera la y, y el resto la x
        //}

        public bool ContainsCasilla(int x, int y)
        {
            //if ((x < 0 || x >= _width) || (y < 0 || y >= _height))
            //    return false;
            //if (x < 0)
            //y, width, height
            return Utils.IndexOfCasilla(x, y, _width) != -1;
        }

        public int CountCasilla()
        {
            return _casillas.Length;
        }

        public Animal? GetAnimalAt(int x, int y, AnimalType type)
        {
            if (!Utils.IsValidCoordinates(x, y, _width, _height))
                return null;
            for (int i = 0; i < _animals.Count; i++)
            {
                Animal? animal = _animals[i];
                if (animal.coordenada!.EqualsToCoordenada(x, y) && animal.type == type)
                    return animal;
            }
            return null;
        }

        public int IndexOfAnimal(Animal animal)
        {
            for (int i = 0; i < _animals.Count; i++)
            {
                if (_animals[i].type == animal.type && _animals[i].Nombre == animal.Nombre)
                    return i;
            }
            return -1;
        }

        public int CountAnimals()
        {
            return _animals.Count;
        }

        public int CountAnimalsType(AnimalType type)
        {
            if (_animals.Count == 0)
                return 0;

            int aux = 0;
            for (int i = 0; i < _animals.Count; i++)
                if (_animals[i].type == type)
                    aux += 1;
            return aux;
        }

        public void AddAnimal(Animal animal, int x, int y)
        {
            if (animal == null)
                return;

            animal.coordenada = new Coordenada(x, y); // Asignar coordenadas al animal
            _animals.Add(animal);
        }


        public AnimalType GetAnimalTypeAt(int x, int y, AnimalType type)
        {
            Animal? animal = GetAnimalAt(x, y, type);
            return animal.type;
        }

        public void CreateWolfs(int count)
        {
            for (int i = 0; i < count; i++)
            {
                int x = Utils.GetRandomNumber(0, _width);
                int y = Utils.GetRandomNumber(0, _height);

                if (GetAnimalAt(x, y, AnimalType.LOBO) == null) // Evitar duplicados
                {
                    Lobo lobo = new Lobo($"Lobo{i}");
                    lobo.coordenada = new Coordenada(x, y);
                    AddAnimal(lobo, x, y);
                }
            }
        }

        public void CreateSheeps(int count)
        {
            for (int i = 0; i < count; i++)
            {
                int x = Utils.GetRandomNumber(0, _width);
                int y = Utils.GetRandomNumber(0, _height);

                if (GetAnimalAt(x, y, AnimalType.OVEJA) == null) // Evitar duplicados
                {
                    Oveja oveja = new Oveja($"Oveja{i}");
                    oveja.coordenada = new Coordenada(x, y);
                    AddAnimal(oveja, x, y);
                }
            }
        }

        public void CrearCasillas()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    int index = Utils.IndexOfCasilla(x, y, _width);
                    _casillas[index] = new Casilla(new Coordenada(x, y))
                    {
                        type = Utils.GenerateRandomType()
                    };
                }
            }
        }

        //public void CreateSheeps(int v)
        //{
        //    for (int y = 0; y < _height; y++)
        //    {
        //        for (int x = 0; x < _width; x++)
        //        {
        //            int index = Utils.IndexOfCasilla(x, y, _width);
        //            _casillas[index] = new Casilla(new Coordenada(x, y));
        //        }
        //    }
        //}

        public void ImprimirCasillas()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    int index = Utils.IndexOfCasilla(x, y, _width);
                    if (_casillas[index] != null)
                    {
                        Console.Write($"[{_casillas[index].coordenada.X},{_casillas[index].coordenada.Y}] ");
                    }
                    else
                    {
                        Console.Write("[null] ");
                    }
                }
                Console.WriteLine(); // Nueva línea para cada fila
            }
        }

        internal void CreateRocks(int v)
        {
            throw new NotImplementedException();
        }

        internal void CreateWaters(int v)
        {
            throw new NotImplementedException();
        }

        ///TODO: Añadir un método para añadir un animal a la lista de animales
        //public AnimalType GetAnimalTypeAt(int x, int y)
        //{
        //    Animal animal = GetAnimalAt(x, y);
        //    return animal.animalType;
        //}

        //public int IndexOfOveja(Oveja oveja)
        //{
        //    for (int i = 0; i < _ovejas.Count; i++)
        //    {
        //        if (_ovejas[i].Nombre == oveja.Nombre)
        //            return i;
        //    }
        //    return -1;
        //}

        //public int IndexOfLobo()
        //{
        //    for (int i = 0; i < _ovejas.Count; i++)
        //    {
        //        if (_ovejas[i].Nombre == oveja.Nombre)
        //            return i;
        //    }
        //    return -1;
        //}

        //public Oveja GetOvejaAt()
        //{

        //}
        //public Lobo GetLoboAt()
        //{

        //}


        //indexOf
        //contains
        //count?

        //int index = y * width + x
        //index / ancho = cociente la y y resto la x

    }
}
