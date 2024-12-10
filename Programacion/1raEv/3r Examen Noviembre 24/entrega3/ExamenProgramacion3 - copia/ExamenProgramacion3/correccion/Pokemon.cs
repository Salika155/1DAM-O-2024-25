using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgramacion3
{
    //public enum PokemonTipo
    //{
    //    AGUA,
    //    FUEGO,
    //    PLANTA,
    //    TIERRA,
    //    PSIQUICO,
    //    HIELO,
    //    ELECTRICO,
    //    DRAGON

    //}
    //public class Pokemon
    //{
    //    private int _id;
    //    private string? _nombre;
    //    private PokemonTipo _tipoPokemon;
    //    private int _nivel;
    //    private int _energia;
    //    private Ataque? _ataque;
    //    private readonly List<Ataque> _ataquesList;

    //    public Pokemon()
    //    {

    //    }

    //    public Pokemon(List<Ataque> ataques)
    //    {
    //        if (ataques == null)
    //            return;

    //        for (int i = 0; i < ataques.Count; i++)
    //        {
    //            Ataque at = new Ataque();
    //            ataques.Add(at);
    //        }
    //    }

    //    public int GetId() => _id;
    //    public string? GetNombrePokemon() => _nombre;
    //    public PokemonTipo GetPokemonTipo() => _tipoPokemon;

    //    public int GetNivelPokemon() => _nivel;
    //    public int GetEnergiaPokemon() => _energia;
    //    public Ataque? GetAtaquesPokemon()
    //    {
    //        return _ataque;
    //    }

    //    public List<Ataque> GetAtaqueList(Pokemon pok)
    //    {
    //        List<Ataque> ataques = pok._ataquesList;
    //        if (pok == null)
    //        {
    //            return pok._ataquesList;
    //        }
    //        return ataques;
    //    }

    //    public void AddAtaque(Ataque ataque)
    //    {
    //        if (ataque == null)
    //            return;
    //        _ataquesList.Add(ataque);
    //    }

    //    public bool ComprobarNivel(Pokemon pokemon)
    //    {
    //        for (int i = 0; i < _ataquesList.Count; i++)
    //        {
    //            Ataque a = _ataquesList[i];
    //            if (a.GetNivelMinimo() >= pokemon.GetNivelPokemon())
    //                return true;
    //        }
    //        return false;
    //    }

    //    public void SetNivel(int nivel)
    //    {
    //        _nivel = nivel;
    //    }

    //    public void SetEnergia(int energia)
    //    {
    //        _energia = energia;
    //    }

    //    public Pokemon Clone(Pokemon pokemon)
    //    {
    //        Pokemon p = new();
    //        {
    //            p._ataque = pokemon._ataque;
    //            p._energia = pokemon._energia;
    //            p._id = pokemon._id;
    //            p._nivel = pokemon._nivel;
    //            p._nombre = pokemon._nombre;
    //            p._tipoPokemon = pokemon._tipoPokemon;
    //            //p._ataquesList = pokemon.GetAtaquesPokemon();
    //        }
    //        return p;
    //    }

    //    public int CountAtaquesPokemon()
    //    {
    //        return _ataquesList.Count;
    //    }

    //    public Ataque AtacarPokemon(Pokemon pokemon)
    //    {
            
    //        for (int i = 0; i < _ataquesList.Count; i++)
    //        {
    //            int position = Utils.GetRandomNumber(1, CountAtaquesPokemon());
    //            Ataque a = _ataquesList[position];
                
    //            if (_ataquesList[i] == a)
    //            {
    //                return a;
    //            }
    //        }
    //        return null;
            
    //    }
    //}
}
