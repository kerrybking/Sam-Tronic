


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public InputActionAsset _inputActionAsset;
    public Rigidbody2D player;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    public Vector2 dir;
    InputAction _Jump;
    InputAction _Move;
    InputAction _CommandPrompt;
    InputAction _attack;
    [SerializeField] bool grounded;
    [SerializeField] Transform princess;
    [SerializeField] BlueMan blueman;
    public Animator animator;
    [SerializeField] float dis;
    public bool posReset;
    public bool canMove;
    public LayerMask layer;
    [SerializeField] Transform groundCheck;
    public bool bigJump;
    [SerializeField] Transform[] BigJumpPath;
    public SpriteRenderer jump;
    public SpriteRenderer charcter;
    public float normalDamage;
    public float superDamage;
    public float slimeDamage;
    [SerializeField] Dragon dragon;
    public GameObject pcCmd;
    [SerializeField] TMPro.TMP_InputField inputField;
    public bool superAttack;
    public bool die;
    public bool normalAttack;
    public bool slimeAttack;
    public float health;
    public GameObject lavafiedVFX;
    [SerializeField] Image playerHealthBar;
    [SerializeField] float fireDamage;
    
    [HideInInspector] public Slime slime;
    public Controls controls;
    public RightButton rightbutton;
    public LeftButton leftbutton;
    public JumpButton jumpbutton;
    public GameObject brickbutton;
    public GameObject brickbutton2;
    public GameObject Redbrickbutton;
    public SwordButton swordbutton;
  
    public GameObject mobileControls;

    public RectTransform userInput;
 
    public GameObject pcFrontCollider;
    public GameObject mobileFrontCollider;

    public GameObject KeyboardPortrait;
    public GameObject keyboardLandscape;
    public GameObject mobileCmdPortait;
    public GameObject mobileCmdLandscape;

    public GameObject portraitPanels;
    public GameObject landscapePanels;
   [HideInInspector] public bool bigJumpEnabled;
   [HideInInspector] public bool attackEnabled;
    public GameObject doorTrigger;
    public CameraMovement cam;
    private void Start()
    {
    

 
        controls = DeviceDetector.IsPc ? Controls.Pc : Controls.Mobile;

        if (controls == Controls.Pc)
        {
            _inputActionAsset.FindActionMap("Player").Enable();
            _Jump = _inputActionAsset.FindAction("Jump");
            _Move = _inputActionAsset.FindAction("Move");
            _CommandPrompt = _inputActionAsset.FindAction("CommandPrompt");
            _attack = _inputActionAsset.FindAction("Attack");

            mobileControls.SetActive(false);
            if(brickbutton!=null)
            brickbutton.SetActive(true);
            if(brickbutton2!=null)
            brickbutton2.SetActive(false);
            if(pcFrontCollider!=null)
            pcFrontCollider.SetActive(true);
            if(mobileFrontCollider!=null)
            mobileFrontCollider.SetActive(false);
      

        

        }
        else if (controls == Controls.Mobile)
        {
           

            _inputActionAsset.FindActionMap("Player").Disable();
            mobileControls.SetActive(true);
            if(brickbutton!=null)
            brickbutton.SetActive(true);
            if(brickbutton2!=null)
            brickbutton2.SetActive(true);
            if(pcFrontCollider!=null)
            pcFrontCollider.SetActive(false);
            if(mobileFrontCollider!=null)
            mobileFrontCollider.SetActive(true);

        


          

        }
    

        canMove = true;

       


    }
  

    public Coroutine DieFromFire;
    public IEnumerator PlayerHealthBarFill()
    {

        while (health > 0)
        {
            health -= fireDamage;
            health = Mathf.Max(health, 0);
            playerHealthBar.fillAmount = health / 100f;
            yield return new WaitForSeconds(1f);
        }
    }
    void MoveRight()
    {
        dir.x = 1;
    }
    void MoveLeft()
    {
        dir.x = -1;
    }

    bool wasSwordButtonpressthisframe;
    bool wasSwordButtonPress;
    GameObject GetUIUnderPointer()
    {
        if (EventSystem.current == null)
            return null;

        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, raycastResults);

        if (raycastResults.Count > 0)
        {
            // The first result is the topmost UI element
            return raycastResults[0].gameObject;
        }

        return null;
    }
    private void Update()
    {
        if (controls == Controls.Mobile)
        {
            if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
            {


                portraitPanels.SetActive(true);
                landscapePanels.SetActive(false);
                if(brickbutton2!=null)
                brickbutton2.gameObject.SetActive(true);

                if (mobileCmdPortait.activeSelf == false && KeyboardPortrait.activeSelf == false)
                {
                   
                    keyboardLandscape.SetActive(false);
                    mobileCmdLandscape.SetActive(false);
                    mobileControls.SetActive(true);
               

                }

            }
            else if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
            {

                portraitPanels.SetActive(false);
                landscapePanels.SetActive(true);
                if(brickbutton2!=null)
                brickbutton2.gameObject.SetActive(false);

                if (mobileCmdLandscape.activeSelf == false && keyboardLandscape.activeSelf == false)
                {
                   
                    KeyboardPortrait.SetActive(false);
                    mobileCmdPortait.SetActive(false);
                    mobileControls.SetActive(true);
                   
                 
                }

            }
        }
      


        if (health <= 0 && DieFromFire != null)
        {
            StopCoroutine(DieFromFire);
            DieFromFire = null;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("die from fire stop");
        }

        if (health <= 0)
        {
            player.linearVelocity = Vector2.zero;
        }

        if (!die)
        {


            if (canMove)
            {


                RaycastHit2D hit = Physics2D.CircleCast(groundCheck.position, 0.05f, Vector2.down, 0.01f, layer);
                grounded = hit.collider != null;

                if (princess != null && cam.scene2)
                {
                    Debug.Log("scene 2");

                    if (Vector2.Distance(player.position, princess.position) <= dis)
                    {
                       

                            blueman.move = true;
                            canMove = false;
                            player.linearVelocity = Vector2.zero;

                        

                    }
                }

                if (!die)
                {
                    charcter.gameObject.SetActive(grounded);
                    jump.gameObject.SetActive(!grounded);

                }

                if (controls == Controls.Pc)
                {

                    if (_attack.WasPerformedThisFrame() && dir.x == 0)
                    {

                        GameObject hoveredUI = GetUIUnderPointer();

                        if (hoveredUI != null)
                        {
                            
                            if (hoveredUI.tag != "Untagged")
                            {
                                animator.SetBool("attack", true);
                                Invoke(nameof(GiveDamage), animator.GetCurrentAnimatorStateInfo(0).length / 2);

                            }

                        }
                        else
                        {
                            animator.SetBool("attack", true);
                            Invoke(nameof(GiveDamage), animator.GetCurrentAnimatorStateInfo(0).length / 2);
                        }
                     

                    }
                    else
                    {
                        animator.SetBool("attack", false);

                    }

                    if (_CommandPrompt.WasPerformedThisFrame())
                    {

                        Invoke("EnablePrompt", 0.1f);

                    }
                }
                else if (controls == Controls.Mobile)
                {
                   


                    if (swordbutton.press && !wasSwordButtonPress)
                    {
                        wasSwordButtonpressthisframe = true;
                    }
                    else
                    {
                        wasSwordButtonpressthisframe = false;
                    }

                    wasSwordButtonPress = swordbutton.press;

                    if (wasSwordButtonpressthisframe && dir.x == 0)
                    {

                        animator.SetBool("attack", true);
                        Invoke(nameof(GiveDamage), animator.GetCurrentAnimatorStateInfo(0).length / 2);
                    }
                    else
                    {
                        animator.SetBool("attack", false);

                    }
                }

               
                if (controls == Controls.Pc)
                {
                    dir = _Move.ReadValue<Vector2>();

                }
                else if (controls == Controls.Mobile)
                {
                    if (rightbutton.press && rightbutton != null)
                    {
                        dir.x = 1;
                    }
                    else if (leftbutton.press && leftbutton != null)
                    {
                        dir.x = -1;
                    }
                    else
                    {
                        dir.x = 0;

                    }
                }

                if (dir.x > 0 || dir.x < 0)
                {
                    if (dir.x > 0)
                    {
                        Vector3 scale = player.transform.localScale;
                        scale.x = 1f;
                        player.transform.localScale = scale;
                    }
                    else if (dir.x < 0)
                    {
                        Vector3 scale = player.transform.localScale;
                        scale.x = -1f;
                        player.transform.localScale = scale;
                    }




                }

                animator.SetFloat("Speed", Mathf.Abs(dir.x));


                if (controls == Controls.Pc)
                {


                    if (_Jump.WasPressedThisFrame() && grounded)
                    {
                        player.linearVelocity = new Vector2(player.linearVelocity.x, jumpForce);

                    }
                }
                else if (controls == Controls.Mobile)
                {
                    if (jumpbutton.press && grounded)
                    {
                        player.linearVelocity = new Vector2(player.linearVelocity.x, jumpForce);
                    }
                }


            }
            //AttackEvent();

            if (health <= 0)
            {

                lavafiedVFX.SetActive(true);
                animator.SetBool("die", true);
                dragon.dragonFire.SetActive(false);
                dragon.animator.SetBool("attack", false);
                Invoke(nameof(Reload), 5f);
                die = true;
            }

        }
        else
        {
            canMove = false;


        }
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            Movemennt(dir);

        }
     
        BigJumpEvent();
       StartCoroutine(AttackEvent());
    }
    void EnablePrompt()
    {
        

            if (!isAttacked || !isJumped)
            {
                if (pcCmd != null)
                    pcCmd.SetActive(true);

                if (inputField != null)
                    inputField.ActivateInputField();
            }
        
    }
    public void GiveDamage()
    {
        if (normalAttack)
        {
            if (dragon != null)
                dragon.GetDamage(normalDamage);

        }
        else if (slimeAttack)
        {
            if (slime != null)
                slime.GetDamage(slimeDamage);
        }
    }

    void Movemennt(Vector2 dir)
    {
        player.linearVelocity = new Vector2(dir.x * moveSpeed, player.linearVelocity.y);

    }
    int index = 0;
    [SerializeField] float bigJumpSpeed;
    bool isJumped;
   [HideInInspector] public bool canBigJump;
    public void BigJumpEvent()
    {
        if (bigJump)
        {
            canMove = false;
            //  charcter.gameObject.SetActive(false);
            // jump.gameObject.SetActive(true);
            Vector3 scale = player.transform.localScale;
            scale.x = scale.x == -1 ? 1 : scale.x;
            player.transform.localScale = scale;
            charcter.gameObject.SetActive(false);
            jump.gameObject.SetActive(true);
            player.bodyType = RigidbodyType2D.Kinematic;
            player.position = Vector2.MoveTowards(player.position, BigJumpPath[index].position, bigJumpSpeed * Time.fixedDeltaTime);

            if (player.transform.position == BigJumpPath[index].position)
            {
                if (index < BigJumpPath.Length - 1)
                {
                    index++;
                }
                else if (index > BigJumpPath.Length)
                {
                    index = BigJumpPath.Length - 1;
                }

            }
            if (index >= BigJumpPath.Length - 1)
            {
                if (player.transform.position == BigJumpPath[index].position)
                {
                    jump.gameObject.SetActive(false);
                    charcter.gameObject.SetActive(true);

                    player.bodyType = RigidbodyType2D.Dynamic;
                    canAttack = true;
                    isJumped = true;
                    canMove = true;
                    bigJump = false;
                    canBigJump = false;



                }

            }
        }
    }
    bool canAttack;
   [HideInInspector] public bool canSuperWipe;

    public IEnumerator AttackEvent()
    {
     
            if (superAttack && canAttack)
            {
                superAttack = false;
                canAttack= false;
                canMove = false;
                Vector3 scale = player.transform.localScale;
                scale.x = Mathf.Abs(scale.x);
                player.transform.localScale = scale;


                while(Vector2.Distance(player.transform.position, dragon.playerAttackPoint.position) > 0.1f)
                {
                    player.transform.position = Vector2.MoveTowards(player.transform.position, dragon.playerAttackPoint.position, 1.5f * Time.fixedDeltaTime);
                    animator.SetFloat("Speed", 1);
                    yield return new WaitForFixedUpdate();
                }
           
              animator.SetBool("super attack", true);
              yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
              SuperDragonDamage();
              animator.SetBool("super attack", false);
              doorTrigger.SetActive(true);
              canMove = true;
            }

        
        
    }
    
    void NormalDragonDamage()
    {
        dragon.GetDamage(normalDamage);
    }
    void SuperDragonDamage()
    {
        dragon.GetDamage(superDamage);
    }
    bool isAttacked;
    public void GetDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
        if (health <= 0)
        {
            player.linearVelocity = Vector2.zero;
            lavafiedVFX.SetActive(true);
            animator.SetBool("die", true);
            animator.SetBool("attack", false);
            dragon.dragonFire.SetActive(false);
            dragon.animator.SetBool("attack", false);
            canFade = false;
            die = true;
            Invoke(nameof(Reload), 5f);
        }

        if (playerHealthBar != null)
            playerHealthBar.fillAmount = health / 100f;
    }
    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public bool canFade;
    public float delay;

    public Coroutine fadein;
    public IEnumerator FadeIn()
    {
        canFade = true;
        Color color = charcter.color;

        while (canFade)
        {

            color.a = 0.4f;
            charcter.color = color;
            yield return new WaitForSeconds(delay);
            color.a = 1f;
            charcter.color = color;
            yield return new WaitForSeconds(delay);

        }


    }
    public void FadeOut()
    {


        Color color = charcter.color;
        color.a = 1f;
        charcter.color = color;

    }





}
public enum Controls
{
    Mobile, Pc
}

