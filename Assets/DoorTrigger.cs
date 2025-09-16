using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    public Transform player;
    public Transform cam;
    
    public GameObject scene1;
    public GameObject scene2;
    public Vector3 resetPlayerPos;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
         
           // scene1.SetActive(false);
            //scene2.SetActive(true);
            SceneManager.LoadScene(2);
            //cam.GetComponent<CameraMovement>().scene1 = false;
           // cam.GetComponent<CameraMovement>().scene2 = true;
           // player.transform.position = resetPlayerPos;
           // Vector3 pos=cam.transform.position;
          //  pos.x = -8.67f;
           // cam.transform.position = pos;
           // player.GetComponent<PlayerController>().posReset = true;
        }
    }
}
