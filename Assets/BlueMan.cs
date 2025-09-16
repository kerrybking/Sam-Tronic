using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;

public class BlueMan : MonoBehaviour
{
    public bool move;
    [SerializeField] Transform[] waypoints;
    [SerializeField] float speed;
    [SerializeField] Transform princess;
    [SerializeField] Animator playerAnim;
    [SerializeField] Animator bluemanAnim;
    public GameObject princess2;
    public GameObject gameOver;
    public GameObject redButton;



    Material material;
     int index = 0;
     bool grab;

 
    private void Update()
    {
        if(move && !redButton.GetComponent<RedBrickButton>().levelCompleted)
        {
            playerAnim.SetFloat("Speed",0f);
            bluemanAnim.SetBool("walk",true);

            transform.position = Vector2.MoveTowards(transform.position, waypoints[index].transform.position, speed*Time.deltaTime);

            if (transform.position == waypoints[index].position)
            {
                while(!grab)
                {
                    bluemanAnim.SetBool("walk", false);
                    StartCoroutine(Matrix());
                    princess.transform.SetParent(transform);
                    Vector3 scale = princess.transform.localScale;
                    scale.x = Mathf.Abs( scale.x);
                    princess.transform.localScale = scale;
                    princess.transform.localPosition = new Vector2(.15f, -0.1f);
                    Invoke("GrabPrincess", 1f);
                    return;
                }
                SetIndex();
            }
        }
       
    }
    void SetIndex()
    {
       if(index<waypoints.Length-2)
        {
            index++;
        }
       else
        {
            index=waypoints.Length-1;

            if (transform.position == waypoints[index].position)
            {
                gameOver.SetActive(true);
                redButton.GetComponent<Canvas>().sortingOrder = 7;
            }
        }
    }
    void GrabPrincess()
    {
     
        grab = transform.childCount > 0 && fadein;
    
    }
    bool matrixed;
    bool fadein;
    float t;
    IEnumerator Matrix()
    {
        if (!matrixed)
        {
            matrixed = true;

            while (!fadein)
            {
                var renderer = GetComponent<SpriteRenderer>();
                var mpb = new MaterialPropertyBlock();
                renderer.GetPropertyBlock(mpb);

                float overlayStrength = mpb.GetFloat("_OverlayStrength");
                float effectBlend = mpb.GetFloat("_EffectBlend");

                t += Time.deltaTime * 1f;
                t = Mathf.Clamp01(t);

                if (t <= 1f)
                {
                    overlayStrength = Mathf.Lerp(0f, 1f, t);
                    effectBlend = Mathf.Lerp(0f, 0.7f, t);

                    mpb.SetFloat("_OverlayStrength", overlayStrength);
                    mpb.SetFloat("_EffectBlend", effectBlend);

                    renderer.SetPropertyBlock(mpb);
                    

                    princess2.SetActive(true);

                    if (t >= 1f)
                    {
                        fadein = true;
                    }
                }

                Debug.Log("_OverlayStrength = " + overlayStrength);
                Debug.Log("_EffectBlend = " + effectBlend);

                yield return new WaitForEndOfFrame();
            }
        }
    }

}



