using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float animationTime;
    [SerializeField] private int damageActif;
    private bool _inRange;

    // Update is called once per frame
    void Update()
    {
        if (_inRange)
        {
            StartCoroutine(WaitEndOfAttackAnimation());
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void setRange(bool inRange)
    {
        _inRange = inRange;
    }

    private void Attack()
    {
        animator.SetBool("isAttacking", true);

        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);

        hit.GetComponent<PlayerHealth>().TakeDamage(damageActif);
    }

    private IEnumerator WaitEndOfAttackAnimation()
    {
        while (_inRange)
        {
            Attack();
            yield return new WaitForSeconds(animationTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
