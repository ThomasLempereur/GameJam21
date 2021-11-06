using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private float BigAttackRange;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private StarManagerProxy starManagerProxy;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip soundDamageTaken;
    
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("attack");
        }
        if (starManagerProxy.NbrStars() >= 4 && Input.GetButtonDown("Fire2"))
        {
            animator.SetTrigger("bigAttack");
        }

    }

    private void Attack()
    {
        audioSource.PlayOneShot(soundDamageTaken);
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hit)
        {

            enemy.GetComponent<IEnemy>().EnemyDeath();

        }
    }

    private void BigAttack()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, BigAttackRange, enemyLayer);

        foreach (Collider2D enemy in hit)
        {

            enemy.GetComponent<IEnemy>().EnemyDeath();

        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPoint.position, BigAttackRange);
    }
}
