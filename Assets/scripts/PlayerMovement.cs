using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float acceleration = 10f;
    public float maxSpeed = 5f;
    public float friction = 5f;
    public float visualTurnSmoothTime = 0.1f;

    private Rigidbody2D rb;
    private Vector2 input;
    private Vector2 currentVelocity;
    private Vector3 upVelocity = Vector3.zero;

    
    [SerializeField] private ParticleSystem[] accelerationParticles;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }

    void Update()
    {
        float x = 0f;
        float y = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            x -= 1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            x += 1f;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            y += 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            y -= 1f;

        input = new Vector2(x, y).normalized;

        
        if (accelerationParticles != null)
        {
            if (input.magnitude > 0)
            {
                foreach (var ps in accelerationParticles)
                {
                    if (!ps.isPlaying)
                        ps.Play();
                }
            }
            else
            {
                foreach (var ps in accelerationParticles)
                {
                    if (ps.isPlaying)
                        ps.Stop();
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (input.magnitude > 0)
        {
            currentVelocity = Vector2.MoveTowards(rb.linearVelocity, input * maxSpeed, acceleration * Time.fixedDeltaTime);
            rb.linearVelocity = currentVelocity;

            Vector3 targetUp = new Vector3(-input.y, input.x, 0f);
            Vector3 smoothedUp = Vector3.SmoothDamp(transform.up, targetUp, ref upVelocity, visualTurnSmoothTime);
            if (smoothedUp.sqrMagnitude > 0.001f)
                transform.up = smoothedUp.normalized;
        }
        else
        {
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, Vector2.zero, friction * Time.fixedDeltaTime);
        }
    }
}







