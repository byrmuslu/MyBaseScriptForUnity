namespace Base.Game.Command
{
    using UnityEngine;

    public class RotationAction
    {
        private IRotateableObject _obj;

        public RotationAction(IRotateableObject obj)
        {
            _obj = obj;
        }

        public void RotationActionX()
        {
            _obj.GetTransform().Rotate(Vector3.right, _obj.GetMultipierValue() * _obj.GetRotateSpeed());
        }

        public void RotationActionXPlusNonMultipier()
        {
            _obj.GetTransform().Rotate(Vector3.right, _obj.GetRotateSpeed());
        }

        public void RotationActionXMinusNonMultipier()
        {
            _obj.GetTransform().Rotate(Vector3.right, _obj.GetRotateSpeed() * -1);
        }

        public void RotationActionY()
        {
            _obj.GetTransform().Rotate(Vector3.up, _obj.GetMultipierValue() * _obj.GetRotateSpeed());
        }

        public void RotationActionYPlusNonMultipier()
        {
            _obj.GetTransform().Rotate(Vector3.up, _obj.GetRotateSpeed());
        }

        public void RotationActionYMinusNonMultipier()
        {
            _obj.GetTransform().Rotate(Vector3.up, _obj.GetRotateSpeed() * -1);
        }

        public void RotationActionZ()
        {
            _obj.GetTransform().Rotate(Vector3.forward, _obj.GetMultipierValue() * _obj.GetRotateSpeed());
        }

        public void RotationActionZPlusNonMultipier()
        {
            _obj.GetTransform().Rotate(Vector3.forward, _obj.GetRotateSpeed());
        }

        public void RotationActionZMinusNonMultipier()
        {
            _obj.GetTransform().Rotate(Vector3.forward, _obj.GetRotateSpeed() * -1);
        }

        public void RotationActionRotateToTarget(Quaternion target)
        {
            _obj.GetTransform().rotation = Quaternion.RotateTowards(_obj.GetTransform().rotation, target, _obj.GetRotateSpeed());
        }

        public void RotationActionRotateToTarget(Vector3 target)
        {
            _obj.GetTransform().rotation = Quaternion.RotateTowards(_obj.GetTransform().rotation, Quaternion.Euler(target), _obj.GetRotateSpeed());
        }

    }
}
