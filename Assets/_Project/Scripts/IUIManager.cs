using UnityEngine;

public interface IUIManager
{
    void ChangeVisibilityInteractUI(bool visibility);
    void EnableUIStarPortalLvl1(bool visibility);
    void EnableUIStarPortalLvl2(bool visibility);
    void EnableUIStarPortalLvl3(bool visibility);
    void ChangeText(int missingStars);
    void ChangeVisibilityPapyrus(bool visibility, string papyrus, Color color);

}