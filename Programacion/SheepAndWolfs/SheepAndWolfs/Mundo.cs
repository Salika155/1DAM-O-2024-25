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
        private List<Casilla> _casilla;
        private (int, int)[] _casillas = new (int, int)[] { };
        //lista de lobos y ovejas obligatorio
        private List<Oveja> _ovejas;
        private List<Lobo> _lobos;
        private int _width;
        private int _height;
        private List<Animal> _animals;


        public Mundo(int width, int height)
        {
            this._width = width;
            this._height = height;
            this._casilla = new List<Casilla>();
            this._animals = new List<Animal>();

            CrearCasillas();
        }

        public void CrearCasillas()
        {
            for (int y = 0; y < _height; y++) 
            {
                for (int  x = 0; x < _width; x++) 
                {
                    _casilla.Add(new Casilla(new Coordenada(x, y), TerritorioType.VACIO));
                }
            }
        }

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
            return _casilla[IndexOfCasilla(x, y)];
            //}
            //return null;
        }



        //no sirve
        //public void RemoveCasillaAt(int x, int y) 
        //{
        //    for (int i = 0; i < _casilla.Count; ++i) 
        //    {
        //        Casilla? casilla = _casilla[i];
        //        if (casilla.coordenada.EqualsToCoordenada(x, y)) 
        //            _casilla.RemoveAt(i);
        //    }
        //}

        public int IndexOfCasilla (int x, int y)
        {
            if ((x < 0 || x >= _width) || (y < 0 || y >= _height))
                return -1;
            //for (int i = 0; i < _casilla.Count; ++i)
            //{
            //    Casilla casilla = _casilla[i];
            //    if (casilla.coordenada.EqualsToCoordenada(x, y))
            //        return i;
            //}
            //return -1;
            return y * _width + x;
            //dado un index para hallar x e y divido el index entre el ancho como divisor y el cociente sera la y, y el resto la x
        }



        public bool ContainsCasilla(int x, int y)
        {
            //if ((x < 0 || x >= _width) || (y < 0 || y >= _height))
            //    return false;
            //if (x < 0)
            //y, width, height
            return IndexOfCasilla(x, y) != -1;
        }

        public int CountCasilla()
        {
            return _casilla.Count;
        }

        public Animal GetAnimalAt(int x, int y, AnimalType type)
        {
            for(int i = 0; i < _animals.Count; i++)
            {
                if (_animals[i].coordenada.EqualsToCoordenada(x, y) && _animals[i].type == type)
                    return _animals[i];
            }
            return null;
        }

        public int IndexOfAnimal(Animal animal)
        {
            for(int i = 0; i < _animals.Count; i++)
            {
                if (_animals[i].type == animal.type && _animals[i].Nombre == animal.Nombre)
                    return i;
            }
            return -1;
        }

        public int IndexOfOveja(Oveja oveja)
        {
            for (int i = 0; i < _ovejas.Count; i++)
            {
                if (_ovejas[i].Nombre == oveja.Nombre)
                    return i;
            }
            return -1;
        }

        public int IndexOfLobo()
        {
            for (int i = 0; i < _ovejas.Count; i++)
            {
                if (_ovejas[i].Nombre == oveja.Nombre)
                    return i;
            }
            return -1;
        }

        public Oveja GetOvejaAt()
        {

        }
        public Lobo GetLoboAt()
        {

        }

        
        //indexOf
        //contains
        //count?

        //int index = y * width + x
        //index / ancho = cociente la y y resto la x
       
    }
}
