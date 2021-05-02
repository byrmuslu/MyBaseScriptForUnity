namespace Base.Game.Command
{
    using System;

    public class Command<T> : ICommand
    {
        private T _target;
        private Action<T> _action;

        public Command(T target, Action<T> action)
        {
            _target = target;
            _action = action;
        }

        public void Execute()
        {
            _action(_target);
        }
    }
}