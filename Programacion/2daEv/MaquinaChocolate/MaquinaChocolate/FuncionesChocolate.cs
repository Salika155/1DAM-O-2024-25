
namespace MaquinaChocolate
{
    public class FuncionesChocolate : IFuncionesChocolate
    {
        private readonly double _precio;
        private readonly double _cantidad;

        //private readonly Dictionary<double, double> _sampleList =new Dictionary<double, double>();
        //para hacerlo con una lista necesitaria crear la clase sample y luego instancias de este para calcular
        //la posible interpolacion a dar de resultado.

        //posible necesidad de comprobar entre que dos muestras o samples se situa el dinero introducido
        public double CalculateSampleMinNear(double precio)
        {
            double calculatemin = 0; 

            switch (precio)
            {
                case 0:
                    return _cantidad;
            }
            return calculatemin;
        }
        public double CalculateSampleMaxNear(double precio)
        {
            double calculatemin = 0;

            switch (precio)
            {
                case 0:
                    return _cantidad;
            }
            return calculatemin;
        }


        public double CalculateChocolateSample(/*sample A y sample B, y el dinero para interpolar */)
        {
            //y = y1 + (x - x1) * ((y2 - y1) / (x2 - x1))
            throw new NotImplementedException();
        }

        
        //public void AddSample(double precio, double cantidad)
        //{
        //    _sampleList.Add(precio, cantidad);
        //}

        

    }
}
