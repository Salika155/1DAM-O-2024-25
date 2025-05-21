namespace Blueprint
{
    public interface IBlueprint
    {
        void Draw(ICanvas canvas);
        void Displace(Vector2D direction);
    }
}