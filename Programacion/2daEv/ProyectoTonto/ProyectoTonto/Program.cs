namespace ProyectoTonto
{

    public class Message
    {
        public bool Checked { get; set; }
        public DateTime Time { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Sender { get; set; } = string.Empty;
        public string Receiver { get; set; } = string.Empty;
    }

    public struct Estructura
    {

    }
    
    public record Message1(
        bool Checked,
        DateTime Time,
        string Content);

    public class Program
    {
        public static int F1(
                ref int number, 
                out int otro, 
                in int otromas) /*posicion de memoria ram donde hay un entero, ref escribe y lee | variable out solo escribe, y tienes que asegurar que escribes | in solo lee, solo utilizable en struct*/
        {
            otro = 20;
            number++;
            number = 2;
            int pp = number;
            return number;
        }
        static void Main(string[] args)
        {
            int k = 10;
            int i = 10; /*i y j valen 2 */
            int j = F1(ref i, out k, 20);

            List<string> l = new();

            //Utils.Filter(l, val) =>
            //{
            //    return val.Contains("a")
            //});

            //
            var a = Funciones.Filter(l, val => val.Contains("a"));



            var list = Utils.Gen<int>(5, i => i * 2);


            List<int> lenter = new() { 5, 10, 15, 20, 25, 30 };

            var result = Utils.FilterProfundo(lenter, value => value > 10).
                FilterProfundo(value => value < 20).ToList();

            var l1 = lenter
                .Where(value => false)
                .Where(value => false);


            Estructura estruct = new Estructura();


            Dictionary<string, bool> odiarAJaime 
                = new Dictionary<string, bool>();

            //esto peta
            odiarAJaime.Add("Marcos", true);
            odiarAJaime.Add("Jaime", false);
            //esto intenta meterlo
            odiarAJaime.TryAdd("Marcos", true);

            odiarAJaime["Javi"] = false;
            odiarAJaime["Javi"] = true;

            bool value = odiarAJaime["Jaime"];
            var nombres = odiarAJaime.Where(item => item.Value == true).ToDictionary().Keys;
            //nombre de las personas que odian a jaime

            //manera estandar de acceder a un elemento en un diccionario:
            bool v;
            if (odiarAJaime.TryGetValue("Javi", out v))
            {
                v = true;
                odiarAJaime["Javi"] = v;
                //si esta escribe en la variable v el valor del bool de si esta o no esta
            }
        } 
    }
}
