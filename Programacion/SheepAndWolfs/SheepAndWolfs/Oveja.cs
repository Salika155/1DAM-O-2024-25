using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SheepAndWolfs
{
    //TODO: esto funciona
    public class Oveja : Animal
    {
        private int _vida;
        public readonly string? Nombre = "";
        public int Vida;
        public AnimalType type = AnimalType.OVEJA;
        public Coordenada coordenada;

        public Oveja(string name) : base(name, 500)
        {
            
        }

        

        //si los metodos vienen de la clase padre animal, habra que sobreescribirlos aqui

    }
}
