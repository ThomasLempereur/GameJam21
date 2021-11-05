using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float attackDelay;
    [SerializeField] private int damageActif;
    private bool _inRange;
    private bool canAttack;

    private void Start()
    {
        canAttack = true;
    }
    void Update()
    {
        Debug.Log("RANGE " + _inRange);
        Debug.Log("ATTACK " + canAttack);
        if (_inRange && canAttack)
        {
            animator.SetBool("isAttacking", true);
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

    public void ThrowAttack()
    {
        StartCoroutine(AttackDelay());
    }

    private IEnumerator AttackDelay()
    {
        canAttack = false;
        Attack();
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }

    private void Attack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);
        hit?.GetComponent<PlayerHealth>().TakeDamage(damageActif);
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
