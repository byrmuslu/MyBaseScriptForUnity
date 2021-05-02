namespace Base.Game.Factory
{
    public interface IFactory<T>
    {
        T GetObject();
        T GetObject(System.Type type);
        T GetObject(System.Type type, Base.Util.ObjectType objType);
    }
}