namespace Base.Game.GameObject
{
    using Base.Game.Signal;
    using UnityEngine;
    public class MyObject : MonoBehaviour
    {
        public Transform Transform => transform;

        private void Awake()
        {
            Initialize();
        }

        private void Start()
        {
        }
        protected virtual void OnDestroy()
        {
        }

        protected virtual void Initialize()
        {
        }

        public virtual void Activate()
        {
            gameObject?.SetActive(true);
        }
        public virtual void DeActivate()
        {
            gameObject?.SetActive(false);
        }

    }
}
