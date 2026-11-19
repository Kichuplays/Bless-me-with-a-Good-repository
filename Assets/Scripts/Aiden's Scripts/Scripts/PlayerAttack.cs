using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 2.3f;

    public void TryAttack()
    {
        Collider[] enemies =
            Physics.OverlapSphere(transform.position, attackRange);

        foreach(Collider enemy in enemies)
        {
            OverworldEnemy overworldEnemy =
                enemy.GetComponent<OverworldEnemy>();

            if (overworldEnemy != null)
            {
                overworldEnemy.StartBattle();

                return;
            }



        }

        Debug.Log("No enemies in range");

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
