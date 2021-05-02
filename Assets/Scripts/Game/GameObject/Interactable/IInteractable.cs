namespace Base.Game.GameObject.Interactable
{
    using Base.Game.GameObject.Interactional;
    public interface IInteractable
    {
        UnityEngine.Transform Transform { get; }
        void Interact(IInteractional obj);
        void Activate();
        void Deactivate();
    }
}