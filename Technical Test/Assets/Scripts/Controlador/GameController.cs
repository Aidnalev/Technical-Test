using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    private BattleStateMachine battleStateMachine;

    private void Awake()
    {
        Instance = this;
        battleStateMachine = GetComponent<BattleStateMachine>();
    }

    public void Turn(GameState state) => battleStateMachine.VerificationState(state);

    public void SelectEnemy(EnemyController enemy) => battleStateMachine.SetCurrentEnemy(enemy);

    public void PlayerDamage(int damage) => battleStateMachine.PInflictDamage(damage);
 
    public void EnemyDamage(int damage) => battleStateMachine.EInflictDamage(damage);

    public void SpawnNextEnemy(GameObject enemy) => battleStateMachine.SpawnEnemy(enemy);
    public void WinGame() => battleStateMachine.YouWin();
    public void PurchaseItem(ItemBase item) => battleStateMachine.Purchase(item);
    public void SellItem(ItemBase item) => battleStateMachine.Sell(item);
}
