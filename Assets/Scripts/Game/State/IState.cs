using System.Collections;

namespace Base.Game.State
{
    public interface IState<T>
    {
        void Handle(BaseContext<T> context);
        IEnumerator GetAction();
    }
}
