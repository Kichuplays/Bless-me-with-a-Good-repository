using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    public float moveSpeed;
    public float changeDirectionTime;

    private Vector3 direction;
    private float timer;

    private void Start()
    {
        PickDirection();
    }


    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <=0)
        {
            PickDirection();

        }
        transform.position +=
            direction *
            moveSpeed *
            Time.deltaTime;
    }

    private void PickDirection()
    {
        direction = new Vector3(
            Random.Range(-1f, 1f),
            0,
            Random.Range(-1f, 1f)
            ).normalized;

        timer = changeDirectionTime;
    }

}
