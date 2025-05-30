using UnityEngine;

public class Coin : MonoBehaviour
{
    public Vector2 minPosition = new Vector2(-8f, -4f);
    public Vector2 maxPosition = new Vector2(8f, 4f);
    public float rotationSpeed = 180f;
    public float minDistanceFromPlayer = 1.5f;

    private float currentYRotation = 0f;
    private Transform player;

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    private void Update()
    {
        currentYRotation += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, currentYRotation, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.Instance.CoinCollected();

            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 newPosition;
        do
        {
            float x = Random.Range(minPosition.x, maxPosition.x);
            float y = Random.Range(minPosition.y, maxPosition.y);
            newPosition = new Vector2(x, y);
        }
        while (player != null && Vector2.Distance(newPosition, player.position) < minDistanceFromPlayer);

        transform.position = newPosition;
    }
}



