using UnityEngine;

public class UIManagerProxy : MonoBehaviour, IUIManager
{
    public void ChangeVisibilityInteractUI(bool visibility)
    {
        UIManager.instance.ChangeVisibilityInteractUI(visibility);
    }

    public void EnableUIStarPortalLvl1(bool visibility)
    {
        UIManager.instance.EnableUIStarPortalLvl1(visibility);
    }

    public void EnableUIStarPortalLvl2(bool visibility)
    {
        UIManager.instance.EnableUIStarPortalLvl2(visibility);
    }
    public void EnableUIStarPortalLvl3(bool visibility)
    {
        UIManager.instance.EnableUIStarPortalLvl3(visibility);
    }

    public void ChangeText(int missingStars) {
        UIManager.instance.ChangeText(missingStars); 
    }
}
