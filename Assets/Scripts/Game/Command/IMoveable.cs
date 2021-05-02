namespace Base.Game.Command
{
    using UnityEngine;
    public interface IMoveable
    {
        Transform Transform { get; }
        Rigidbody RigidBody { get; }
        float MovementSpeed { get; }
        float RotationSpeed { get; }
    }
}
