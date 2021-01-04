namespace Base.Util
{
    public interface IFactory<T>
    {
        T GetObject();
    }
}
