using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private bool onBattle = false;
    private void OnMouseDown()
    {
        if (onBattle == false)
        {
            GameController.Instance.PlayerTurn();
            onBattle = true;
        }
    }
    public void BattleOff() => onBattle = false;
}
