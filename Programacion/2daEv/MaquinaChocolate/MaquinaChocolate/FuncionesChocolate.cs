
namespace MaquinaChocolate
{
    public class FuncionesChocolate : IFuncionesChocolate
    {
        private readonly double _precio;
        private readonly double _cantidad;

        private readonly List<Sample> _samples = new List<Sample>();

        public FuncionesChocolate()
        {
            // Inicializar los samples predefinidos y ordenados
            _samples = new List<Sample>
            {
                new Sample(0.5, 40),  // 0.5 euros -> 40 ml
                new Sample(1.0, 100)  // 1.0 euros -> 100 ml
            };
        }

        //private readonly Dictionary<double, double> _sampleList =new Dictionary<double, double>();
        //para hacerlo con una lista necesitaria crear la clase sample y luego instancias de este para calcular
        //la posible interpolacion a dar de resultado.

        //posible necesidad de comprobar entre que dos muestras o samples se situa el dinero introducido
        //public double CalculateSampleMinNear(double precio)
        //{

        //    Sample muestraInferior = null;


        //}
        //public double CalculateSampleMaxNear(double precio)
        //{
        //    Sample muestraSuperior = null;


        //}

        //public double CalculateChocolateSample(/*sample A y sample B, y el dinero para interpolar */)
        //{
        //    //y = y1 + (x - x1) * ((y2 - y1) / (x2 - x1))
        //    throw new NotImplementedException();
        //}

        //public double CalculateChocolateSample(double dinero)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AddSample(double precio, double cantidad)
        //{
        //    throw new NotImplementedException();
        //}

        // Método para encontrar la muestra inferior (precio <= dinero) usando búsqueda binaria
        public Sample CalculateSampleMinNear(double dinero)
        {
            int left = 0;
            int right = _samples.Count - 1;
            Sample muestraInferior = null;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (_samples[mid].Precio <= dinero)
                {
                    muestraInferior = _samples[mid];
                    left = mid + 1; // Buscar en la mitad superior
                }
                else
                {
                    right = mid - 1; // Buscar en la mitad inferior
                }
            }

            if (muestraInferior == null)
            {
                throw new InvalidOperationException("No se encontró una muestra inferior para el dinero introducido.");
            }

            return muestraInferior;
        }

        public Sample CalculateSampleMaxNear(double dinero)
        {
            int left = 0;
            int right = _samples.Count - 1;
            Sample muestraSuperior = null;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (_samples[mid].Precio > dinero)
                {
                    muestraSuperior = _samples[mid];
                    right = mid - 1; // Buscar en la mitad inferior
                }
                else
                {
                    left = mid + 1; // Buscar en la mitad superior
                }
            }

            if (muestraSuperior == null)
            {
                throw new InvalidOperationException("No se encontró una muestra superior para el dinero introducido.");
            }

            return muestraSuperior;
        }

        // Método para calcular la cantidad de chocolate basada en el dinero introducido
        public double CalculateChocolate(Sample SL, double dinero, Sample SH)
        {
            if (SL.Precio == SH.Precio)
            {
                throw new InvalidOperationException("Los precios de las muestras no pueden ser iguales.");
            }

            double u = 0;
            double aux = SH.Precio - SL.Precio;
            double aux1 = dinero - SL.Precio;
            double aux2 = SH.Precio - dinero;

            if (aux1 < aux2)
            {
                u = aux1 / aux;
            }
            else if (aux1 > aux2)
            {
                u = aux2 / aux;
            }
            else
            {
                u = 0.5;
            }

            // Asegurarse de que u esté en el rango [0, 1]
            u = Math.Max(0, Math.Min(1, u));

            return Utils.GetInterpolacionLineal(SL.Cantidad, SH.Cantidad, u);
        }

        // Método principal para calcular la cantidad de chocolate
        public double CalculateChocolateSample(double dinero)
        {
            if (_samples.Count < 2)
            {
                throw new InvalidOperationException("Se necesitan al menos dos muestras para realizar la interpolación.");
            }

            // Obtener las muestras inferior y superior
            Sample muestraInferior = CalculateSampleMinNear(dinero);
            Sample muestraSuperior = CalculateSampleMaxNear(dinero);

            // Calcular la cantidad de chocolate
            return CalculateChocolate(muestraInferior, dinero, muestraSuperior);
        }
    }
}

