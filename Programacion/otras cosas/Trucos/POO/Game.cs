using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
     
    public class Game
    {
        private decimal _money;
        public string Name { get; set; }
        public decimal Prize
        {
            get { return _money; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _money = value;
            }
        }

        public Game(string name, decimal prize)
        {
            Name = name;
            Prize = prize;
        }

        public string GetInfo()
        {
            return "Nombre: " + Name + ", Precio: $ " + Prize; 
        }

    }
}
