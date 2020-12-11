namespace Base.Game.States
{
    using Base.Game.Command;

    public class MoveableObjectWithMultipierContext : Context
    {
        public MovementActionWithMultipier MoveFuntions { get; private set; }
        public ICommand Move { get; set; }

        public MoveableObjectWithMultipierContext(IMoveableObjectWithMultipier obj)
        {
            MoveFuntions = new MovementActionWithMultipier(obj);
        }

        public void Execute()
        {
            Move?.Execute();
        }
    }
}
