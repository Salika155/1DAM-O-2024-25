namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBlueprint blueprint = new Blueprint();
            IShape shape1 = new Hector();
            IShape shape2 = new Circle("", new Color());

            blueprint.AddShape(shape2);
            blueprint.AddShape(shape1);

            shape2.Owner = null;

            var filteredList = blueprint.FilterShapes(f =>
            {
                return f.Rect.Position.X < 0.0;
            });
        }
    }
}
