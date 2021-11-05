using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonBehaviour<UIManager>, IUIManager
{
    [SerializeField] private Text interactUI;
    [SerializeField] private GameObject starPortalLvl1;
    [SerializeField] private GameObject starPortalLvl2;
    [SerializeField] private GameObject starPortalLvl3;

    public void ChangeVisibilityInteractUI(bool visibility)
    {
        interactUI.enabled = visibility;
    }

    public void ChangeText(int missingStars){
        if(missingStars > 0){
            interactUI.text = missingStars + " needed to enter the dungeon !"; 
        }else{
            interactUI.text = "Press E to interact"; 
        }
    
    }

    public void EnableUIStarPortalLvl1(bool visibility)
    {
        starPortalLvl1.SetActive(visibility);
    }

    public void EnableUIStarPortalLvl2(bool visibility)
    {
        starPortalLvl2.SetActive(visibility);
    }
    public void EnableUIStarPortalLvl3(bool visibility)
    {
        starPortalLvl3.SetActive(visibility);
    }
}
