namespace Base.Game.UI
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    [RequireComponent(typeof(Button))]
    public class BaseButton : MyUI, IPointerClickHandler
    {
        public virtual void OnPointerClick(PointerEventData eventData)
        {
        }
    }
}
