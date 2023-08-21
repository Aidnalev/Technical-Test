public class EnemyBoss : Enemy
{
    private int defenseValue = 8;
    private bool activeDefense = false;
    private int currentValue = 0;
    private int porcentajeHealth = 40;
    private int healValue = 9;
    public EnemyBoss()
    {
        maxHealth = 100;      // Ajusta la vida para Frog
        attackPower = 15;    // Ajusta el poder de ataque para Frog
    }
    public override void Special()
    {
        activeDefense = true;
        StartCoroutine(DelayedPlayerTurn());
    }
    public override void Attack()
    {
        base.Attack();
        activeDefense = false;
    }
    public override void SelectAction()
    {
        if (currentHealth <= maxHealth * (porcentajeHealth / 100))
        {
            Special2();
        }
        else if (currentValue == 0)
        {
            Attack();
        }
        else
        {
            Special();
        }
        currentValue = 1 - currentValue;
    }
    public void Special2()
    {
        currentHealth += healValue;
        activeDefense = false;
        StartCoroutine(DelayedPlayerTurn());
    }
    public override void ReceiveDamage(int damage)
    {
        if (activeDefense)
        {
            damage -= defenseValue;
            currentHealth -= damage;
        }
        else
        {
            base.ReceiveDamage(damage);
        }
    }
}
