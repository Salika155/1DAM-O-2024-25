using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgramacion3
{
    public class Pokedex
    {
        private readonly List<Pokemon> _pokemonList = new();

        public void AddPokemon(Pokemon pokemon)
        {
            if (pokemon == null)
                return;

            for (int i = 0; i < _pokemonList.Count; i++)
            {
                if (pokemon == _pokemonList[i])
                    return;                 
            }
            _pokemonList.Add(pokemon);
        }

        public void RemovePokemonAtWithID(int id)
        {
            if (id < 0 || id >= _pokemonList.Count)
                return;

            for (int i = 0; i < _pokemonList.Count; i++)
            {
                Pokemon p = _pokemonList[i];
                if (p.GetId() == id)
                {
                    _pokemonList.RemoveAt(i);
                    break;
                }
            }
        }

        public Pokemon? GetPokemonPorNombre(string? nombre)
        {
            for (int i = 0; i < _pokemonList.Count; i++)
            {
                Pokemon p = _pokemonList[i];
                if (p.GetNombrePokemon() == nombre)
                    return p;
            }
            return null;
        }

        public int GetPokemonAlmacenadosCount() => _pokemonList.Count;
    }
}
