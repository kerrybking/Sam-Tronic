using UnityEngine;
using UnityEngine.EventSystems;

public class RightButton :MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool press;
    public void OnPointerDown(PointerEventData eventData)
    {
       press = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        press = false;
    }


}
