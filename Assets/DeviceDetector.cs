using TMPro;
using UnityEngine;

public class DeviceDetector : MonoBehaviour
{
    
    public  static bool IsPc;


  

    public void ReceiveDeviceType(string device)
    {
     
        if(device.Equals("Mobile"))
        {
            IsPc = false;
        }
        else if(device.Equals("Pc"))
        {

            IsPc= true;
        }

  
    }

}
