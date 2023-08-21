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
        GameController.Instance.EnemyTurn();
    }

    public void Block()
    {
        inBlock = true;
        Debug.Log("¡Bloqueado!");
        GameController.Instance.EnemyTurn();
    }
    public void Heal()
    {
        inBlock = false;
        player.currentHealth += player.healValue;
        Debug.Log("¡Has usado una habilidad especial!");
        GameController.Instance.EnemyTurn();
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
}
