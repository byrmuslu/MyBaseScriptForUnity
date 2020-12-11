using Base.Game.Command;

namespace Base.Game.States
{
    public class MoveableObjectToTargetContext : Context
    {
        public MovementActionToTarget MovementActions { get; set; }
        public ICommand Movement { get; set; }

        public MoveableObjectToTargetContext(IMoveableObjectToTarget obj)
        {
            MovementActions = new MovementActionToTarget(obj);
        }

    }
}
