namespace Base.Game.Signal
{
    using System;
    using System.Collections.Generic;

    public sealed class SignalBus<T>
    {
        public static SignalBus<T> Instance { get; private set; } = new SignalBus<T>();
        private List<Action> _actions;

        private SignalBus() => _actions = new List<Action>();

        public void Register(Action action) 
        {
            if (_actions.Contains(action))
                return;
            _actions.Add(action);
        }

        public void UnRegister(Action action) 
        {
            _actions.Remove(action);
        }

        public void Fire()
        {
            for (int i = 0; i < _actions.Count; i++)
                _actions[i]();
        }
    }

    public sealed class SignalBus<T,T1>
    {
        public static SignalBus<T,T1> Instance { get; private set; } = new SignalBus<T,T1>();
        private List<Action<T1>> _actions;

        private SignalBus() => _actions = new List<Action<T1>>();

        public void Register(Action<T1> action)
        {
            if (_actions.Contains(action))
                return;
            _actions.Add(action);
        }

        public void UnRegister(Action<T1> action)
        {
            _actions.Remove(action);
        }

        public void Fire(T1 obj)
        {
            for (int i = 0; i < _actions.Count; i++)
                _actions[i](obj);
        }
    }

    public class SignalBus<T, T1,T2>
    {
        public static SignalBus<T, T1,T2> Instance { get; private set; } = new SignalBus<T, T1,T2>();
        private List<Action<T1,T2>> _actions;

        private SignalBus() => _actions = new List<Action<T1,T2>>();

        public void Register(Action<T1,T2> action)
        {
            if (_actions.Contains(action))
                return;
            _actions.Add(action);
        }

        public void UnRegister(Action<T1,T2> action)
        {
            _actions.Remove(action);
        }

        public void Fire(T1 obj, T2 obj2)
        {
            for (int i = 0; i < _actions.Count; i++)
                _actions[i](obj, obj2);
        }
    }

}
