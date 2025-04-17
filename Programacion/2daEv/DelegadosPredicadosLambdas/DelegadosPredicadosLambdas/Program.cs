namespace DelegadosPredicadosLambdas
{
    public class Program
    {
        // Definición de los delegados
        delegate void ObjetoDelegado();
        delegate void ObjetoStringDelegado(string mensaje);

        static void Main(string[] args)
        {
            string mensaje = "usando el delegado tradicional";
            string mensajeLambda = "usando lambda";

            // 🔸 Estilo 1: Delegado tradicional (usa el tipo adecuado)
            ObjetoStringDelegado delegadoTradicional = MensajeBienvenida.SaludoBienvenida;
            delegadoTradicional(mensaje);

            // 🔸 Estilo 2: Lambda que adapta el método a un delegado sin parámetros
            ObjetoDelegado delegadoLambda = () => MensajeBienvenida.SaludoBienvenida(mensajeLambda);
            delegadoLambda();

            // 🔸 Delegado directo sin parámetros (despedida)
            ObjetoDelegado delegadoDespedida = MensajeDespedida.SaludoDespedida;
            delegadoDespedida();

            List<int> _listaNumeros = new();
            _listaNumeros.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            //declaramos delegado predicado
            Predicate<int> elDelegadoPredi = new Predicate<int>(DamePares);
            List<int> numPares = _listaNumeros.FindAll(elDelegadoPredi);

            foreach(int n in numPares)
            {
                Console.WriteLine(n);
            }

            List<Persona> gente = new();
            Persona p1 = new Persona();
            p1.Nombre = "Juan";
            p1.Edad = 18;
            Persona p2 = new Persona();
            p2.Nombre = "Maria";
            p2.Edad = 28;
            Persona p3 = new Persona();
            p3.Nombre = "Ana";
            p3.Edad = 37;

            gente.AddRange(new Persona[] { p1, p2, p3 });
            Predicate<Persona> elPredicadoPersonas = new Predicate<Persona>(ExisteJuan);
            bool existe = gente.Exists(elPredicadoPersonas);
            Predicate<Persona> elPredicadoPersonasMayores = new Predicate<Persona>(ExistenMayoresEdad);
            bool existenMayores = gente.Exists(elPredicadoPersonasMayores);

            //uso del delegado
            OperacionesMatematicas op = new(Cuadrado);
            Console.WriteLine(op(4));
            //expresion lambda
            //parametro que se le pasa izquierda, derecha lo que se quiere que haga
            OperacionesMatematicas op2 = new(n => n * n);
            Console.WriteLine(op2(5));
            OperacionesMatematicasSuma ops1 = new(SumaNumeros);
            Console.WriteLine(ops1(4, 5));
            //cuando parametros exp lambda son + de 1 van entre parentesis
            OperacionesMatematicasSuma ops2 = new((n1, n2) => n1 + n2);
            Console.WriteLine(ops2(1, 2));


            //lambdas y delegados complejos
            List<int> valoresLista = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9};
            List<int> valoresListaPares = valoresLista.FindAll(i => i % 2 == 0);
            foreach (var i in valoresListaPares)
                Console.WriteLine(i);
            valoresListaPares.ForEach(num => Console.WriteLine(num));
            //lo mismo pero con varias lineas, para ampliar lineas de codigo se usan {}
            valoresListaPares.ForEach(num =>
            {
                Console.WriteLine("el numero par que buscas es: ");
                Console.WriteLine(num);
                });

            //llambda compara edad personas que sean iguales o no
            ComparatorPersonas comparaEdad = (n1, n2) => n1 == n2;
            Console.WriteLine(comparaEdad(p1.Edad, p2.Edad));
            //ComparatorPersonasGenerico<T> comparatorGenerico = (n1, n2) => n1 == n2;
            ComparatorPersonasGenerico<int> compararEdades = (edad1, edad2) => edad1 == edad2;
            ComparatorPersonasGenerico<string> compararNombres = (n1, n2) => n1 == n2;
            ComparatorPersonasGenerico<Persona> compararPersonas = (p1, p2) => p1.Nombre == p2.Nombre;

            // Comparar edades
            bool igualesEdades = CompararElementos(18, 18, (a, b) => a == b);
            Console.WriteLine("¿Edades iguales? " + igualesEdades);

            // Comparar nombres
            bool igualesNombres = CompararElementos("Ana", "Ana", (a, b) => a == b);
            Console.WriteLine("¿Nombres iguales? " + igualesNombres);

            // Comparar personas por nombre
            bool mismosNombres = CompararElementos(p1, p2, (per1, per2) => per1.Nombre == per2.Nombre);
            Console.WriteLine("¿Personas con mismo nombre? " + mismosNombres);
        }

        //delegado predicado
        static bool DamePares(int n)
        {
            return (n % 2 == 0) ? true : false;
        }
        static bool ExisteJuan(Persona p)
        {
            return (p.Nombre == "Juan") ? true : false;
        }
        static bool ExistenMayoresEdad(Persona p)
        {
            return (p.Edad >= 18) ? true : false;
        }

        public static int Cuadrado(int n)
        {
            return n * n;
        }

        public static int SumaNumeros(int n1, int n2) => n1 + n2;

        public static bool CompararElementos<T>(T element1, T element2, ComparatorPersonasGenerico<T> comparator)
        {
            return comparator(element1, element2);
        }

        public delegate int OperacionesMatematicas(int numb);
        public delegate int OperacionesMatematicasSuma(int num1, int num2);

        //comparar edad dos personas
        public delegate bool ComparatorPersonas(int edad1, int edad2);
        public delegate bool ComparatorPersonasGenerico<T>(T persona1, T persona2);
    }

    class Persona
    {
        private string _nombre = string.Empty;
        private int _edad;

        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Edad { get => _edad; set => _edad = value; }
    }

    #region MensajeBienvenida
    class MensajeBienvenida
    {
        public static void SaludoBienvenida(string msj)
        {
            Console.WriteLine("👋 Hola, soy Peter, {0}", msj);
        }
    }
    #endregion
    #region MensajeDespedida
    class MensajeDespedida
    {
        public static void SaludoDespedida()
        {
            Console.WriteLine("👋 Que te den mala pecora");
        }
    }
    #endregion
}

