using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] GameObject scene1;
    [SerializeField] GameObject scene2;
    [SerializeField] Vector3 playerPos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            scene1.SetActive(false);
            scene2.SetActive(true);
            collision.gameObject.transform.position = playerPos;
            collision.gameObject.GetComponent<PlayerController>().posReset = true;
        }
    }
}
