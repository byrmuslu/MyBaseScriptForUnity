namespace Base.Util
{
    using Base.Game.GameObject;
    public interface IFactory
    {
        PoolableObject GetObject();
        PoolableObject GetObject(System.Type type);
        PoolableObject GetObject(System.Type type, ObjectType objType);
    }
}