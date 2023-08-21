public class EnemyPink : Enemy
{
    private int healValue = 9;
    private int porcentajeHealth = 40;
    public EnemyPink()
    {
        maxHealth = 40;      // Ajusta la vida para Pink
        attackPower = 8;     // Ajusta el poder de ataque para Pink
    }

    public override void Special()
    {
        currentHealth += healValue;
        StartCoroutine(DelayedPlayerTurn());
    }
    public override void SelectAction()
    {

        if (currentHealth <= maxHealth*(porcentajeHealth/100))
        {
            Special();
        }
        else
        {
            Attack();
        }
    }
}
