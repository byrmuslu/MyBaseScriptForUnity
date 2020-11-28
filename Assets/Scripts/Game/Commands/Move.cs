namespace Base.Game.Commands
{
    
    public class Move
    {
        private IMoveable _obj;

        public Move(IMoveable obj)
        {
            _obj = obj;
        }

        public void MoveActionXY()
        {
            _obj.GetTransform().Translate(_obj.GetSpeed() * _obj.GetMultipierHorizontal(), _obj.GetSpeed() * _obj.GetMultipierVertical(), 0);
        }

        public void MoveActionXZ()
        {
            _obj.GetTransform().Translate(_obj.GetSpeed() * _obj.GetMultipierHorizontal(), 0, _obj.GetSpeed() * _obj.GetMultipierVertical());
        }

        public void MoveActionYZ()
        {
            _obj.GetTransform().Translate(0, _obj.GetSpeed() * _obj.GetMultipierHorizontal(), _obj.GetSpeed() * _obj.GetMultipierVertical());
        }

        public void MoveActionX()
        {
            _obj.GetTransform().Translate(_obj.GetSpeed() * _obj.GetMultipierHorizontal(), 0, 0);
        }

        public void MoveActionXNonMultipier()
        {
            _obj.GetTransform().Translate(_obj.GetSpeed(), 0, 0);
        }

        public void MoveActionXPlus()
        {
            if(_obj.GetMultipierHorizontal() > 0)
            {
                _obj.GetTransform().Translate(_obj.GetSpeed() * _obj.GetMultipierHorizontal(), 0, 0);
            }
        }

        public void MoveActionXMinus()
        {
            if (_obj.GetMultipierHorizontal() < 0)
            {
                _obj.GetTransform().Translate(_obj.GetSpeed() * _obj.GetMultipierHorizontal(), 0, 0);
            }
        }

        public void MoveActionY()
        {
            _obj.GetTransform().Translate(0, _obj.GetSpeed() * _obj.GetMultipierVertical(), 0);
        }

        public void MoveActionYNonMultipier()
        {
            _obj.GetTransform().Translate(0, _obj.GetSpeed(), 0);
        }

        public void MoveActionYPlus()
        {
            if(_obj.GetMultipierVertical() > 0)
            {
                _obj.GetTransform().Translate(0, _obj.GetSpeed() * _obj.GetMultipierVertical(), 0);
            }
        }

        public void MoveActionYMinus()
        {
            if (_obj.GetMultipierVertical() < 0)
            {
                _obj.GetTransform().Translate(0, _obj.GetSpeed() * _obj.GetMultipierVertical(), 0);
            }
        }

        public void MoveActionZ()
        {
            _obj.GetTransform().Translate(0, 0, _obj.GetSpeed() * _obj.GetMultipierVertical());
        }

        public void MoveActionZNonMultipier()
        {
            _obj.GetTransform().Translate(0, 0, _obj.GetSpeed());
        }

        public void MoveActionZPlus()
        {
            if (_obj.GetMultipierVertical() > 0)
            {
                _obj.GetTransform().Translate(0, 0, _obj.GetSpeed() * _obj.GetMultipierVertical());
            }
        }

        public void MoveActionZMinus()
        {
            if (_obj.GetMultipierVertical() < 0)
            {
                _obj.GetTransform().Translate(0, 0, _obj.GetSpeed() * _obj.GetMultipierVertical());
            }
        }

    }
}
