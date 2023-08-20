using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void Attack()
    {
        // L�gica para el ataque
        Debug.Log("�Has realizado un ataque!");
        GameController.Instance.EnemyTurn();
    }

    public void Block()
    {
        // L�gica para la defensa
        Debug.Log("�Bloqueado!");
        GameController.Instance.EnemyTurn();
    }

    public void Magic()
    {
        // L�gica para usar una habilidad especial
        Debug.Log("�Has usado una habilidad especial!");
        GameController.Instance.EnemyTurn();
    }
}
