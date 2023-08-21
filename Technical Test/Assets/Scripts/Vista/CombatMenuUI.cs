using UnityEngine;

public class CombatMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject combatMenu;
    [SerializeField] private GameObject enemyLife;
    public void ShowCombatMenu()
    {
        combatMenu.SetActive(true);
    }

    public void HideCombatMenu()
    {
        combatMenu.SetActive(false);

    }
    public void ShowEnemyLife()
    {
        enemyLife.SetActive(true);
    }
    public void HideEnemyLife()
    {
        enemyLife.SetActive(false);
    }
}
