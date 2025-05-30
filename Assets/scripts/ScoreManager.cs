using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TextMeshProUGUI scoreText;
    private int score = 0;
    private bool isSubscribed = false;
    private GameObject player;

    void Awake()
    {
        Instance = this;
        UpdateScoreText();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!isSubscribed && GameEvents.Instance != null)
        {
            GameEvents.Instance.OnCoinCollected += OnCoinCollected;
            GameEvents.Instance.OnPlayerHitEnemy += OnPlayerHitEnemy;
            isSubscribed = true;
        }
    }

    void OnDestroy()
    {
        if (isSubscribed && GameEvents.Instance != null)
        {
            GameEvents.Instance.OnCoinCollected -= OnCoinCollected;
            GameEvents.Instance.OnPlayerHitEnemy -= OnPlayerHitEnemy;
        }
    }

    private void OnCoinCollected()
    {
        score += 1;
        UpdateScoreText();
    }

    private void OnPlayerHitEnemy()
    {
        score -= 1;
        if (score < 0) score = 0;
        UpdateScoreText();

        if (score == 0 && player != null)
        {
            Destroy(player);
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = " " + score;
        print(score);
    }
}



