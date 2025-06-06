using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.onPlayerHitEnemy.Invoke();
        }
    }
}


