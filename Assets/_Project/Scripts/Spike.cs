using System.Collections;
using UnityEngine;

public class Spike : MonoBehaviour
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
            currentPlayer.TakeDamage(1);
            yield return new WaitForSeconds(1.5f);
        }
    }
}
