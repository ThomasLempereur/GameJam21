using UnityEngine;


public class WeakSpot : MonoBehaviour
{

    [SerializeField] private GameObject graphic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            graphic.GetComponent<IEnemy>().EnemyDeath();
        }
    }
}
