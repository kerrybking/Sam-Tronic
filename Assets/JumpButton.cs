using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour,IPointerDownHandler
{
    public bool press;
    

   
    private void Update()
    {
        if(press)
        {
            Invoke(nameof(ResetFlag),0.1f);
        }
    }
    void ResetFlag()
    {
        press = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        press = true;
    }
}
