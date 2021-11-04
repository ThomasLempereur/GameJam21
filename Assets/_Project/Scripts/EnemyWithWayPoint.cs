using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyWithWayPoint : MonoBehaviour, IEnemy
{

    [SerializeField] private UnityEvent onDeath;
    [SerializeField] private GameObject objectDestroyed;
    [SerializeField] private float speed;
    [SerializeField] private PolygonCollider2D enemyCollider2D;
    [SerializeField] private BoxCollider2D hitCollider;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private Animator animator;

    private Transform target;
    private int destPoint;

    // Start is called before the first frame update
    public void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    public void Update()
    {
        if (!animator.GetBool("isDead") && !animator.GetBool("isAttacking"))
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            // Si l'ennemie est presque arrivé à destination
            if (Vector3.Distance(transform.position, target.position) < 0.3f)
            {
                Vector3 reverseScale = transform.localScale;
                reverseScale.x *= -1f;
                transform.localScale = reverseScale;

                destPoint = (destPoint + 1) % waypoints.Length;
                target = waypoints[destPoint];
            }
        }
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
    */
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
