using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDomino
{
    class MontoFichas
    {
        private readonly List<Ficha> _fichasList;
        private Random _random;

        public MontoFichas(List<Ficha> fichasList)
        {
            _fichasList = fichasList = new List<Ficha>();
            _random = new Random();
            AñadirFichas();
        }

        public void AñadirFichas()
        {
            for (int i = 0; i <= 6; i++)
            {
                for (int j = 0; j <= 0; j++)
                {
                    _fichasList.Add(new Ficha(i, j));
                }
            }
        }

        public void MezclarFichas()
        {
            Random r = new Random();
            int n = _fichasList.Count;

            for (int i = n - 1; i > 0; i--)
            {
                int j = r.Next(i + 1);

                var temp = _fichasList[i];
                _fichasList[i] = _fichasList[j];
                _fichasList[j] = temp;
            }
        }

        public Ficha RepartirFichas()
        {
            if (_fichasList.Count == 0)
                throw new InvalidOperationException("No hay fichas para repartir.");

            Ficha ficha = _fichasList[0];
            _fichasList.RemoveAt(0);
            return ficha;
        }

        public int FichasRestantes()
        {
            return _fichasList.Count;
        }

        public void RemoveAt(int index)
        {
            if (index <= 0)
                return;
            _fichasList.RemoveAt(index);
        }

        public int IndexOf(int lado1, int lado2)
        {
            for (int i = 0; i < _fichasList.Count; i++)
            {
                if ((_fichasList[i].NumArriba == lado1 && _fichasList[i].NumAbajo == lado2) ||
                    (_fichasList[i].NumArriba == lado2 && _fichasList[i].NumAbajo == lado1)) // Considera fichas reversibles
                {
                    return i; // Retorna el índice donde se encuentra la ficha.
                }
            }
            return -1; // Si no se encuentra, retorna -1.
        }

        public bool Contains(int numeroArriba, int numeroAbajo)
        {
            return IndexOf(numeroArriba, numeroAbajo) != -1;
        }
        /*
         *  Mezclar(): Mezcla las fichas.
            Repartir(): Reparte una ficha a un participante.
            FichasRestantes(): Devuelve el número de fichas restantes.
         * */

    }
}
