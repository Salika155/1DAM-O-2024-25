namespace Blueprint
{
    public interface IBlueprint
    {
        
        // Definición de la interfaz IBluePrint que representa un plano o esquema que contiene formas.
        public interface IBluePrint
        {
            // Delegado que define un método para visitar una forma.
            public delegate void VisitDelegate(IShape shape);
            // Delegado que define un método para filtrar formas.
            public delegate bool FilterDelegate(IShape shape);

            // Método que obtiene el número total de formas en el plano.
            int GetShapeCount();
            // Método que obtiene la forma en una posición específica.
            IShape GetShapeAt(int index);
            // Método para agregar una nueva forma al plano.
            void AddShape(IShape shape);
            // Método para eliminar formas que cumplan con un criterio específico.
            void RemoveShape(FilterDelegate filter);
            // Método para eliminar una forma específica del plano.
            void RemoveShape(IShape shape);
            // Método que obtiene una forma que cumple con un criterio específico.
            IShape? GetShape(VisitDelegate visit);
        }
       
    }
}

//int GetShapeCount();
//IShape GetShapeAt(int index);
//void AddShape(IShape shape);
//void RemoveShape(ShapeFilter filter);
//void RemoveShape(IShape shape);
//IShape GetShape(ShapeFilter filter);
//List<IShape> FilterShapes(ShapeFilter filter);
//void Draw(ICanvas canvas);