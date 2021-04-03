namespace Base.Game.Factory
{
    public interface IFactory<T>
    {
        T GetObject();
        T GetObject(System.Type type);
    }
}
