namespace Base.Util
{
    using System.Collections.Generic;
    using UnityEngine;

    public class Factory : IFactory
    {
        public static IFactory Instance { get => Constraction.Build(); }
        public static Builder Constraction { get; private set; } = new Builder();
        private List<MyObject> _pool;
        private List<MyObject> _prefabs;
        private int _totalObject;
        private Factory()
        {
            _pool = new List<MyObject>();
            _prefabs = new List<MyObject>();
        }

        public T GetObject<T>() where T : MyObject
        {
            T found = (T)_pool.Find(x => x is T);
            if (_pool.Count > 0 && found)
            {
                _pool.Remove(found);
                return found;
            }
            else
            {
                found = (T)_prefabs.Find(x => x is T);
                if (found)
                {
                    return MonoBehaviour.Instantiate(found);
                }
            }
            Debug.LogWarning("Prefab not found please check it in resources file!!");
            return null;
        }

        public T GetObject<T>(UnityEngine.Transform parent) where T : MyObject
        {
            T found = (T)_pool.Find(x => x is T);
            if (_pool.Count > 0 && found)
            {
                _pool.Remove(found);
                return found;
            }
            else
            {
                found = (T)_prefabs.Find(x => x is T);
                if (found)
                {
                    return MonoBehaviour.Instantiate(found, parent);
                }
            }
            Debug.LogWarning("Prefab not found please check it in resources file!!");
            return null;
        }

        public T GetObject<T>(int variantID) where T : MyObject
        {
            List<MyObject> foundAll = _pool.FindAll(x => x is T && x.VariantID.Equals(variantID));
            T found = null;
            if (_pool.Count > 0 && foundAll.Count > 0)
            {
                found = (T)foundAll[Random.Range(0, foundAll.Count)];
                _pool.Remove(found);
                return found;
            }
            else
            {
                foundAll = _prefabs.FindAll(x => x is T && x.VariantID.Equals(variantID));
                if (foundAll.Count > 0)
                {
                    found = (T)foundAll[Random.Range(0, foundAll.Count)];
                    return MonoBehaviour.Instantiate(found);
                }
            }
            Debug.LogWarning("Prefab not found please check it in resources file!!" + " Object Type : " + variantID);
            return null;
        }

        public T GetObject<T>(int variantID, UnityEngine.Transform parent) where T : MyObject
        {
            List<MyObject> foundAll = _pool.FindAll(x => x is T && x.VariantID.Equals(variantID));
            T found = null;
            if (_pool.Count > 0 && foundAll.Count > 0)
            {
                found = (T)foundAll[Random.Range(0, foundAll.Count)];
                _pool.Remove(found);
                return found;
            }
            else
            {
                foundAll = _prefabs.FindAll(x => x is T && x.VariantID.Equals(variantID));
                if (foundAll.Count > 0)
                {
                    found = (T)foundAll[Random.Range(0, foundAll.Count)];
                    return MonoBehaviour.Instantiate(found, parent);
                }
            }
            Debug.LogWarning("Prefab not found please check it in resources file!!" + " Object Type : " + variantID);
            return null;
        }

        public class Builder
        {
            private Factory _factory;

            public Builder()
            {
                _factory = new Factory();
                AddAllPrefabOnPath("");
            }

            public Builder AddPrefab(MyObject prefab)
            {
                if (!_factory._prefabs.Contains(prefab))
                {
                    _factory._prefabs.Add(prefab);
                }
                return this;
            }

            public Builder AddPrefabOnPath(string prefabPath)
            {
                MyObject prefab = Resources.Load<MyObject>(prefabPath);
                if (!prefab)
                {
                    Debug.LogWarning(prefabPath + " prefab not found please check it!!");
                    return this;
                }
                if (!_factory._prefabs.Contains(prefab))
                {
                    _factory._prefabs.Add(prefab);
                }
                return this;
            }

            public Builder AddPrefabOnPathInitInstantiate(string prefabPath)
            {
                MyObject prefab = Resources.Load<MyObject>(prefabPath);
                if (!prefab)
                {
                    Debug.LogWarning(prefabPath + " prefab not found please check it!!");
                    return this;
                }
                if (!_factory._prefabs.Contains(prefab))
                {
                    MonoBehaviour.Instantiate(prefab);
                    _factory._prefabs.Add(prefab);
                }
                return this;
            }

            public Builder AddAllPrefabOnPathInitInstantiate(string basePath)
            {
                MyObject[] objs = Resources.LoadAll<MyObject>(basePath);
                foreach (MyObject obj in objs)
                {
                    if (!_factory._prefabs.Contains(obj))
                    {
                        MonoBehaviour.Instantiate(obj);
                        _factory._prefabs.Add(obj);
                    }
                    else
                        Debug.LogWarning("Prefab dublicated check it!! Type : " + obj.GetType() + " Path : " + basePath);
                }
                return this;
            }

            public Builder AddAllPrefabOnPath(string basePath)
            {
                MyObject[] objs = Resources.LoadAll<MyObject>(basePath);
                foreach(MyObject obj in objs)
                {
                    if (!_factory._prefabs.Contains(obj))
                        _factory._prefabs.Add(obj);
                    else
                        Debug.LogWarning("Prefab dublicated check it!! Type : " + obj.GetType() + " Path : " + basePath);
                }
                return this;
            }

            public IFactory Build()
            {
                return _factory;
            }

        }

    }
}