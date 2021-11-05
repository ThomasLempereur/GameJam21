using System.Collections;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    PlayerHealth currentPlayer;

    void Update()
    {
        StartCoroutine(Damage());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentPlayer = collision.GetComponent<PlayerHealth>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentPlayer = null;
        }
    }

    public IEnumerator Damage()
    {
        while (currentPlayer != null)
        {
            int health = currentPlayer.GetActualHealth();
            currentPlayer.TakeDamage(health);
            yield return new WaitForSeconds(1.5f);
        }
    }
}
