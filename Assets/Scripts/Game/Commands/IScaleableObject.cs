namespace Base.Game.Command
{
    public interface IScaleableObject
    {
        UnityEngine.Transform GetTransform();
        float GetScaleSpeed();
        float GetMultipierValue();
    }
}
