using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI muerteText;

    private int score = 0;
    private GameObject player;
    private bool isPlayerDead = false;

    void Awake()
    {
        Instance = this;
        UpdateScoreText();
        muerteText.gameObject.SetActive(false);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameEvents.onCoinCollected.AddListener(OnCoinCollected);
        GameEvents.onPlayerHitEnemy.AddListener(OnPlayerHitEnemy);
        GameEvents.onRestart.AddListener(RestartScene);
    }

    void Update()
    {
        
        if (isPlayerDead && Input.GetKeyDown(KeyCode.E))
        {
            GameEvents.onRestart.Invoke();
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

        if (score == 0)
        {
            isPlayerDead = true;
            Destroy(player);
            muerteText.gameObject.SetActive(true);
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void UpdateScoreText()
    {
        scoreText.text = " " + score;
        print(score);
    }
}






