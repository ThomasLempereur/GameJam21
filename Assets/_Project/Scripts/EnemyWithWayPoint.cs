using System.Collections;
using UnityEngine;

public class EnemyWithWayPoint : MonoBehaviour, IEnemy
{
    [SerializeField] private GameObject objectDestroyed;
    [SerializeField] private float speed;
    [SerializeField] private PolygonCollider2D enemyCollider2D;
    [SerializeField] private BoxCollider2D hitCollider;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private Animator animator;
    [SerializeField] private int damagePassif;
    private Transform target;
    private int destPoint;
    private Collision2D player;

    // Start is called before the first frame update
    public void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    public void Update()
    {
        if (!animator.GetBool("isDead") && !animator.GetBool("playerDetected"))
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
        if (player != null)
        {
            player.transform.GetComponent<PlayerHealth>().TakeDamage(damagePassif);
        }
    }

    public void SetWayPoints(Transform[] _waypoints)
    {
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i].position = _waypoints[i].position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            player = collision;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            player = null;
        }
    }

    public void EnemyDeath()
    {
        animator.SetBool("isDead", true);
        objectDestroyed.GetComponentInChildren<EnemyArea>()?.incrementCountDeathArea();
        Destroy(enemyCollider2D);
        Destroy(hitCollider);
        StartCoroutine(WaitAndDestroy());
    }

    public IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(objectDestroyed);
    }
}
