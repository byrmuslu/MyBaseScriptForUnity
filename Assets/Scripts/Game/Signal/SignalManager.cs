using System;
using System.Collections.Generic;
using System.Reflection;

namespace Base.Game.Signal
{
    public class SignalManager
    {
        private static Dictionary<string, Signal> _signal = new Dictionary<string, Signal>();
        public static void Register<T>(T type, string tag)
        {
            Dictionary<string, List<MethodInfo>> methodGroup = new Dictionary<string, List<MethodInfo>>();
            MethodInfo[] customs = type.GetType().GetMethods();
            foreach (MethodInfo s in customs)
            {
                SignalAttribute att = (SignalAttribute)s.GetCustomAttribute(typeof(SignalAttribute));
                if (att == null || att.Tag != tag)
                    continue;
                if (!methodGroup.ContainsKey(att.Tag))
                {
                    methodGroup.Add(att.Tag, new List<MethodInfo>());
                }
                methodGroup[att.Tag].Add(s);
            }
            if (methodGroup.Count <= 0)
                return;
            _signal.Add(tag, new Signal(tag, type));
            foreach (string t in methodGroup.Keys)
            {
                _signal[tag].AddMethods(t, methodGroup[tag]);
            }
        }

        public static void UnRegister<T>(T type, string tag)
        {
            _signal.Remove(tag);
        }

        public static void Fire(string tag, params object[] prms)
        {
            if (!_signal.ContainsKey(tag))
                return;
            Signal signal = _signal[tag];
            signal.FireSignalMethodGroup(tag, prms);
        }

    }
}
