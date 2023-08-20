using UnityEngine;

public class CombatMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject combatMenu;
    public void ShowCombatMenu()
    {
        combatMenu.SetActive(true);
    }

    public void HideCombatMenu()
    {
        combatMenu.SetActive(false);
    }
}
