using UnityEngine;
using System.Diagnostics;

using System.IO;
using UnityEngine.EventSystems;

public class CommandPrompt : MonoBehaviour
{
    [SerializeField] PlayerController playerController;


    private void OnEnable()
    {
        playerController.canMove = false;
        playerController.player.linearVelocity = Vector2.zero;
        playerController.animator.SetFloat("Speed", 0f);
      
    }
    private void OnDisable()
    {
        playerController.canMove = true;
    }


}
