namespace Base.Game.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Text))]
    public class BaseText : MyUI
    {
        protected Text _txt;
        protected override void Initialize()
        {
            base.Initialize();
            _txt = GetComponent<Text>();
        }
    }
}
