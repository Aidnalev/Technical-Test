using UnityEngine;

public class BattleStateMachine : MonoBehaviour
{
    private BattleEventController battleEvents;
    private GameState currentState;
    private EnemyController currentEnemy;
    [SerializeField] private PlayerController player;
    [SerializeField] private HealthBarManager healthBarManager;
    [SerializeField] private EnemyHealthBarManager enemyHealthBarManager;

    private void Awake()
    {
        battleEvents = GetComponent<BattleEventController>();
    }

    public void SetCurrentEnemy(EnemyController enemy)
    {
        currentEnemy = enemy;
        battleEvents.onStartCombat.Invoke();
    }
    public void ChangeState(GameState newState)
    {
        currentState = newState;
        HandleStateChange();
    }
    private void UpdateLifes()
    {
        healthBarManager.UpdateHealthBar(player.GetComponent<PlayerAttributes>().currentHealth, player.GetComponent<PlayerAttributes>().maxHealth);
        enemyHealthBarManager.UpdateHealthBar(currentEnemy.GetComponent<Enemy>().currentHealth, currentEnemy.GetComponent<Enemy>().maxHealth);
    }
    private void HandleStateChange()
    {
        switch (currentState)
        {
            case GameState.PlayerTurn:
                battleEvents.onPlayerTurn.Invoke();
                break;
            case GameState.EnemyTurn:
                currentEnemy.EnemyAction();
                battleEvents.onEnemyTurn.Invoke();
                break;

            case GameState.BattleOver:
                battleEvents.onBattleOver.Invoke();
                currentEnemy.NextStep();
                break;
            case GameState.GameOver:
                battleEvents.onGameOver.Invoke();
                break;
        }
    }
    public void PInflictDamage(int damage) => currentEnemy.GetComponent<Enemy>().ReceiveDamage(damage);
    public void EInflictDamage(int damage) => player.ReceiveDamage(damage);
    public void SpawnEnemy(GameObject enemy) => battleEvents.onSpawnEnemy.Invoke(enemy);
    public void VerificationState(GameState newState)
    {
        newState = currentEnemy.VerifyDeath(newState);
        newState = player.VerifyGameOver(newState); //Verificar si ya perdio el jugador
        UpdateLifes(); //Actualizar vidas
        ChangeState(newState);
    }
    public void YouWin() => battleEvents.onYouWin.Invoke();
    public void Purchase(ItemBase item)
    {
        if (player.GetComponent<PlayerAttributes>().currency>= item.buyPrice)
        {
            player.Purchase(item.buyPrice);
            item.isAvailable = false;
            battleEvents.onPurchase.Invoke(item);
        }
    }
    public void Sell(ItemBase item)
    {
        player.Sell(item.sellPrice);
        item.isAvailable = true;
        battleEvents.onSell.Invoke();
    }
}
