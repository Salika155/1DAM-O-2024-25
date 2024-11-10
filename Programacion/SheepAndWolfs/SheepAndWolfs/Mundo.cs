using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepAndWolfs
{
    public class Mundo
    {
        private List<Casilla> _casilla;
        private int _width;
        private int _height;

        public int GetWidth()
        {
            return _width;
        }

        public int GetHeight()
        {
            return _height;
        }

        public Casilla? GetCasillaAt(int x, int y)
        {
            for(int i = 0; i < _casilla.Count; i++)
            {
                Casilla? casilla = _casilla[i];
                if (casilla.coordenada.GetX() == x && casilla.coordenada.GetY() == y)
                    return casilla;
            }
            return null;
        }

        public void RemoveCasillaAt(int x, int y) 
        {
            for (int i = 0; i < _casilla.Count; ++i) 
            {
                Casilla? casilla = _casilla[i];
                if (casilla.coordenada.GetX() == x && casilla.coordenada.GetY() == y)
                    _casilla.RemoveAt(i);
            }
        }

        public int IndexOfCasilla (int x, int y)
        {
            for (int i = 0; i < _casilla.Count; ++i)
            {
                Casilla casilla = _casilla[i];
                if (casilla.coordenada.GetX() == x && casilla.coordenada.GetY() == y)
                    return i;
            }
            return -1;
        }

        public bool ContainsCasilla(int x, int y)
        {
            return IndexOfCasilla(x, y) != -1;
        }

        public int CountCasilla()
        {
            return _casilla.Count;
        }

        //removeat???
        //indexOf
        //contains
        //count?
       
    }
}
