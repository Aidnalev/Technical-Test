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

    public void PlayerTurn() => battleStateMachine.ChangeState(GameState.PlayerTurn); // Inicia el turno del jugador

    public void EnemyTurn() => battleStateMachine.ChangeState(GameState.EnemyTurn); // Inicia el turno del enemigo

    public void SelectEnemy(EnemyController enemy) => battleStateMachine.SetCurrentEnemy(enemy);
    public void PlayerDamage(int damage)
    {
        battleStateMachine.PInflictDamage(damage);
    }
    public void EnemyDamage(int damage)
    {
        battleStateMachine.EInflictDamage(damage);
    }
}
