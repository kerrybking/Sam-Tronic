using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    public bool scene1;
    public bool scene2;

  

    private void LateUpdate()
    {
        if (scene1)
        {


            if (player.GetComponent<PlayerController>().controls == Controls.Pc)
            {
                if (player.transform.position.x > 0 && player.transform.position.x <= 45f)
                {
                    transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
                }
            }
            else if (player.GetComponent<PlayerController>().controls == Controls.Mobile)
            {
                if (player.transform.position.x > 0 && player.transform.position.x <= 50f)
                {
                    transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
                }
            }

        }

        if (scene2)
        {
            if (player.GetComponent<PlayerController>().controls == Controls.Mobile)
            {
                if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
                {
                    if (player.transform.position.x > -8.67f && player.transform.position.x <= 8.46)
                    {
                        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
                    }
                }
                else if(Screen.orientation==ScreenOrientation.LandscapeLeft || Screen.orientation==ScreenOrientation.LandscapeRight)
                {
                    if (player.transform.position.x > -3.2f && player.transform.position.x <= 3.2f)
                    {
                        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
                    }
                    else if (player.transform.position.x < -3.2f)
                    {
                        transform.position = new Vector3(-3.2f, transform.position.y, transform.position.z);
                    }
                    else if (player.transform.position.x >= 3.2f)
                    {
                        transform.position = new Vector3(3.2f, transform.position.y, transform.position.z);
                    }
                }

            }
            else if(player.GetComponent<PlayerController>().controls == Controls.Pc)
            {
                if (player.transform.position.x > -2.5f && player.transform.position.x <= 2.5f)
                {
                    transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
                }
                else if(player.transform.position.x < -2.5f)
                {
                    transform.position = new Vector3(-2.5f, transform.position.y, transform.position.z);
                }
                else if (player.transform.position.x >= 2.5f)
                {
                    transform.position = new Vector3(2.5f, transform.position.y, transform.position.z);
                }


            }
        }
    }
}
