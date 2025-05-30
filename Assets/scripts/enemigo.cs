using UnityEngine;

public class enemigo : MonoBehaviour
{
    public Vector3 offset = Vector3.zero;
    public float pointA = -3f;
    public float pointB = 3f;
    public float speed = 2f;
    public float smooth = 5f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float currentY;
    private int direction = 1;

    void Start()
    {
        startPosition = transform.position + offset;
        currentY = pointA;
    }

    void Update()
    {
        currentY += direction * speed * Time.deltaTime;

        if (currentY >= pointB)
        {
            currentY = pointB;
            direction = -1;
        }
        else if (currentY <= pointA)
        {
            currentY = pointA;
            direction = 1;
        }

        targetPosition = startPosition + new Vector3(0f, currentY, 0f);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smooth * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameEvents.Instance != null)
                GameEvents.Instance.PlayerHitEnemy();
        }
    }
}




