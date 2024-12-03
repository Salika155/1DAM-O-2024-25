using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen3Corregido
{
    internal class Pokedex
    {
        private readonly List<Pokemon> PokemonList = new List<Pokemon>();

        public void Add(Pokemon pokemon)
        {
            if (pokemon == null)
                return;
            if (Contains(pokemon))
                return;
            PokemonList.Add(pokemon);
        }

        //esto tendria que ser un long
        public void RemovePokemonWithID(int id)
        {
            for (int i = 0; i < PokemonList.Count; i++)
            {
                if (PokemonList[i].Id == id)
                {
                    PokemonList.RemoveAt(i);
                    i--;
                }
            }
        }

        private object IndexOfPokemonWithId(int id)
        {
            throw new NotImplementedException();
        }

        private bool Contains(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public List<Pokemon> GetPokemonsWithHighAttackCount()
        {
            List<Pokemon> result = new();

            int n = GetPokemonsWithHighAttackCount();
            for (int i = 0; i < PokemonList.Count; i++)
            {
                if (PokemonList[i].GetAttackCount() == n)
                    result.Add(PokemonList[i]);
            }
            return result;

        }

        public int GetPokemonsWithHighAttackCount()
        {
            int result = 0;
            for (int i = 0; i < PokemonList.Count; i++)
            {
                if (PokemonList[i].GetAttackCount() > result)
                    result = PokemonList[i].GetAttackCount();
            }
            return result;
        }

    }
}
