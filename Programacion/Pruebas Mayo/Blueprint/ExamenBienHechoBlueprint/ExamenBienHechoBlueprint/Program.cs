using System.Numerics;

namespace Blueprint
{
    internal class Program
    {
        static void Main()
        {
            var p1 = new Point2D(1, 2);
            var p2 = new Point2D(4, 6);
            var vector = new Vector2D(3, 4);
            var moved = vector.Displace(p1);

            var rect = new Rect2D(p1, 10, 5);
            var color = new Color(0.5, 0.7, 1.0, 0.0);

            Console.WriteLine($"Punto original: {p1}");
            Console.WriteLine($"Punto movido: {moved}");
            Console.WriteLine($"Rectángulo: {rect}");
            Console.WriteLine($"Color: {color}");

            ShapeFilter sinArea = shape => !shape.HasArea;
            ShapeFilter porNombre = shape => shape.Name == "Círculo 1";


            var blueprint = new Blueprint("Plano Principal");
            var canvas = new Canvas();

            var circle = new Circle("Círculo 1", new Color(0.5, 0.5, 0.5, 0.0), new Point2D(5, 5), 3, blueprint);
            var point = new Point("Punto A", new Color(1, 0, 0, 0.0), new Point2D(1, 1), blueprint);

            blueprint.AddShape(circle);
            blueprint.AddShape(point);

            blueprint.Draw(canvas);

            var soloPuntos = blueprint.FilterShapes(s => !s.HasArea);
            Console.WriteLine("Formas sin área: " + soloPuntos.Count);
            var filtrados = blueprint.FilterShapes(sinArea);
            var unoPorNombre = blueprint.GetShape(porNombre);
        }
    }
}
