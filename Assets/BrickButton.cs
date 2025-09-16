using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrickButton : MonoBehaviour, IPointerDownHandler
{



    [SerializeField] GameObject mobileControls;
    public PlayerController playerController;
    public GameObject KeyboardPortrait;
    public GameObject keyboardLandscape;
    public GameObject mobileCmdPortait;
    public GameObject mobileCmdLandscape;
    public GameObject pcCmd;
    public TMP_InputField pcCmdInput;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(playerController.controls==Controls.Mobile)
        {
            transform.parent.GetComponent<Canvas>().sortingOrder = 7;

            if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
            {
                mobileCmdPortait.SetActive(true);
                mobileCmdLandscape.SetActive(false);
                KeyboardPortrait.SetActive(true);
                keyboardLandscape.SetActive(false);
            }
            else if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
            {
                mobileCmdPortait.SetActive(false);
                mobileCmdLandscape.SetActive(true);
                KeyboardPortrait.SetActive(false);
                keyboardLandscape.SetActive(true);
            }

            mobileControls.SetActive(false);
        }
        else if(playerController.controls==Controls.Pc)
        {
            pcCmd.SetActive(true);
            pcCmdInput.ActivateInputField();
        }
       



    }
}
