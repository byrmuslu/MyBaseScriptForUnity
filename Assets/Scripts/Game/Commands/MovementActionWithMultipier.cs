using UnityEngine;

namespace Base.Game.Command
{
    public class MovementActionWithMultipier
    {
        private IMoveableObjectWithMultipier _obj;

        public MovementActionWithMultipier(IMoveableObjectWithMultipier obj)
        {
            _obj = obj;
        }

        public void MoveActionXY()
        {
            _obj.GetTransform().Translate(_obj.GetSpeed() * _obj.GetMultipierHorizontalValue(), _obj.GetSpeed() * _obj.GetMultipierVerticalValue(), 0);
        }

        public void MoveActionXZ()
        {
            _obj.GetTransform().Translate(_obj.GetSpeed() * _obj.GetMultipierHorizontalValue(), 0, _obj.GetSpeed() * _obj.GetMultipierVerticalValue());
        }

        public void MoveActionYZ()
        {
            _obj.GetTransform().Translate(0, _obj.GetSpeed() * _obj.GetMultipierVerticalValue(), _obj.GetSpeed() * _obj.GetMultipierHorizontalValue());
        }

        public void MoveActionX()
        {
            _obj.GetTransform().Translate(_obj.GetSpeed() * _obj.GetMultipierHorizontalValue(), 0, 0);
        }

        public void MoveActionXPlusNonMultipier()
        {
            _obj.GetTransform().Translate(_obj.GetSpeed(), 0, 0);
        }

        public void MoveActionXMinusNonMultipier()
        {
            _obj.GetTransform().Translate(_obj.GetSpeed() * -1, 0, 0);
        }

        public void MoveActionXPlus()
        {
            if(_obj.GetMultipierHorizontalValue() > 0)
            {
                _obj.GetTransform().Translate(_obj.GetSpeed() * _obj.GetMultipierHorizontalValue(), 0, 0);
            }
        }

        public void MoveActionXMinus()
        {
            if (_obj.GetMultipierHorizontalValue() < 0)
            {
                _obj.GetTransform().Translate(_obj.GetSpeed() * _obj.GetMultipierHorizontalValue() * -1, 0, 0);
            }
        }

        public void MoveActionY()
        {
            _obj.GetTransform().Translate(0, _obj.GetSpeed() * _obj.GetMultipierVerticalValue(), 0);
        }

        public void MoveActionYPlusNonMultipier()
        {
            _obj.GetTransform().Translate(0, _obj.GetSpeed(), 0);
        }

        public void MoveActionYMinusNonMultipier()
        {
            _obj.GetTransform().Translate(0, _obj.GetSpeed() * -1, 0);
        }

        public void MoveActionYPlus()
        {
            if(_obj.GetMultipierVerticalValue() > 0)
            {
                _obj.GetTransform().Translate(0, _obj.GetSpeed() * _obj.GetMultipierVerticalValue(), 0);
            }
        }

        public void MoveActionYMinus()
        {
            if (_obj.GetMultipierVerticalValue() < 0)
            {
                _obj.GetTransform().Translate(0, _obj.GetSpeed() * _obj.GetMultipierVerticalValue(), 0);
            }
        }

        public void MoveActionZ()
        {
            _obj.GetTransform().Translate(0, 0, _obj.GetSpeed() * _obj.GetMultipierVerticalValue());
        }

        public void MoveActionZPlusNonMultipier()
        {
            _obj.GetTransform().Translate(0, 0, _obj.GetSpeed());
        }

        public void MoveActionZMinusNonMultipier()
        {
            _obj.GetTransform().Translate(0, 0, _obj.GetSpeed() * -1);
        }

        public void MoveActionZPlus()
        {
            if (_obj.GetMultipierVerticalValue() > 0)
            {
                _obj.GetTransform().Translate(0, 0, _obj.GetSpeed() * _obj.GetMultipierVerticalValue());
            }
        }

        public void MoveActionZMinus()
        {
            if (_obj.GetMultipierVerticalValue() < 0)
            {
                _obj.GetTransform().Translate(0, 0, _obj.GetSpeed() * _obj.GetMultipierVerticalValue());
            }
        }

        public void MoveToTarget(Vector3 target)
        {
            _obj.GetTransform().position = Vector3.MoveTowards(_obj.GetTransform().position, target, _obj.GetSpeed());
        }

    }
}
