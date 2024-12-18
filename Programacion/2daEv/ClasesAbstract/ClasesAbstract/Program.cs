namespace ClasesAbstract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayUtils.Filter(array, (value)) => value.Contains('a'));
            int[] array = { 1, 5, 7, 3, -1 };
            //var filterArray = ArrayUtils.Filter(array, (int value) =>
            //{
            //    return value >= 0;
            //});
            var filterArray = ArrayUtils.Filter(array, value => value < 0);
            //---------------------------------------------------------------------

            int[] numeros = { 1, 2, 3, 4, 5, 6 };
            var filteredArray1 = ArrayUtils.Filter(numeros, ArrayUtils.IsPair);
            var filteredArray2 = ArrayUtils.Filter(numeros, value => value % 2 == 0);

            int[] array1 = { 1, 5, 7, 3, -1 };
            int umbral = 3;

            // Usamos una expresión lambda que llama a IsMayor con el umbral
            var filteredArray = ArrayUtils.Filter(array, value => ArrayUtils.IsMayor(value, umbral));

            //--------------------------------------------------------------------------------------------

            int[] arrayInt = { 1, -2, 3, -4, 5, -6 };
            var filteredArrayInt = ArrayUtils.Filter(arrayInt, value => value > 0);

            string[] arrayString = { "manzana", "pera", "plátano", "uva", "cereza" };
            var filteredArrayString = ArrayUtils.Filter(arrayString, value => value.Contains("a"));

            double[] arrayDouble = { 1.5, 2.7, 3.1, -0.4, 6.8 };
            double threshold = 2.0;
            var filteredArrayDouble = ArrayUtils.Filter(arrayDouble, value => value > threshold);

                DateTime[] arrayDates = {
                    new DateTime(2024, 1, 1),
                    new DateTime(2024, 5, 1),
                    new DateTime(2023, 12, 31),
                    new DateTime(2024, 7, 15)
                    };

                DateTime filterDate = new DateTime(2024, 1, 1);
                var filteredArrayDates = ArrayUtils.Filter(arrayDates, date => date > filterDate);
        }
    }
}
