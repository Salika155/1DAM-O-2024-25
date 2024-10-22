using System.Threading.Channels;

namespace Trucos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = 100;
            string message = "";

            Console.WriteLine(message);

            Prueba? prueba = null;

            if(prueba != null)
            {
                Console.WriteLine(prueba.name);
            }

            //con null condicional seria asi sin necesidad del if:
            Console.WriteLine(prueba?.name);

            //ejemplo con listas y con el where
            List<string> names = new List<string>()
            {
                "Ana", "Juan", "Alejandro"
            };

            List<string> names2 = new List<string>();
            foreach(string name in names)
            {
                if (name.ToUpper()[0] == 'A')
                    names2.Add(name);
            }

            //caso switch
            int op = 4;

            switch (op)
            {
                case 1:
                    Console.WriteLine("1");
                    break;
                case 2:
                    Console.WriteLine("2");
                    break;
                case 3:
                    Console.WriteLine("3");
                    break;
                case 4:
                    Console.WriteLine("4");
                    break;
                default:
                    Console.WriteLine("Def");
                    break;

            }

            //esto seria pero a nivel superior y no funciona
            //Prueba[] pruebas = new Prueba[]
            //{
            //    () => Console.WriteLine("1"),
            //    () => Console.WriteLine("2"),
            //    () => Console.WriteLine("3"),
            //    () => Console.WriteLine("4"),
            //    () => Console.WriteLine("def"),
            //};

            //if (op > 0 && op <= pruebas.Length)
            //{
            //    pruebas[op - 1]();
            //}
            //else
            //{
            //    Console.WriteLine("Esta fuera");
            //}

            //        var result = new Maybe<int>(20)
            //.Bind(x => MaybeDivide(x, 2))  // Dividir 20 entre 2
            //.Bind(x => MaybeAddFive(x));    // Sumar 5 al resultado
        }
    }
}
