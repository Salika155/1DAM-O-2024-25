namespace ObjectTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1;
            s1 = new Student();
            s1.SayHola();
            s1.Gender = GenderType.FEMALE;

            /*
             Student s1 = new Student();
            s1.name = "Juan";
            string hello1 = s1.SayHola();
            Console.WriteLine(hello1);

            Student s2 = new Student();
            s2.name = "Adrian";
            string hello2 = s2.SayHola();
            Console.WriteLine(hello2);
             */


            Student s2;
            s1 = s1;
            s2.NIA = 5;

            s2 = new Student();
            s1.NIA = 3;
            Student s3 = s1;
            Console.WriteLine(s1.NIA);
            Console.WriteLine(s3.NIA);

            s1 = null;
            Console.WriteLine(s3.NIA);

            Student s4 = s1;
            s3.Name = "Juan";
            s2.Name = "Ana";
            //s4.name = "Silvia";

            s4 = s2;
            s2 = null;
            s3 = null;

        }
    }
}
