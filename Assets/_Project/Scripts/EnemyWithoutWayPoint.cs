using System.Collections;
using UnityEngine;
public class EnemyWithoutWayPoint : MonoBehaviour, IEnemy
{

    [SerializeField] private GameObject objectDestroyed;
    [SerializeField] private float speed;
    [SerializeField] private PolygonCollider2D enemyCollider2D;
    [SerializeField] private BoxCollider2D hitCollider;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform target;
    [SerializeField] private int damagePassif;
    [SerializeField] private SpriteRenderer spriteRendererEnemy;
    private Collision2D player;

    bool pass;

    // Start is called before the first frame update
    public void Start()
    {
    }

    // Update is called once per frame
    public void Update()
    {
        if (target)
        {
            Vector3 dir = target.position - transform.position;
            Vector3 reverseScale = transform.localScale;
            if (dir.x > 0.1f && !pass)
            {
                reverseScale.x *= -1;
                pass = true;
            }
            else if (dir.x < 0.1f && pass)
            {
                reverseScale.x *= -1;
                pass = false;
            }
            transform.localScale = reverseScale;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }
        if (player != null)
        {
            player.transform.GetComponent<PlayerHealth>()?.TakeDamage(damagePassif);
        }
    }

    public void SetTraget(GameObject _target)
    {
        target = _target?.transform;
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
