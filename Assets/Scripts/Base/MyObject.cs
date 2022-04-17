namespace Base
{
    using System;
    using UnityEngine;

    public class MyObject : MonoBehaviour
    {
        public virtual int VariantID { get; set; } = 0;

        public event Action Destroyed;
        public event Action Activated;
        public event Action DeActivated;

        protected virtual void Awake()
        {
            Initialize();
            Registration();
        }

        protected virtual void OnEnable()
        {
            Activated?.Invoke();
        }

        protected virtual void OnDisable()
        {
            DeActivated?.Invoke();
        }

        protected virtual void OnDestroy()
        {
            Destroyed?.Invoke();
            UnRegistration();
        }

        protected virtual void OnApplicationQuit()
        {
            UnRegistration();
        }

        protected virtual void Initialize()
        {
        }

        protected virtual void Registration()
        {
            Application.quitting += UnRegistration;
        }

        protected virtual void UnRegistration()
        {
            Application.quitting -= UnRegistration;
        }

        public virtual void Activate()
        {
            gameObject.SetActive(true);
        }

        public virtual void DeActivate()
        {
            gameObject.SetActive(false);
        }

    }
}