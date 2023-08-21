using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;
    public int attackPower = 10;

    public void Awake()
    {
        currentHealth = maxHealth;
    }
    public virtual void Attack()
    {
        GameController.Instance.EnemyDamage(attackPower);
        Debug.Log("¡Has realizado atkque!");
        StartCoroutine(DelayedPlayerTurn());
    }
    public void WaitForSelect()
    {
        StartCoroutine(DelayedTurn());
    }
    public virtual void Special()
    {
    }
    public virtual void SelectAction()
    {
    }
    protected IEnumerator DelayedPlayerTurn()
    {
        // Esperar un tiempo antes de cambiar al turno del jugador
        yield return new WaitForSeconds(1f); // Ajusta el tiempo de espera según sea necesario

        GameController.Instance.Turn(GameState.PlayerTurn); // Cambiar al turno del jugador
    }
    protected IEnumerator DelayedTurn()
    {
        // Esperar un tiempo antes de cambiar al turno del jugador
        yield return new WaitForSeconds(1f); // Ajusta el tiempo de espera según sea necesario
        SelectAction();
    }
    public virtual void ReceiveDamage(int damage)
    {
        currentHealth -= damage;
    }
}
