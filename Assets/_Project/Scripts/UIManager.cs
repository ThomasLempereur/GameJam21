using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonBehaviour<UIManager>, IUIManager
{
    [SerializeField] private Text interactUI;
    public void ChangeVisibilityInteractUI(bool visibility)
    {
        interactUI.enabled = visibility;
    }
}
