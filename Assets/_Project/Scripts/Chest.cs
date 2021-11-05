using UnityEngine;
using Random = UnityEngine.Random;

public class Chest : MonoBehaviour
{
    [SerializeField] private Animator animatorChest;
    [SerializeField] private UIManagerProxy uIManagerProxy;

    private PlayerHealth player;

    private bool isInRange;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            OpenChest();
        }
    }

    private void OpenChest()
    {
        if (animatorChest.GetBool("open") == false)
        {
            Reward();
            animatorChest.SetBool("open", true);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void Reward()
    {
        int malusOrBonus = Random.Range(0, 2);

        if (malusOrBonus == 1)
        {
            player.TakeDamage(1);
        }
        else
        {
            player.HealPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            uIManagerProxy.ChangeVisibilityInteractUI(true);
            player = collision.GetComponent<PlayerHealth>();
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            uIManagerProxy.ChangeVisibilityInteractUI(false);
            player = null;
            isInRange = false;
        }
    }
}
