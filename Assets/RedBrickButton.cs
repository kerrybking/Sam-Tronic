using UnityEngine;
using UnityEngine.EventSystems;

public class RedBrickButton : MonoBehaviour
{
    public GameObject levelCompletePanel;
    public BlueMan blueman;
    public bool levelCompleted;
  
    public void OpenLevelPanel()
    {
       if(!blueman.move)
        {
            transform.parent.GetComponent<Canvas>().sortingOrder = 7;
            levelCompletePanel.SetActive(true);
            levelCompleted = true;
        }
    
    }
    public void OpenNewTab()
    {
        if(!blueman.move)
        {
            Application.OpenURL("https://thecodemaker.com/riddleme1");
        }
      
       
    }
}
