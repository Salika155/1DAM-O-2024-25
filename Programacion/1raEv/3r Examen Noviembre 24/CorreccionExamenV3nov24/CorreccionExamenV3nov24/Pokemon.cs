using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgramacion3
{
    public enum PokemonTipo
    {
        AGUA,
        FUEGO,
        PLANTA,
        TIERRA,
        PSIQUICO,
        HIELO,
        ELECTRICO,
        DRAGON

    }
    public class Pokemon
    {
        private int _id;
        private string? _nombre;
        private PokemonTipo _tipoPokemon;
        private int _nivel;
        private int _energia;
        private Ataque? _ataque;
        private readonly List<Ataque> _ataquesList;

        public Pokemon(int id, string? nombre, PokemonTipo tipo, int nivel, int energia)
        {
            _id = id;
            _nombre = nombre;
            _tipoPokemon = tipo;
            _nivel = nivel;
            _energia = energia;
            _ataquesList = new List<Ataque>();
        }

        //public Pokemon(List<Ataque> ataques)
        //{
        //    if (ataques == null)
        //        return;

        //    for (int i = 0; i < ataques.Count; i++)
        //    {
        //        string? nombreataque = "lanzallamas";
        //        string? descripcion = "quema mucho";
        //        int poderAtaque = 15;
        //        int nivelAtaque = 22;
        //        AtaqueTypo tipo = AtaqueTypo.ESPECIAL;
        //        Ataque at = new Ataque(nombreataque, descripcion, poderAtaque, nivelAtaque, tipo);
        //        ataques.Add(at);
        //    }
        //}

        public int GetId() => _id;
        public string? GetNombrePokemon() => _nombre;
        public PokemonTipo GetPokemonTipo() => _tipoPokemon;

        public int GetNivelPokemon() => _nivel;
        public int GetEnergiaPokemon() => _energia;
        public List<Ataque> GetAtaqueList() => _ataquesList;
        
        public void AddAtaque(Ataque? ataque)
        {
            if (ataque == null)
                return;
            _ataquesList.Add(ataque);
        }

        public bool ComprobarNivel()
        {
            bool puedeatacar = false;
            for (int i = 0; i < _ataquesList.Count; i++)
            {
                Ataque? a = _ataquesList[i];
                if (_nivel >= a.GetNivelMinimo())
                {
                    puedeatacar = true;
                }
            }
            return puedeatacar;
        }

        public void SetNivel(int nivel)
        {
            _nivel = nivel;
        }

        public void SetEnergia(int energia)
        {
            _energia = energia;
        }

        public Pokemon? Clone()
        {
            Pokemon? p = new(_id, _nombre, _tipoPokemon, _nivel, _energia);
            
            for (int i = 0; i < _ataquesList.Count; i++)
            {
                Ataque? ataque = _ataquesList[i];
                p.AddAtaque(new Ataque(ataque.GetNombreAtaque(),
                    ataque.GetDescripcion(), ataque.GetEnergia(),
                    ataque.GetNivelMinimo(), ataque.GetAtaqueTypo()));
            }
            return p;
        }

        public int CountAtaquesPokemon()
        {
            return _ataquesList.Count;
        }

        public Ataque? AtacarPokemon()
        {
            List<Ataque> ataquesPokemon = new List<Ataque>();
            
            for (int i = 0; i < _ataquesList.Count; i++)
            {
                Ataque? a = _ataquesList[i];

                if (_energia >= a.GetEnergia() && _nivel >= a.GetNivelMinimo())
                {
                    ataquesPokemon.Add(a);
                }
            }

            if (ataquesPokemon.Count == 0)
                return null;
            Ataque? ataqueSeleccionado = SeleccionarAtaque(ataquesPokemon);
            _energia -= ataqueSeleccionado.GetEnergia();

            return ataqueSeleccionado;
        }

        public Ataque? SeleccionarAtaque(List<Ataque> lista)
        {
            if (lista.Count == 0)
                return null;

            int index = Utils.GetRandomNumber(0, lista.Count);
            Ataque? ataque = lista[index];
            return ataque;
        }
    }
}
