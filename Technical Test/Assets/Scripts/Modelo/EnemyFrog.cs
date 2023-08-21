public class EnemyFrog : Enemy
{
    private int defenseValue = 8;
    private bool activeDefense = false;
    private int currentValue = 0;
    public EnemyFrog()
    {
        maxHealth = 60;      // Ajusta la vida para Frog
        attackPower = 10;    // Ajusta el poder de ataque para Frog
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
        if (currentValue == 0)
        {
            Attack();
        }
        else
        {
            Special();
        }
        currentValue = 1 - currentValue;
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
