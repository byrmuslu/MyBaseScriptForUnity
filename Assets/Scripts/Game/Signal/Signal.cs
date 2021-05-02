using System;
using System.Collections.Generic;
using System.Reflection;

namespace Base.Game.Signal
{
    public class Signal
    {
        private Type _tag;
        public Type Tag { get => _tag; }
        private object _o;
        public object Object { get => _o; }
        private Dictionary<Type, List<MethodInfo>> _methodGroup;
        public Dictionary<Type, List<MethodInfo>> MethodGroup { get => _methodGroup; }

        public Signal(Type tag, object o)
        {
            _tag = tag;
            _o = o;
            _methodGroup = new Dictionary<Type, List<MethodInfo>>();
        }

        public void AddMethods(Type tag, List<MethodInfo> methods)
        {
            if (!_methodGroup.ContainsKey(tag))
            {
                _methodGroup.Add(tag, new List<MethodInfo>());
            }
            _methodGroup[tag].AddRange(methods);
        }

        public void FireSignalMethodGroup(Type tag, params object[] prms)
        {
            if (_methodGroup.ContainsKey(tag))
            {
                foreach (MethodInfo action in _methodGroup[tag])
                {
                    if (action.GetParameters().Length != prms.Length)
                        continue;
                    bool isOk = true;
                    for (int i = 0; i < action.GetParameters().Length; i++)
                    {
                        Type type = prms[i].GetType();
                        if (!type.IsPrimitive)
                        {
                            while (type.BaseType != typeof(Base.Game.GameObject.MyObject))
                            {
                                type = type.BaseType;
                            }

                        }
                        if (!action.GetParameters()[i].ParameterType.Equals(type))
                            isOk = false;
                    }
                    if (isOk)
                        action.Invoke(_o, prms);
                }
            }
        }
    }
}
