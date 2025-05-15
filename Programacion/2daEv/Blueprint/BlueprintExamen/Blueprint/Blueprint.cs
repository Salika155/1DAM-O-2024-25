using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint
{
    class Blueprint : IBlueprint
    {
        private string? _name;
        private List<Shape> _shapes;

        public string? Name { get => _name; }

        public Blueprint(string? name)
        {
            _name = name;

        }

        public void Displace(Vector2D direction)
        {
            throw new NotImplementedException();
        }

        public void Draw(ICanvas canvas)
        {
            Console.WriteLine(""+ canvas);
        }
    }
}
