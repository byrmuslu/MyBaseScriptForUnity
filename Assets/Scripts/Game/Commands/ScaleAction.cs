namespace Base.Game.Command
{
    using UnityEngine;

    public class ScaleAction
    {
        private IScaleableObject _obj;

        public ScaleAction(IScaleableObject obj)
        {
            _obj = obj;
        }

        public void ScaleActionXYZ()
        {
            _obj.GetTransform().localScale += Vector3.one * _obj.GetScaleSpeed() * _obj.GetMultipierValue();
        }

        public void ScaleActionXY()
        {
            _obj.GetTransform().localScale += new Vector3(1, 1, 0) * _obj.GetScaleSpeed() * _obj.GetMultipierValue();
        }

        public void ScaleActionXZ()
        {
            _obj.GetTransform().localScale += new Vector3(1, 0, 1) * _obj.GetScaleSpeed() * _obj.GetMultipierValue();
        }

        public void ScaleActionYZ()
        {
            _obj.GetTransform().localScale += new Vector3(0, 1, 1) * _obj.GetScaleSpeed() * _obj.GetMultipierValue();
        }

        public void ScaleActionX()
        {
            _obj.GetTransform().localScale += Vector3.right * _obj.GetScaleSpeed() * _obj.GetMultipierValue();
        }

        public void ScaleActionY()
        {
            _obj.GetTransform().localScale += Vector3.up * _obj.GetScaleSpeed() * _obj.GetMultipierValue();
        }

        public void ScaleActionZ()
        {
            _obj.GetTransform().localScale += Vector3.forward * _obj.GetScaleSpeed() * _obj.GetMultipierValue();
        }

    }
}
