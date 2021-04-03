namespace Base.Game.Factory
{
    using Base.Game.Signal;
    using System.Collections.Generic;
    using UnityEngine;

    public class Factory<T, T1> : IFactory<T> where T : MonoBehaviour
    {
        private List<T> _pool;
        private List<T> _prefabs;
        private int _totalObject;
        private Factory()
        {
            _pool = new List<T>();
            _prefabs = new List<T>();
        }
        ~Factory()
        {
            SignalBus<T1, T>.Instance.UnRegister(OnDestroyed);
        }
        private void SetHandle()
        {
            SignalBus<T1, T>.Instance.Register(OnDestroyed);
        }

        private void OnDestroyed(T obj)
        {
            if (_pool.Contains(obj))
                return;
            _pool.Add(obj);
        }

        public T GetObject()
        {
            if (_pool.Count > 0)
            {
                T inPoolObj = _pool[UnityEngine.Random.Range(0, _pool.Count)];
                _pool.Remove(inPoolObj);
                return inPoolObj;
            }
            _totalObject += 1;
            return MonoBehaviour.Instantiate(_prefabs[UnityEngine.Random.Range(0, _prefabs.Count)].gameObject).GetComponent<T>();
        }

        public T GetObject(System.Type type)
        {
            T found = _pool.Find(x => x.GetType().Equals(type));
            if (_pool.Count > 0 && found)
            {
                _pool.Remove(found);
                return found;
            }
            else
            {
                found = _prefabs.Find(x => x.GetType().Equals(type));
                if (found)
                {
                    return MonoBehaviour.Instantiate(found.gameObject).GetComponent<T>();
                }
            }
            Debug.LogWarning("Prefab not found please check it in resources file!! Type : " + type);
            return null;
        }

        public int GetTotalObject()
        {
            return _totalObject;
        }

        public class Builder
        {
            private Factory<T, T1> _factory;

            public Builder()
            {
                _factory = new Factory<T, T1>();
            }

            public Builder AddPrefab(T prefab)
            {
                if (!_factory._prefabs.Contains(prefab))
                {
                    _factory._prefabs.Add(prefab);
                }
                return this;
            }

            public Builder AddPrefab(string prefabPath)
            {
                T prefab = Resources.Load<GameObject>(prefabPath).GetComponent<T>();
                if (!prefab)
                {
                    Debug.LogWarning(prefabPath + " prefab not found please check it!!");
                    return this;
                }
                if (!_factory._prefabs.Contains(prefab))
                {
                    T initialObject = MonoBehaviour.Instantiate(prefab).GetComponent<T>();
                    _factory._totalObject += 1;
                    _factory._pool.Add(initialObject);
                    initialObject.gameObject.SetActive(false);
                    _factory._prefabs.Add(prefab);
                }
                return this;
            }

            public Builder AddAllPrefabOnPathInitInstantiate(string basePath)
            {
                GameObject[] objs = Resources.LoadAll<GameObject>(basePath);
                foreach (GameObject obj in objs)
                {
                    T prefab = obj.GetComponent<T>();
                    if (prefab)
                    {
                        if (!_factory._prefabs.Contains(prefab))
                        {
                            T initialObject = MonoBehaviour.Instantiate(prefab).GetComponent<T>();
                            _factory._pool.Add(initialObject);
                            initialObject.gameObject.SetActive(false);
                            _factory._prefabs.Add(prefab);
                        }
                    }
                    else
                    {
                        Debug.LogWarning(basePath + " some prefab not found please check it!!");
                    }
                }
                return this;
            }

            public Builder AddAllPrefabOnPath(string basePath)
            {
                GameObject[] objs = Resources.LoadAll<GameObject>(basePath);
                foreach (GameObject obj in objs)
                {
                    T prefab = obj.GetComponent<T>();
                    if (prefab)
                    {
                        if (!_factory._prefabs.Contains(prefab))
                        {
                            _factory._prefabs.Add(prefab);
                        }
                    }
                    else
                    {
                        Debug.LogWarning(basePath + " some prefab not found please check it!!");
                    }
                }
                return this;
            }

            public Builder SetHandle()
            {
                _factory.SetHandle();
                return this;
            }

            public IFactory<T> Build()
            {
                return _factory;
            }

        }

    }
}