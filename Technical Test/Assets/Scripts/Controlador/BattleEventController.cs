using UnityEngine;
using UnityEngine.Events;

public class BattleEventController : MonoBehaviour
{
    public UnityEvent onPlayerTurn;
    public UnityEvent onEnemyTurn;
    public UnityEvent onBattleOver;
    public UnityEvent onStartCombat;
    public UnityEvent onGameOver;
    public UnityEvent<GameObject> onSpawnEnemy;
    public UnityEvent onYouWin;
    public UnityEvent<ItemBase> onPurchase;
    public UnityEvent onSell;

}
