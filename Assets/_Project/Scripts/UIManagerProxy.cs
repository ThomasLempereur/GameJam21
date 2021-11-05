using UnityEngine;

public class UIManagerProxy : MonoBehaviour, IUIManager
{
    public void ChangeVisibilityInteractUI(bool visibility)
    {
        UIManager.instance.ChangeVisibilityInteractUI(visibility);
    }
}
