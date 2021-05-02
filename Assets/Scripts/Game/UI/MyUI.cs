namespace Base.Game.UI
{
    using Base.Game.Signal;
    using UnityEngine;

    public class MyUI : MonoBehaviour
    {
        private void Awake()
        {
            SignalManager.Register(this);
            Initialize();
        }

        protected virtual void OnDestroy()
        {
            SignalManager.UnRegister(this);
        }

        protected virtual void Initialize()
        {

        }

        public virtual void Activate()
        {
            gameObject.SetActive(true);
        }

        public virtual void Deactivate()
        {
            gameObject.SetActive(false);
        }

    }
}
