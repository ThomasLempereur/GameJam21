using UnityEngine;

public class HealUp : MonoBehaviour
{
    [SerializeField] private HealthManagerProxy proxy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();

            if (player.GetActualHealth() != proxy.GetMaximumHearth())
            {
                player.HealPlayer();
                Destroy(gameObject);
            }
        }
    }
}
