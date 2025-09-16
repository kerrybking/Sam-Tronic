using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public PlayerController playerController;
    public void HintPanelEnable()
    {
        if (playerController.brickbutton!=null )
         playerController.brickbutton.GetComponent<Canvas>().sortingOrder = 7;
            
        if (playerController.brickbutton2 != null) 
            playerController.brickbutton2.GetComponent<Canvas>().sortingOrder = 7;

        if (playerController.Redbrickbutton != null)
            playerController.Redbrickbutton.GetComponent<Canvas>().sortingOrder = 7;


    }
    public void HintPanelDisable()
    {
        if (playerController.brickbutton != null)
            playerController.brickbutton.GetComponent<Canvas>().sortingOrder = 9;
            
        if (playerController.brickbutton2 != null)
            playerController.brickbutton2.GetComponent<Canvas>().sortingOrder = 9;

        if (playerController.Redbrickbutton != null)
            playerController.Redbrickbutton.GetComponent<Canvas>().sortingOrder = 9;


    }
    public void  RetryButton()
    {
        SceneManager.LoadScene(0);
    }
}
