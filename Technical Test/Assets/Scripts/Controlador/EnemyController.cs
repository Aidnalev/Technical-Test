using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private bool onBattle = false;
    public BattleEventController battleEventController;

    public void Start()
    {
        battleEventController.onBattleOver.AddListener(BattleOff);
    }
    private void OnMouseDown()
    {
        if (onBattle == false)
        {
            GameController.Instance.SelectEnemy(this);
            GameController.Instance.PlayerTurn();
            onBattle = true;
        }
    }
    public void BattleOff() => onBattle = false;

    public void EnemyAction() => this.GetComponent<Enemy>().WaitForSelect();
}

