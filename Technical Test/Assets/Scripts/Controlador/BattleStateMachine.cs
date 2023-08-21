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
        UpdateLifes();
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
                // Lógica para el final del combate
                battleEvents.onBattleOver.Invoke();
                break;
        }
    }
    public void PInflictDamage(int damage)
    {
        currentEnemy.GetComponent<Enemy>().ReceiveDamage(damage);
    }
    public void EInflictDamage(int damage)
    {
        player.ReceiveDamage(damage);
    }
}
