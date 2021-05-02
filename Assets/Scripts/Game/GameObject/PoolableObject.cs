using Base.Util;

namespace Base.Game.GameObject
{
    public class PoolableObject : MyObject
    {
        public virtual ObjectType Type { get => ObjectType.TYPE1; }
    }
}
