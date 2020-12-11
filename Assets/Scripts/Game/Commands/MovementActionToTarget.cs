namespace Base.Game.Command
{
    using UnityEngine;

    public class MovementActionToTarget
    {
        private IMoveableObjectToTarget _obj;

        public MovementActionToTarget(IMoveableObjectToTarget obj)
        {
            _obj = obj;
        }

        public void MoveToTargetXYZ(Vector3 target)
        {
            _obj.GetTransform().position = Vector3.MoveTowards(_obj.GetTransform().position, target, _obj.GetSpeed());
        }

        public void MoveToTargetXYZ()
        {
            Vector3 target = new Vector3(_obj.GetTarget().x, _obj.GetTarget().y, _obj.GetTarget().z);
            _obj.GetTransform().position = Vector3.MoveTowards(_obj.GetTransform().position, target, _obj.GetSpeed());
        }

        public void MoveToTargetXY()
        {
            Vector3 target = new Vector3(_obj.GetTarget().x, _obj.GetTarget().y, _obj.GetTransform().position.z);
            _obj.GetTransform().position = Vector3.MoveTowards(_obj.GetTransform().position, target, _obj.GetSpeed());
        }

        public void MoveToTargetYZ()
        {
            Vector3 target = new Vector3(_obj.GetTransform().position.x, _obj.GetTarget().y, _obj.GetTarget().z);
            _obj.GetTransform().position = Vector3.MoveTowards(_obj.GetTransform().position, target, _obj.GetSpeed());
        }

        public void MoveToTargetXZ()
        {
            Vector3 target = new Vector3(_obj.GetTarget().x, _obj.GetTransform().position.y, _obj.GetTarget().z);
            _obj.GetTransform().position = Vector3.MoveTowards(_obj.GetTransform().position, target, _obj.GetSpeed());
        }

        public void MoveToTargetX()
        {
            Vector3 target = new Vector3(_obj.GetTarget().x, _obj.GetTransform().position.y, _obj.GetTransform().position.z);
            _obj.GetTransform().position = Vector3.MoveTowards(_obj.GetTransform().position, target, _obj.GetSpeed());
        }

        public void MoveToTargetXPlus()
        {
            float currentPosX = _obj.GetTransform().position.x;
            float targetPosX = _obj.GetTarget().x;
            if (currentPosX < targetPosX)
                MoveToTargetX();
        }

        public void MoveToTargetXMinus()
        {
            float currentPosX = _obj.GetTransform().position.x;
            float targetPosX = _obj.GetTarget().x;
            if (currentPosX < targetPosX)
                MoveToTargetX();
        }

        public void MoveToTargetY()
        {
            Vector3 target = new Vector3(_obj.GetTransform().position.x, _obj.GetTarget().y, _obj.GetTransform().position.z);
            _obj.GetTransform().position = Vector3.MoveTowards(_obj.GetTransform().position, target, _obj.GetSpeed());
        }

        public void MoveToTargetYPlus()
        {
            float currentPosY = _obj.GetTransform().position.y;
            float targetPosY = _obj.GetTarget().y;
            if (currentPosY < targetPosY)
                MoveToTargetY();
        }

        public void MoveToTargetYMinus()
        {
            float currentPosY = _obj.GetTransform().position.y;
            float targetPosY = _obj.GetTarget().y;
            if (currentPosY > targetPosY)
                MoveToTargetY();
        }

        public void MoveToTargetZ()
        {
            Vector3 target = new Vector3(_obj.GetTransform().position.x, _obj.GetTransform().position.y, _obj.GetTarget().z);
            _obj.GetTransform().position = Vector3.MoveTowards(_obj.GetTransform().position, target, _obj.GetSpeed());
        }

        public void MoveToTargetZPlus()
        {
            float currentPosZ = _obj.GetTransform().position.z;
            float targetPosZ = _obj.GetTarget().z;
            if (currentPosZ < targetPosZ)
                MoveToTargetZ();
        }

        public void MoveToTargetZMinus()
        {
            float currentPosZ = _obj.GetTransform().position.z;
            float targetPosZ = _obj.GetTarget().z;
            if (currentPosZ > targetPosZ)
                MoveToTargetZ();
        }


    }
}
