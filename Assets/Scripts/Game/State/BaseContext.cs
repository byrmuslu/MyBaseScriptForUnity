using Base.Game.GameObject;

namespace Base.Game.State
{
    public class BaseContext<T>
    {
        public T MyObject { get; set; }
        public virtual IState<T> State { get; set; }

        public void Request() => State?.Handle(this);
    }
}