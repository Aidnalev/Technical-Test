using UnityEngine;

public class BattleStateMachine : MonoBehaviour
{
    private BattleEventController battleEvents;
    private GameState currentState;

    private void Awake()
    {
        battleEvents = GetComponent<BattleEventController>();
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        HandleStateChange();
    }

    private void HandleStateChange()
    {
        switch (currentState)
        {
            case GameState.PlayerTurn:
                battleEvents.onPlayerTurn.Invoke();
                break;
            case GameState.EnemyTurn:
                // L�gica para el turno del enemigo
                battleEvents.onEnemyTurn.Invoke();
                break;

            case GameState.BattleOver:
                // L�gica para el final del combate
                battleEvents.onBattleOver.Invoke();
                break;
        }
    }
}
