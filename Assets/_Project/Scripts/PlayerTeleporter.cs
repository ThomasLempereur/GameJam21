
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{

    private GameObject currentTeleporter;


    // Update is called once per frame
    void Update()
    {
        if (currentTeleporter != null && Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter.GetComponent<Teleporter>())
            {
                transform.position = currentTeleporter.GetComponent<Teleporter>().GoToDestination().position;
            }
            else
            {
                currentTeleporter.GetComponent<EndPortal>().LoadScene();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter") || collision.CompareTag("LoadingPortal"))
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter") || collision.CompareTag("LoadingPortal"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
