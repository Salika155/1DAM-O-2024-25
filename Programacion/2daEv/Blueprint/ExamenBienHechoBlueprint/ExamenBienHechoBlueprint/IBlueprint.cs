namespace Blueprint
{
    public interface IBlueprint
    {
        int GetShapeCount();
        IShape GetShapeAt(int index);
        void AddShape(IShape shape);
        void RemoveShape(ShapeFilter filter);
        IShape GetShape(ShapeFilter filter);
        List<IShape> FilterShapes(ShapeFilter filter);
        void Draw(ICanvas canvas);
    }
}