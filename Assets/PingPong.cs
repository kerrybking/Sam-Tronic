using UnityEngine;

public class PingPong : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Speed of the pulse (how fast it oscillates)
    public float pulseSpeed = 2f;

    // Colors to ping-pong between
    public Color colorA = Color.white; 
    public Color colorB = Color.red;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Calculate a value between 0 and 1 that goes back and forth
        float t = Mathf.PingPong(Time.time * pulseSpeed, 1f);

        // Lerp between colorA and colorB
        spriteRenderer.color = Color.Lerp(colorA, colorB, t);
    }
}
