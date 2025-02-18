namespace MaquinaChocolate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FuncionesChocolate f =new FuncionesChocolate();
            //aqui mete los samples 

            //se supone que tenemos que hacer una maquina expendedora de chocolate liquido que en funcion del dinero introducido
            //recalcule la cantidad de chocolate que devuelve -> interpolacion de la cantidad con los limites de muestra que esten
            //inmediatamente por debajo y por arriba para calcularlo en funcion del dinero.
            // Programa principal

            FuncionesChocolate maquina = new FuncionesChocolate();

            // Calcular la cantidad de chocolate para 0.80 euros
            double dineroIntroducido = 0.80;
            double cantidadChocolate = maquina.CalculateChocolateSample(dineroIntroducido);

            Console.WriteLine($"Para {dineroIntroducido} euros, obtienes {cantidadChocolate} ml de chocolate.");
        }
    }
}
