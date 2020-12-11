namespace Base.Game.Command
{
    public interface IRotateableObject
    {
        UnityEngine.Transform GetTransform();
        float GetMultipierValue();
        float GetRotateSpeed();
    }
}
