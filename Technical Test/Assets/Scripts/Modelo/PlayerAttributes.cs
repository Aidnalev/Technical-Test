using UnityEngine;

[System.Serializable]
public class PlayerAttributes : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int attackPower = 10;
    public int healValue = 8;
    public int blockValue = 8;
    public int currency = 0;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
}
