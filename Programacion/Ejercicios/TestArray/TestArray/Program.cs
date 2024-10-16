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
            int[] newarray2 = ExercisesArray.RemoveAt(array, index);
            Console.WriteLine(newarray2);


            int indexn = 3;
            int indexvalor = 15;
            int[] newarray3 = ExercisesArray.Insert(array, indexn, indexvalor);
            Console.WriteLine(newarray3);

            int[] array1 = { 1, 3, 5 };
            int[] array2 = { 2, 4, 6, 8 };

            int[] mergedArray = ExercisesArray.MergeSortArray(array1, array2);
            Console.WriteLine(mergedArray);
        }
    }
}
