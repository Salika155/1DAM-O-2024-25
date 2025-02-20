namespace ProyectoTonto
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> l = new();

            //Utils.Filter(l, val) =>
            //{
            //    return val.Contains("a")
            //});

            //
            var a = Funciones.Filter(l, val => val.Contains("a"));



            var list = Utils.Gen<int>(5, i => i * 2);


            List<int> lenter = new() { 5, 10, 15, 20, 25, 30 };

            var result = Utils.FilterProfundo(lenter, value => value > 10).FilterProfundo(value => value < 20).ToList();


            foreach (var item in result)
            {
                Console.WriteLine(item); // 15
            }
        } 
    }
}
