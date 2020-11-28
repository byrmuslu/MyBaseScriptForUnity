namespace Base.Utils
{
    using Base.Game.Signals;
    using System.Collections.Generic;
    using UnityEngine;

    public class Factory<T, T1> : IFactory<T> where T : MonoBehaviour
    {
        private Queue<T> _pool;
        private T _prefab;
        
        public Factory(string prefabPath)
        {
            _prefab = Resources.Load<GameObject>(prefabPath).GetComponent<T>();
            _pool = new Queue<T>();
            SignalBus<T1, T>.Instance.Register(OnDestroyed);
        }

        private void OnDestroyed(T obj)
        {
            if (_pool.Contains(obj))
                return;
            _pool.Enqueue(obj);
        }

        public T GetObject()
        {
            if(_pool.Count > 0)
            {
                return _pool.Dequeue();
            }
            return MonoBehaviour.Instantiate(_prefab.gameObject).GetComponent<T>();
        }
    }
}
