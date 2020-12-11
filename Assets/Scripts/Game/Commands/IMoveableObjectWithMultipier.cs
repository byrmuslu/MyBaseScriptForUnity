namespace Base.Game.Command
{
    public interface IMoveableObjectWithMultipier
    {
        UnityEngine.Transform GetTransform();
        float GetSpeed();
        float GetMultipierVerticalValue();
        float GetMultipierHorizontalValue();
    }
}
