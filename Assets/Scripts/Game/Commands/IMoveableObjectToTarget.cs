namespace Base.Game.Command
{
    public interface IMoveableObjectToTarget
    {
        UnityEngine.Transform GetTransform();
        float GetSpeed();
        UnityEngine.Vector3 GetTarget();
    }
}
