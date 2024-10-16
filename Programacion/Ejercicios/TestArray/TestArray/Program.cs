namespace TestArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[]{ 1, 2, 3, 4, 5 };

            int n = 6;

            int [] newarray = ExercisesArray.Append(array, n);
            Console.WriteLine(newarray);

            int index = 5;
            int[] newarray2 = ExercisesArray.Remove(array, index);
            Console.WriteLine(newarray2);
        }
    }
}
