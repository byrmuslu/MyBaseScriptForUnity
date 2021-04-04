namespace Base.Game.Signal
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    public class Signal
    {
        private string _tag;
        public string Tag { get => _tag; }
        private object _o;
        private Dictionary<string, List<MethodInfo>> _methodGroup;

        public Signal(string tag, object o)
        {
            _tag = tag;
            _o = o;
            _methodGroup = new Dictionary<string, List<MethodInfo>>();
        }

        public void AddMethods(string tag, List<MethodInfo> methods)
        {
            if (!_methodGroup.ContainsKey(tag))
            {
                _methodGroup.Add(tag, new List<MethodInfo>());
            }
            _methodGroup[tag].AddRange(methods);
        }

        public void FireSignalMethodGroup(string tag, params object[] prms)
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
                        if (!action.GetParameters()[i].ParameterType.Equals(prms[i].GetType()))
                            isOk = false;
                    }
                    if (isOk)
                        action.Invoke(_o, prms);
                }
            }
        }



    }
}
