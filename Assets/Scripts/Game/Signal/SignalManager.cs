using Base.Game.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Base.Game.Signal
{
    public class SignalManager
    {
        private static Dictionary<Type, List<Signal>> _signal = new Dictionary<Type, List<Signal>>();
        public static void Register<T>(T clz)
        {
            Dictionary<Type, List<MethodInfo>> methodGroup = new Dictionary<Type, List<MethodInfo>>();
            MethodInfo[] customs = clz.GetType().GetMethods();
            foreach (MethodInfo s in customs)
            {
                SignalAttribute att = (SignalAttribute)s.GetCustomAttribute(typeof(SignalAttribute));
                if (att == null)
                    continue;
                if (!methodGroup.ContainsKey(att.Tag))
                {
                    methodGroup.Add(att.Tag, new List<MethodInfo>());
                }
                methodGroup[att.Tag].Add(s);
            }
            if (methodGroup.Count <= 0)
                return;
            foreach (Type tag in methodGroup.Keys)
            {
                if (_signal.ContainsKey(tag))
                {
                    Signal newSignal = new Signal(tag, clz);
                    newSignal.AddMethods(tag, methodGroup[tag]);
                    _signal[tag].Add(newSignal);
                }
                else
                {
                    Signal newSignal = new Signal(tag, clz);
                    newSignal.AddMethods(tag, methodGroup[tag]);
                    _signal.Add(tag, new List<Signal>() { newSignal });
                }
            }
        }

        public static void UnRegister<T>(T clz, Type tag)
        {
            if (_signal.ContainsKey(tag))
            {
                _signal[tag].ToList().FindAll(s => s.Object == (object)clz).ForEach(s => _signal[tag].Remove(s));
            }
        }

        public static void UnRegister<T>(T clz)
        {
            foreach (Type tag in _signal.Keys)
            {
                _signal[tag].ToList().FindAll(s => s.Object == (object)clz).ForEach(s => _signal[tag].Remove(s));
            }
        }

        public static void Fire(Type tag, params object[] prms)
        {
            if (!_signal.ContainsKey(tag))
                return;
            _signal[tag].ToList().ForEach(s => s.FireSignalMethodGroup(tag, prms));
        }

    }
}
