using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgramacion3
{
    public enum AtaqueTypo
    {
        FISICO,
        ESPECIAL,
        OTRO
    }

    public class Ataque
    {
        private string? _nombre;
        private string? _descripcion;
        private int _energia;
        private int _nivelMinimo;
        private AtaqueTypo _tipo;

        public Ataque(string nombre, string description, int energia, int nivelMin, AtaqueTypo tipo)
        {
            _nombre = nombre;
            _descripcion = description;
            _energia = energia;
            _nivelMinimo = nivelMin;
            _tipo = tipo;
        }

        public string? GetNombreAtaque() => _nombre;

        public string? GetDescripcion() => _descripcion;

        public int GetEnergia() => _energia;

        public int GetNivelMinimo() => _nivelMinimo;

        public AtaqueTypo GetAtaqueTypo() => _tipo;

    }
}
