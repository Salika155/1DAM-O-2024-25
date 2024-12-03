namespace Herencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * 
             * 
             * Animal a1 = new Animal();
             * Animal a2 = new Lobo();
             * Animal a3 = new Oveja();
             * 
             * Lobo l1 = a2;
             * 
             * Lobo l1 = (Lobo)a2
             * 
             * 
            //if (a2 is lobo l2)
            {
            }



            */

            Animal a1 = new Animal();
            Animal a2 = new Oveja();
            Animal a3 = new Lobo();


            a1.ExecuteTurn();
            a2.ExecuteTurn();
            a3.ExecuteTurn();


        }
    }
}
