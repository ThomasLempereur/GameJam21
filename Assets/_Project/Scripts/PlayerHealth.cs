using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private SpriteRenderer graphics;
    [SerializeField] private Animator animator;
    [SerializeField] private bool isTouched;
    [SerializeField] private float isTouchedDelay;
    [SerializeField] private GameObject objectDestroyed;
    [SerializeField] private UnityEvent onDeath;
    [SerializeField] private HealthManagerProxy healthProxy;
    [SerializeField] private Rigidbody2D rb;

    private int actualHealth;

    // Start is called before the first frame update
    void Start()
    {
        if (healthProxy)
        {
            healthProxy.Reset();
            actualHealth = healthProxy.GetActualHearth();
        }
        isTouched = false;
    }

    public void TakeDamage(int numberLostHearts)
    {
        if (isTouched)
        {
            return;
        }

        isTouched = true;

        actualHealth = healthProxy.DecreaseUp(numberLostHearts);

        if (actualHealth <= 0)
        {
            animator.SetBool("isDead", true);
            Vector2 v = rb.velocity;
            v.x = 0;
            rb.velocity = v;
            StartCoroutine(WaitAndDestroy());
        }
        else
        {
            StartCoroutine(invincibility());
            StartCoroutine(handleInvincibilityDelay());
        }

    }

    public void HealPlayer()
    {
        actualHealth = healthProxy.IncreaseUp();
    }

    public IEnumerator invincibility()
    {
        while (isTouched)
        {
            graphics.color = new Color(1f, 1f, 1f, 0.3f);

            yield return new WaitForSeconds(isTouchedDelay);

            graphics.color = new Color(1f, 1f, 1f, 1f);

            yield return new WaitForSeconds(isTouchedDelay);
        }
    }

    public IEnumerator handleInvincibilityDelay()
    {
        yield return new WaitForSeconds(1.5f);
        isTouched = false;
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(2);
        onDeath?.Invoke();
        Destroy(objectDestroyed);
    }

    public int GetActualHealth()
    {
        return actualHealth;
    }
}
