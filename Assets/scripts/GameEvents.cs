using UnityEngine;
using UnityEngine.Events;

public static class GameEvents
{
    public static UnityEvent onCoinCollected = new UnityEvent();
    public static UnityEvent onPlayerHitEnemy = new UnityEvent();
    public static UnityEvent onRestart = new UnityEvent(); 
}






