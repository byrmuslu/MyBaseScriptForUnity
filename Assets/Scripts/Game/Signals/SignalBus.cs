namespace Base.Game.Signals
{
    using System;
    using System.Collections.Generic;
    public class SignalBus<T>
    {
        public static SignalBus<T> Instance { get; private set; } = new SignalBus<T>();

        private List<Action> _observers;

        private SignalBus()
        {
            _observers = new List<Action>();
        }

        public void Register(Action action)
        {
            if (_observers.Contains(action))
                return;
            _observers.Add(action);
        }

        public void UnRegister(Action action)
        {
            _observers.Remove(action);
        }

        public void Fire()
        {
            for(int i = 0; i < _observers.Count; i++)
            {
                _observers[i]();
            }
        }
    }

    public class SignalBus<T, T1>
    {
        public static SignalBus<T, T1> Instance { get; private set; } = new SignalBus<T, T1>();

        private List<Action<T1>> _observers;

        private SignalBus()
        {
            _observers = new List<Action<T1>>();
        }

        public void Register(Action<T1> action)
        {
            if (_observers.Contains(action))
                return;
            _observers.Add(action);
        }

        public void UnRegister(Action<T1> action)
        {
            _observers.Remove(action);
        }

        public void Fire(T1 obj)
        {
            for(int i = 0; i < _observers.Count; i++)
            {
                _observers[i](obj);
            }
        }
    }

    public class SignalBus<T, T1, T2>
    {
        public static SignalBus<T, T1, T2> Instance { get; private set; } = new SignalBus<T, T1, T2>();

        private List<Action<T1, T2>> _observers;

        private SignalBus()
        {
            _observers = new List<Action<T1, T2>>();
        }

        public void Register(Action<T1,T2> action)
        {
            if (_observers.Contains(action))
                return;
            _observers.Add(action);
        }

        public void UnRegister(Action<T1,T2> action)
        {
            _observers.Remove(action);
        }

        public void Fire(T1 obj, T2 obj2)
        {
            for(int i = 0; i < _observers.Count; i++)
            {
                _observers[i](obj, obj2);
            }
        }
    }

    public class SignalBus<T, T1, T2, T3>
    {
        public static SignalBus<T, T1, T2, T3> Instance { get; private set; } = new SignalBus<T, T1, T2, T3>();

        private List<Action<T1, T2, T3>> _observers;

        private SignalBus()
        {
            _observers = new List<Action<T1, T2, T3>>();
        }

        public void Register(Action<T1,T2,T3> action)
        {
            if (_observers.Contains(action))
                return;
            _observers.Add(action);
        }

        public void UnRegister(Action<T1,T2,T3> action)
        {
            _observers.Remove(action);
        }

        public void Fire(T1 obj, T2 obj2, T3 obj3)
        {
            for(int i = 0; i < _observers.Count; i++)
            {
                _observers[i](obj, obj2, obj3);
            }
        }
    }
}
