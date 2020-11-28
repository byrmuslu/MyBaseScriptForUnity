namespace Base.Game.States
{
    public class Context
    {
        public IState State { get; set; }

        public Context(IState state)
        {
            State = state;
        }

        public void Request()
        {
            State.Handle(this);
        }

    }
}
