namespace BlueprintCorregidoClase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBluePrint blueprint = new BluePrint();
            IShape shape1 = new Hector();
            IShap3 shape2 = new Circle("", new Color());

            blueprint.AddShape(shape2);
            blueprint.AddShape(shape1);

            var filteredList = blueprint.FilterShapes(f => f.Rect.Position.X < 0.0);
        }
    }
}
