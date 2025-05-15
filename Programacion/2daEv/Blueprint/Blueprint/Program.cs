namespace Blueprint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Rect2D Rect es inmutable

            Point2D point = new Point2D(5, 6);
            Point2D point2 = new Point2D(6, 8);

            Vector2D vector = new Vector2D(point, point2);
            Color color = new Color(1.0, 2.0, 2.0, 1.0);
        }
    }
}
