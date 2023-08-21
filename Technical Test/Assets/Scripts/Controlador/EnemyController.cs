using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private bool onBattle = false;
    [SerializeField] private GameObject nextEnemy; 

    private void OnMouseDown()
    {
        if (onBattle == false)
        {
            GameController.Instance.SelectEnemy(this);
            GameController.Instance.Turn(GameState.PlayerTurn);
            onBattle = true;
        }
    }
    public void EnemyAction() => this.GetComponent<Enemy>().WaitForSelect();
    public GameState VerifyDeath(GameState state)
    {
        if (this.GetComponent<Enemy>().currentHealth <= 0)
        {
            return GameState.BattleOver;
        }
        else
        {
            return state;
        }

    }
    public void NextStep()
    {
        if (nextEnemy)
        {
            GameController.Instance.SpawnNextEnemy(nextEnemy);
        }
        else
        {
            GameController.Instance.WinGame();
        }
        Destroy(gameObject);
    }
}

