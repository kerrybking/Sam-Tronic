using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Slime : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] PlayerController player;
    [SerializeField] float damage;
    public float health;
    public bool die;
    [SerializeField] Image healthFill;
    [SerializeField] GameObject healthBar;
    [SerializeField] ParticleSystem dieVFX;
    [SerializeField] ParticleSystem lavaFiedVfX;
    public bool active;
    bool flip;
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
    public void GetDamage(float damage)
    {
        if (!die)
        {
            if (health > 0)
                health -= damage;

            if (health <= 0)
            {
               
                animator.SetBool("attack", false);
                animator.SetBool("die", true);
                Destroy(transform.GetComponent<CircleCollider2D>());
                Invoke(nameof(EnableDieVfx), 0f);
                healthBar.SetActive(false);
                Invoke(nameof(EnableLavaFieldVfx), 1f);
                Invoke(nameof(DisableVfx), 2f);
               // transform.GetComponent<SpriteRenderer>().sortingOrder =9;
                die = true;
            }

            if (healthFill != null)
               healthFill.fillAmount = health / 100;

        }


    }
    private void EnableFadeIn()
    {
        player.fadein = StartCoroutine(player.FadeIn());
    }
    private void Update()
    {

    
        if (!die)
        {
            flip = player.transform.position.x > transform.position.x;
            transform.GetComponent<SpriteRenderer>().flipX = flip;
        }

        if (die)
        {
            animator.SetBool("attack", false);
            animator.SetBool("die", true);

        }
        else if(!die && player.die)
        {
            animator.SetBool("attack", false);
            animator.SetBool("die", false);

        }
       
        
   

        if(!stay)
        {
            isAttacked = false;
          
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            active = true;
          //  transform.GetComponent<SpriteRenderer>().sortingOrder = 11;
            animator.SetBool("attack",true);
            player.slimeAttack = true;
            player.slime = this;
            Invoke(nameof(EnableFadeIn), animator.GetCurrentAnimatorStateInfo(0).length/2);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            active = false;
            animator.SetBool("attack", false);
            player.slime = null;
            player.slimeAttack = false;
            isAttacked = false;
            stay = false;
            player.canFade = false;
          
            if (player.fadein != null)
            {
                StopCoroutine(player.fadein);
            }

          player.FadeOut();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            stay=true;
            StartCoroutine(Attack(collision.gameObject));

        }
    }
    bool isAttacked;
    bool stay;
    IEnumerator Attack(GameObject obj)
    {

        if (!isAttacked)
        {
            isAttacked = true;
            PlayerController player = obj.GetComponent<PlayerController>();

            while (stay && !player.die && !die)
            {
                yield return new WaitForSeconds(0.5f);
                player.GetDamage(damage);

            }
        }
    }
}
