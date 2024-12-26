namespace AlgoritmoSwapNLetrasDePalabra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] palabra = ["H","O","L","A"];
            ArrayAlgoritmo.E1(palabra, 2);

            string[] palabra2 = ["S", "O", "F", "I", "A"];
            ArrayAlgoritmo.E1(palabra2, 3);

            string[] palabra3 = ["H", "O", "L", "A"];
            ArrayAlgoritmo.E2(palabra, 2);

            string[] palabra4 = ["S", "O", "F", "I", "A"];
            ArrayAlgoritmo.E2(palabra2, 3);


        }
    }
}
