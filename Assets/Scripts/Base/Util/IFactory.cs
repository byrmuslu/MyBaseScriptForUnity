namespace Base.Util
{
    public interface IFactory
    {
        T GetObject<T>() where T : MyObject;
        T GetObject<T>(UnityEngine.Transform parent) where T : MyObject;
        T GetObject<T>(int variantID) where T : MyObject;
        T GetObject<T>(int variantID, UnityEngine.Transform parent) where T : MyObject;
    }
}