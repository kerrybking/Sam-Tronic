using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    bool hasLoaded;
    private void Update()
    {
      
            if (hasLoaded)
                return;


            if (DeviceDetector.IsPc)
            {
                if (KeyboardKeyDown())
                {
                    hasLoaded = true;
                    SceneManager.LoadScene(1);
              
                }

            }
            else
            {
                if(Input.GetMouseButtonDown(0))
                {
                    hasLoaded=true;
                    SceneManager.LoadScene(1);


                }
            }
        

        }
    

    public bool KeyboardKeyDown()
    {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
        
            if (key >= KeyCode.Mouse0 && key <= KeyCode.Mouse6)
                continue;

           
            if (key.ToString().StartsWith("JoystickButton"))
                continue;

            if (Input.GetKeyDown(key))
                return true;
        }

        return false;
    }
 
}
