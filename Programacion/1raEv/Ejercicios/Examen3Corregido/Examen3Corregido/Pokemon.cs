using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen3Corregido
{
    public enum PokemonTipo
    {

    }

    internal class Pokemon
    {
        private List<Ataque> _ataqueList = new();

        public readonly int Id;
        public PokemonTipo Tipo;
        private int Nivel;
        private int Energia;

        public Pokemon(int id, int level, int energy)
        {
            Id = id;
            Nivel = level;
            Energia = energy;
        }

        public int GetLevel() => Nivel;

        public void SetLevel(int value)
        {
            if (!CheckLevel(value))
                return;
            
            Nivel = value;
        }

        private bool CheckLevel(int value)
        {
            return 1 <= value && value >= 100;
        }

        public void AddAtaque(Ataque ataque)
        {
            if (ataque == null)
                return;
            if (ataque.Nivel > Nivel)
                return;
            
        }

        private bool Contains(Ataque ataque)
        {
            return IndexOfAtaque(ataque) >= 0;
        }

        private int IndexOfAtaque(Ataque ataque)
        {
            for (int i = 0; i < _ataqueList.Count; i++)
            {
                if (_ataqueList[i] == ataque)
                    return i;
            }
            return -1;
        }

        public Ataque? SelectAtack()
        {
            if (_ataqueList.Count == 0)
                return null;
            Ataque? ataque = null;
            while (true)
            {
                int n = Utils.GetRandom(0, _ataqueList.Count - 1);
                var ataque = _ataqueList[n];
                if (ataque.Energia > Energia)
                {
                    Energia -= ataque.Energia;
                    break;
                }
            }
            return ataque;
            
        }

        public Pokemon Clone()
        {
            Pokemon result = new Pokemon(Id, Nivel, Energia);

            for (int i = 0 i < _ataqueList.Count; i++)
                result._ataqueList.Add(_ataqueList[i]);
            return result;
        }

        internal int GetAttackCount()
        {
            throw new NotImplementedException();
        }
    }
}
