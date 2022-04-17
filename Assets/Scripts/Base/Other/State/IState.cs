namespace Base.Other.State
{
    using System.Collections;
    public interface IState<T>
    {
        void Handle(BaseContext<T> context);
        IEnumerator GetAction();
    }
}