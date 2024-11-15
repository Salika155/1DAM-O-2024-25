using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SheepAndWolfs
{
    public class Oveja : Animal
    {
        private Coordenada _coordenada;
        private int _vida;
        private string _name = "";
        public Oveja() : base("", 500)
        {
            _vida = 500;
            _name = "oveja1";
        }


        //public void MoverOveja()
        //{

        //}

        //public void ComerHierba()
        //{

        //}
    }
}
