using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrickButton : MonoBehaviour
{



    [SerializeField] GameObject mobileControls;
    public PlayerController playerController;
    public GameObject keyboardLandscape;
    public GameObject mobileCmdLandscape;
    public GameObject pcCmd;
    public TMP_InputField pcCmdInput;

    
    public void Brick()
    {
        if (playerController.controls == Controls.Mobile)
        {

            mobileCmdLandscape.SetActive(true);
            keyboardLandscape.SetActive(true);
            mobileControls.SetActive(false);
        }
        else if (playerController.controls == Controls.Pc)
        {
            pcCmd.SetActive(true);
            pcCmdInput.ActivateInputField();
        }
    }
}
