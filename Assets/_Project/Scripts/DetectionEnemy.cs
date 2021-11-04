using UnityEngine;

public class DetectionEnemy : MonoBehaviour
{

    [SerializeField] private GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.GetComponent<EnemyAttack>().setRange(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.GetComponent<EnemyAttack>().setRange(false);
        }
    }

}
