namespace Base.Game.Command
{
    using UnityEngine;
    public class MovementAction
    {
        private IMoveable _obj;
        public MovementAction(IMoveable obj) => _obj = obj;

        public void RMoveForward()
        {
            Vector3 direcVel = _obj.Transform.forward * _obj.MovementSpeed;
            direcVel.y = _obj.RigidBody.velocity.y;
            _obj.RigidBody.velocity = direcVel;
        }

        public void MoveForward()
        {
            _obj.Transform.Translate(0, 0, _obj.MovementSpeed);
        }

        public void RMoveBackward()
        {
            Vector3 direcVel = _obj.Transform.forward * _obj.MovementSpeed * -1;
            direcVel.y = _obj.RigidBody.velocity.y;
            _obj.RigidBody.velocity = direcVel;
        }

        public void MoveBackward()
        {
            _obj.Transform.Translate(0, 0, _obj.MovementSpeed * -1);
        }

        public void RotateRight()
        {
            _obj.Transform.Rotate(Vector3.up, _obj.RotationSpeed);
        }

        public void RotateLeft()
        {
            _obj.Transform.Rotate(Vector3.up, _obj.RotationSpeed);
        }

        public void RotateUp()
        {
            _obj.Transform.Rotate(Vector3.right, _obj.RotationSpeed);
        }

        public void RotateDown()
        {
            _obj.Transform.Rotate(Vector3.right, _obj.RotationSpeed * -1);
        }

        public void RMoveToTarget(Vector3 target)
        {
            _obj.Transform.rotation = Quaternion.RotateTowards(_obj.Transform.rotation, Quaternion.Euler(((_obj.Transform.position - target) * -1).normalized), _obj.RotationSpeed);
            RMoveForward();
        }

        public void MoveToTarget(Vector3 target)
        {
            _obj.Transform.rotation = Quaternion.RotateTowards(_obj.Transform.rotation, Quaternion.Euler(((_obj.Transform.position - target) * -1).normalized), _obj.RotationSpeed);
            _obj.Transform.position = Vector3.MoveTowards(_obj.Transform.position, target, _obj.MovementSpeed);
        }

    }
}
