using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyWithoutWayPoint : MonoBehaviour, IEnemy
{

    [SerializeField] private UnityEvent onDeath;
    [SerializeField] private GameObject objectDestroyed;
    [SerializeField] private float speed;
    [SerializeField] private PolygonCollider2D enemyCollider2D;
    [SerializeField] private BoxCollider2D hitCollider;
    [SerializeField] private Animator animator;

    private Transform target;
    private int destPoint;

    // Start is called before the first frame update
    public void Start()
    {
    }

    // Update is called once per frame
    public void Update()
    {
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }*/

    public void EnemyDeath()
    {
        animator.SetBool("isDead", true);
        Destroy(enemyCollider2D);
        Destroy(hitCollider);
        StartCoroutine(WaitAndDestroy());
    }

    public IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(1);
        onDeath?.Invoke();
        Destroy(objectDestroyed);
    }
}
