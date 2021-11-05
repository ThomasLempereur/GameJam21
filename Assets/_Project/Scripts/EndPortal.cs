using UnityEngine;

public class EndPortal : MonoBehaviour
{
    [SerializeField] private UIManagerProxy uIManagerProxy;
    [SerializeField] private GameManagerProxy gameManagerProxy;
    [SerializeField] private string scene;


    public void LoadScene()
    {
        uIManagerProxy.ChangeVisibilityInteractUI(false);
        gameManagerProxy.StartGame(scene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            uIManagerProxy.ChangeVisibilityInteractUI(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            uIManagerProxy.ChangeVisibilityInteractUI(false);
        }
    }

}
