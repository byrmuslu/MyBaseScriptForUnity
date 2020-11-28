namespace Base.Game.Commands
{
    using UnityEngine;

    public interface IMoveable
    {
        Transform GetTransform();
        float GetSpeed();
        float GetMultipierVertical();
        float GetMultipierHorizontal();
    }
}
