﻿namespace DelegadosPredicadosLambdas
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
            Predicate<int> elDelegadoPredi = new Predicate<int>(Funciones.DamePares);
            List<int> numPares = _listaNumeros.FindAll(elDelegadoPredi);

            foreach (int n in numPares)
            {
                Console.WriteLine(n);
            }

            List<Delegado.Persona> gente = new();
            Delegado.Persona p1 = new Delegado.Persona();
            p1.Nombre = "Juan";
            p1.Edad = 18;
            Delegado.Persona p2 = new Delegado.Persona();
            p2.Nombre = "Maria";
            p2.Edad = 28;
            Delegado.Persona p3 = new Delegado.Persona();
            p3.Nombre = "Ana";
            p3.Edad = 37;

            gente.AddRange(new Delegado.Persona[] { p1, p2, p3 });
            Predicate<Delegado.Persona> elPredicadoPersonas = new Predicate<Delegado.Persona>(Funciones.ExisteJuan);
            bool existe = gente.Exists(elPredicadoPersonas);
            Predicate<Delegado.Persona> elPredicadoPersonasMayores = new Predicate<Delegado.Persona>(Funciones.ExistenMayoresEdad);
            bool existenMayores = gente.Exists(elPredicadoPersonasMayores);

            //uso del delegado
            OperacionesMatematicas op = new(Funciones.Cuadrado);
            Console.WriteLine(op(4));
            //expresion lambda
            //parametro que se le pasa izquierda, derecha lo que se quiere que haga
            OperacionesMatematicas op2 = new(n => n * n);
            Console.WriteLine(op2(5));
            OperacionesMatematicasSuma ops1 = new(Funciones.SumaNumeros);
            Console.WriteLine(ops1(4, 5));
            //cuando parametros exp lambda son + de 1 van entre parentesis
            OperacionesMatematicasSuma ops2 = new((n1, n2) => n1 + n2);
            Console.WriteLine(ops2(1, 2));


            //lambdas y delegados complejos
            List<int> valoresLista = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
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
            ComparatorPersonasGenerico<Delegado.Persona> compararPersonas = (p1, p2) => p1.Nombre == p2.Nombre;

            // Comparar edades
            bool igualesEdades = Funciones.CompararElementos(18, 18, (a, b) => a == b);
            Console.WriteLine("¿Edades iguales? " + igualesEdades);

            // Comparar nombres
            bool igualesNombres = Funciones.CompararElementos("Ana", "Ana", (a, b) => a == b);
            Console.WriteLine("¿Nombres iguales? " + igualesNombres);

            // Comparar personas por nombre
            bool mismosNombres = Funciones.CompararElementos(p1, p2, (per1, per2) => per1.Nombre == per2.Nombre);
            Console.WriteLine("¿Personas con mismo nombre? " + mismosNombres);

            //DICCIONARIO

            Dictionary<int, string> mydict = new Dictionary<int, string>()
            {
                {1, "Jose" },
                {2, "Jaime" },
                {3, "Jesus" },
                {4, "Juan" }
            };

            foreach (KeyValuePair<int, string> estudiantes in mydict)
            {
                Console.WriteLine($"{estudiantes.Key} - {estudiantes.Value}");
            }

            for (int i = 0; i <= mydict.Count - 1; i++)
            {
                Console.WriteLine($"{mydict.ElementAt(i).Key} - {mydict.ElementAt(i).Value}");


            }

            Dictionary<string, int> edades = new();
            //rellenar diccionario
            edades.Add("Juan", 18);
            edades.Add("Diana", 35);
            //introducidos como array
            edades["Maria"] = 25;
            edades["Antonio"] = 29;
            //recorrer diccionario
            foreach(KeyValuePair<string, int> persona in edades)
            {
                Console.WriteLine("Nombre: " + persona.Key + "Edad: " + persona.Value);
                Console.WriteLine("Nombre: {0}, Edad: {1}", persona.Key, persona.Value);
            }
            //STACK

            Stack<int> stack = new();
            foreach(int n in new int[5] {2, 4, 6, 8, 10})
            {
                stack.Push(n);
            }

            stack.Pop(); 
            foreach(int n in stack)
            {
                Console.WriteLine(n);
            }

        
        }

        //delegado predicado
        public delegate int OperacionesMatematicas(int numb);
        public delegate int OperacionesMatematicasSuma(int num1, int num2);

        //comparar edad dos personas
        public delegate bool ComparatorPersonas(int edad1, int edad2);
        public delegate bool ComparatorPersonasGenerico<T>(T persona1, T persona2);
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

