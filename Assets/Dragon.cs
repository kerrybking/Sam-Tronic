using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dragon : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] Image healthfill;
    public Animator animator;
    [SerializeField] Animator doorAnim;
    [SerializeField] GameObject doorTrigger;
    [SerializeField] GameObject commandPrompt;
    [SerializeField] Animator playerAnim;
    public GameObject dragonFire;
    [SerializeField] float normalDamage;
    public bool die;
    public ParticleSystem dieVFX;
    public ParticleSystem lavaFiedVfX;
    [SerializeField] GameObject healthBar;
    [SerializeField] Slime demonSlime;
    [SerializeField] Slime venomSlime;
    public Transform playerAttackPoint;
    private void Start()
    {
        dieVFX.Stop();
        lavaFiedVfX.Stop();
        die = false;
    }
    private void Update()
    {
        
        if (!onStay && !demonSlime.active && !venomSlime.active)
        {
            isAttacked = true;
            dragonFire.SetActive(false);
            animator.SetBool("attack", false);
            playerAnim.transform.parent.GetComponent<PlayerController>().normalAttack = false;
            playerAnim.transform.parent.GetComponent<PlayerController>().canFade = false;

 
        }

    }
    void EnableDieVfx()
    {
        dieVFX.gameObject.SetActive(true);
        dieVFX.Play();
    }
    void EnableLavaFieldVfx()
    {
        lavaFiedVfX.gameObject.SetActive(true);
        lavaFiedVfX.Play();
    }
    void DisableVfx()
    {
        if (lavaFiedVfX != null && dieVFX != null)
        {
            lavaFiedVfX.gameObject.SetActive(false);
            dieVFX.gameObject.SetActive(false);
            dieVFX.Stop();
            lavaFiedVfX.Stop();

        }
    }


    void DisableCommandPrompt()
    {
        commandPrompt.SetActive(false);
    }


    public void GetDamage(float damage)
    {
        if (!die)
        {
            if (health > 0)
                health -= damage;

            if (health <= 0)
            {
                dragonFire.SetActive(false);
                animator.SetBool("attack", false);
                animator.SetBool("die", true);
                doorAnim.SetBool("open", true);
                doorTrigger.SetActive(true);
                playerAnim.SetBool("super attack", false);
                Destroy(transform.GetComponent<BoxCollider2D>());
                Invoke(nameof(EnableDieVfx), 0f);
                healthBar.SetActive(false);
                Invoke(nameof(EnableLavaFieldVfx), 1f);
                Invoke(nameof(DisableVfx), 5f);

                die = true;
            }

            if (healthfill != null)
                healthfill.fillAmount = health / 100;

        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            if (!die)
            {
                onStay = true;
                isAttacked = false;
                animator.SetBool("attack", true);
                collision.gameObject.GetComponent<PlayerController>().normalAttack = true;
                Invoke(nameof(EnableFire), animator.GetCurrentAnimatorStateInfo(0).length / 3f);
                Invoke(nameof(EnableFadeIn), animator.GetCurrentAnimatorStateInfo(0).length / 3f);


            }
        }
    }
  
    private void OnTriggerExit2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            onStay = false;
            
            playerAnim.transform.parent.GetComponent<PlayerController>().canFade = false;

            if (playerAnim.transform.parent.GetComponent<PlayerController>().fadein != null)
            {
                StopCoroutine(playerAnim.transform.parent.GetComponent<PlayerController>().fadein);
            }

            playerAnim.transform.parent.GetComponent<PlayerController>().FadeOut();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (!die)
            {
                onStay = true;
                StartCoroutine(Attack(collision.gameObject));

            }

        }

    }
    bool onStay;
    void EnableFire()
    {
        dragonFire.SetActive(true);
    }
    bool isAttacked;

    private void EnableFadeIn()
    {
        playerAnim.transform.parent.GetComponent<PlayerController>().fadein = StartCoroutine(playerAnim.transform.parent.GetComponent<PlayerController>().FadeIn());
    }
    IEnumerator Attack(GameObject obj)
    {

        if (!isAttacked)
        {
            isAttacked = true;
            PlayerController player = obj.GetComponent<PlayerController>();

            while (!player.die && !die && onStay)
            {
                yield return new WaitForSeconds(0.5f);
                player.GetDamage(normalDamage);

            }
        }
    }

}
