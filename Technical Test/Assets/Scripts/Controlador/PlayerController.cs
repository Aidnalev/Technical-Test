using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerAttributes player;
    private bool inBlock = false;
    public void Start()
    {
        player = GetComponent<PlayerAttributes>();
    }
    public void Attack()
    {
        GameController.Instance.PlayerDamage(player.attackPower);
        inBlock = false;
        // Lógica para el ataque
        Debug.Log("¡Has realizado un ataque!");
        GameController.Instance.Turn(GameState.EnemyTurn);
    }

    public void Block()
    {
        inBlock = true;
        Debug.Log("¡Bloqueado!");
        GameController.Instance.Turn(GameState.EnemyTurn);
    }
    public void Heal()
    {
        inBlock = false;
        player.currentHealth += player.healValue;
        Debug.Log("¡Has usado una habilidad especial!");
        GameController.Instance.Turn(GameState.EnemyTurn);
    }
    public void ReceiveDamage(int damage)
    {
        if (inBlock)
        {
            damage -= player.blockValue;
            player.currentHealth -= damage;
        }
        else
        {
            player.currentHealth -= damage;
        }
    }
    public GameState VerifyGameOver(GameState state)
    {
        if (player.currentHealth <= 0)
        {
            return GameState.GameOver;
        }
        else
        {
            return state;
        }
    }
    public void EarnMoney()
    {
        int randomValue = Random.Range(80, 101);
        player.currency += randomValue;
    }
    public void Purchase(int price)
    {
        player.currency -= price;
    }
    public void Sell(int price)
    {
        player.currency += price;
    }
}
