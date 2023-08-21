using UnityEngine;

public class EnemyVirtual : Enemy
{
    private int dodgeProb = 30;
    private bool activeDodge = false;
    public EnemyVirtual()
    {
        maxHealth = 45;      // Ajusta la vida para Virtual
        attackPower = 12;    // Ajusta el poder de ataque para Virtual
    }

    public override void Special()
    {
        activeDodge = true;
        StartCoroutine(DelayedPlayerTurn());
    }
    public override void Attack()
    {
        base.Attack();
        activeDodge = false;
    }
    public override void SelectAction()
    {
        bool useAttack = Random.Range(0, 2) == 0;

        if (useAttack)
        {
            Attack();
        }
        else
        {
            Special();
        }
    }
    public override void ReceiveDamage(int damage)
    {
        float randomValue = Random.Range(0f, 100f);
        if (activeDodge && randomValue<dodgeProb)
        {
        }
        else
        {
            base.ReceiveDamage(damage);
        }
    }
}
