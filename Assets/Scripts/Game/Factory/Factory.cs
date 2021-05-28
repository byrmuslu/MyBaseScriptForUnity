namespace Base.Util
{
    using Base.Game.GameObject;
    using Base.Game.Signal;
    using System.Collections.Generic;
    using UnityEngine;

    public class Factory : IFactory
    {
        public static IFactory Instance { get => Constraction.Build(); }
        public static Builder Constraction { get; private set; } = new Builder();
        private List<PoolableObject> _pool;
        private List<PoolableObject> _prefabs;
        private int _totalObject;
        private Factory()
        {
            _pool = new List<PoolableObject>();
            _prefabs = new List<PoolableObject>();
        }
        ~Factory()
        {
            SignalManager.UnRegister(this);
        }
        private void Register()
        {
            SignalManager.Register(this);
        }

        [Signal(typeof(PoolableObject), typeof(PoolableObject))]
        public void OnDestroyed(PoolableObject obj)
        {
            if (_pool.Contains(obj))
                return;
            _pool.Add(obj);
        }

        public PoolableObject GetObject()
        {
            if (_pool.Count > 0)
            {
                PoolableObject inPoolObj = _pool[UnityEngine.Random.Range(0, _pool.Count)];
                _pool.Remove(inPoolObj);
                return inPoolObj;
            }
            _totalObject += 1;
            return MonoBehaviour.Instantiate(_prefabs[UnityEngine.Random.Range(0, _prefabs.Count)].gameObject).GetComponent<PoolableObject>();
        }

        public PoolableObject GetObject(System.Type type)
        {
            PoolableObject found = _pool.Find(x => x.GetType().Equals(type));
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
                    return MonoBehaviour.Instantiate(found.gameObject).GetComponent<PoolableObject>();
                }
            }
            Debug.LogWarning("Prefab not found please check it in resources file!! Type : " + type);
            return null;
        }

        public PoolableObject GetObject(System.Type type, ObjectType objType)
        {
            List<PoolableObject> foundAll = _pool.FindAll(x => x.GetType().Equals(type) && x.Type.Equals(objType));
            PoolableObject found = null;
            if (_pool.Count > 0 && foundAll.Count > 0)
            {
                found = foundAll[Random.Range(0, foundAll.Count)];
                _pool.Remove(found);
                return found;
            }
            else
            {
                foundAll = _prefabs.FindAll(x => x.GetType().Equals(type) && x.Type.Equals(objType));
                if (foundAll.Count > 0)
                {
                    found = foundAll[Random.Range(0, foundAll.Count)];
                    return MonoBehaviour.Instantiate(found.gameObject).GetComponent<PoolableObject>();
                }
            }
            Debug.LogWarning("Prefab not found please check it in resources file!! Type : " + type + " Object Type : " + objType);
            return null;
        }

        public int GetTotalObjectCount()
        {
            return _totalObject;
        }

        public class Builder
        {
            private Factory _factory;

            public Builder()
            {
                _factory = new Factory();
            }

            public Builder AddPrefab(PoolableObject prefab)
            {
                if (!_factory._prefabs.Contains(prefab))
                {
                    _factory._prefabs.Add(prefab);
                }
                return this;
            }

            public Builder AddPrefab(string prefabPath)
            {
                PoolableObject prefab = Resources.Load<GameObject>(prefabPath).GetComponent<PoolableObject>();
                if (!prefab)
                {
                    Debug.LogWarning(prefabPath + " prefab not found please check it!!");
                    return this;
                }
                if (!_factory._prefabs.Contains(prefab))
                {
                    PoolableObject initialObject = MonoBehaviour.Instantiate(prefab).GetComponent<PoolableObject>();
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
                    PoolableObject prefab = obj.GetComponent<PoolableObject>();
                    if (prefab)
                    {
                        if (!_factory._prefabs.Contains(prefab))
                        {
                            PoolableObject initialObject = MonoBehaviour.Instantiate(prefab).GetComponent<PoolableObject>();
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
                    PoolableObject prefab = obj.GetComponent<PoolableObject>();
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

            public Builder Register()
            {
                _factory.Register();
                return this;
            }

            public IFactory Build()
            {
                return _factory;
            }

        }

    }
}