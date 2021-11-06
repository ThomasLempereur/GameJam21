using UnityEngine;

public class Papyrus : MonoBehaviour
{

    [SerializeField] private UIManagerProxy uIManagerProxy;
    [SerializeField] private string papyrus;
    [SerializeField] private Color color; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            uIManagerProxy.ChangeVisibilityPapyrus(true, papyrus, color); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            uIManagerProxy.ChangeVisibilityPapyrus(false, papyrus, color);
        }
    }

}
