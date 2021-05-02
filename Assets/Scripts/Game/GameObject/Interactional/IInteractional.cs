namespace Base.Game.GameObject.Interactional
{
    public interface IInteractional
    {
        UnityEngine.Transform Transform { get; }
        void Activate();
        void Deactivate();
    }
}
