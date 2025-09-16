using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
