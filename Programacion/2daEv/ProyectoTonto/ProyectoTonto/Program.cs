namespace ProyectoTonto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> l = new();

            //Utils.Filter(l, val) =>
            //{
            //    return val.Contains("a")
            //});

            //
            var a = Funciones.Filter (l, val => val.Contains("a"));
            


            var list = Utils.Gen<int>(5, i => i * 2);


            List<int> lenter = new();


            var result = Utils.FilterProfundo(lenter, value => value > 10).FilterProfundo(value => value < 20).ToList();
        }
    }
}
