using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FireVfx : MonoBehaviour
{
    [SerializeField] ParticleSystem lavaField;
    [SerializeField] ParticleSystem bubbleglow;
    [SerializeField] PlayerController playerController;
 
    
    private void Start()
    {
        lavaField.Stop();
        bubbleglow.Stop();

    }
    private void Update()
    {
     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlayerDie());
        }
    }
    IEnumerator PlayerDie()
    {
        if(playerController.DieFromFire==null)
        {
            playerController.DieFromFire = StartCoroutine(playerController.PlayerHealthBarFill());
        }
        playerController.canMove=false;
        playerController.jump.gameObject.SetActive(false);
        playerController.charcter.gameObject.SetActive(true);
        playerController.animator.SetBool("die",true);
        yield return new WaitForSeconds(playerController.animator.GetCurrentAnimatorStateInfo(0).length/2f);
        lavaField.gameObject.SetActive(true);
        bubbleglow.gameObject.SetActive(true);
        lavaField.Play();
        bubbleglow.Play();
        //yield return new WaitForSeconds(4f);
   

    }
}
