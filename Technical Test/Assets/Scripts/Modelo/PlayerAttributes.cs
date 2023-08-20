using UnityEngine;

[System.Serializable]
public class PlayerAttributes : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int attackPower = 10;

    public PlayerAttributes()
    {
        currentHealth = maxHealth;
    }
}
