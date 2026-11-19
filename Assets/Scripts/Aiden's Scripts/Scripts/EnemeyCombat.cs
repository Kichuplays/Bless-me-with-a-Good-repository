using UnityEngine;

public class EnemeyCombat : MonoBehaviour
{
    public EnemyData data;

    public int currentHp;

    public bool isDead => currentHp <= 0;

    public void Inititalize(EnemyData enemyData)
    {
        data = enemyData;
        currentHp = data.enemyHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHp = Mathf.Max(0, currentHp - damage);
        Debug.Log("Enemey took damage");

    }

    public void Death()
    {
        if (isDead)
        {
            Destroy(gameObject);
        }
    }

}
