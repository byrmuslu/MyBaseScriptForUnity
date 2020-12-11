namespace Base.Game.States
{
    public class Context
    {
        public IState State { get; set; }
        
        public void Request()
        {
            State?.Handle(this);
        }

    }
}
