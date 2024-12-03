

namespace ObjectTest
{
    public class Student
    {
        public string Name;
        public string DNI;
        public int NIA;
        public int Age;
        public GenderType Gender = GenderType.UNKNOWN;

        public string SayHola() => "Hola soy: " + Name;
    }
}
