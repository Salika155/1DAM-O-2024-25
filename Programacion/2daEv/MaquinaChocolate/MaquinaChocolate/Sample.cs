using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaChocolate
{
    public class Sample
    {
        public double Precio { get; set; }
        public double Cantidad { get; set; }

        public Sample(double precio, double cantidad)
        {
            Precio = precio;
            Cantidad = cantidad;
        }
    }
}
