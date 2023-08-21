using UnityEngine;

public class CombatMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject combatMenu;
    [SerializeField] private GameObject enemyLife;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject victory;
    [SerializeField] private GameObject store;
    [SerializeField] private GameObject inventory;
    public void ShowCombatMenu() => combatMenu.SetActive(true);
    public void HideCombatMenu() => combatMenu.SetActive(false);
    public void ShowEnemyLife() => enemyLife.SetActive(true);
    public void HideEnemyLife() => enemyLife.SetActive(false);
    public void GameOverMenu() => gameOver.SetActive(true);
    public void NextEnemy(GameObject enemy) => enemy.SetActive(true);
    public void YouWin() => victory.SetActive(true);
    public void ShowStore()
    {
        store.SetActive(true);
        inventory.SetActive(true);
    }
    public void HideStore() 
    { 
        store.SetActive(false);
        inventory.SetActive(false);
    }

}
