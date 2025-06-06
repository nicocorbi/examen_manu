using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float baseRadius = 5f;
    public float amplitude = 2f;
    public float frequency = 1f;
    public int initialEnemyCount = 3;

    private int enemyCount;
    private List<GameObject> activeEnemies = new();
    private float elapsedTime = 0f;

    void Start()
    {
        enemyCount = initialEnemyCount;
        SpawnEnemies();
        GameEvents.onCoinCollected.AddListener(OnCoinCollected);
    }

   

    void Update()
    {
        elapsedTime += Time.deltaTime;

        float radialOffset = Mathf.Sin(elapsedTime * frequency) * amplitude;
        float currentRadius = baseRadius + radialOffset;

        for (int i = 0; i < activeEnemies.Count; i++)
        {
            float angle = (2 * Mathf.PI / enemyCount) * i;
            Vector2 pos = (Vector2)transform.position + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * currentRadius;
            activeEnemies[i].transform.position = pos;
        }
    }

    void SpawnEnemies()
    {
        foreach (var enemy in activeEnemies)
            Destroy(enemy);
        activeEnemies.Clear();

        for (int i = 0; i < enemyCount; i++)
        {
            float angle = (2 * Mathf.PI / enemyCount) * i;
            Vector2 pos = (Vector2)transform.position + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * baseRadius;
            GameObject enemy = Instantiate(enemyPrefab, pos, Quaternion.identity);
            activeEnemies.Add(enemy);
        }
    }

    void OnCoinCollected()
    {
        enemyCount++;
        SpawnEnemies();
    }
}









