using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;

    public event Action OnCoinCollected;
    public event Action OnPlayerHitEnemy;

    void Awake()
    {
        Instance = this;
    }

    public void CoinCollected()
    {
        OnCoinCollected?.Invoke();
    }

    public void PlayerHitEnemy()
    {
        OnPlayerHitEnemy?.Invoke();
    }
}



