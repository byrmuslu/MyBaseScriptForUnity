namespace Base.Utils
{
    public interface IFactory<T>
    {
        T GetObject();
    }
}
