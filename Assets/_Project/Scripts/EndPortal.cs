using UnityEngine;

public class EndPortal : MonoBehaviour
{

    [SerializeField] private StarManagerProxy starManagerProxy;
    [SerializeField] private UIManagerProxy uIManagerProxy;
    [SerializeField] private GameManagerProxy gameManagerProxy;
    [SerializeField] private DiamondManagerProxy diamondManagerProxy; 
    [SerializeField] private HealthManagerProxy healthManagerProxy; 
    [SerializeField] private string sceneLoad;
    [SerializeField] private int currentScene;
    [SerializeField] private int currentPortal;
    [SerializeField] private bool endLvlPortal;

    private int totalStar;

    public void LoadScene()
    {   
        totalStar = starManagerProxy.NbrStars();

        if(currentPortal==2 && totalStar < 1){
            return;
        }
        if(currentPortal==3 && totalStar < 4){
            return;
        }

        if(endLvlPortal){
            int stars = 1;
            if(diamondManagerProxy?.GetDiamond() == 5) stars++;
            if(healthManagerProxy?.GetActualHearth() == healthManagerProxy.GetMaximumHearth()) stars++;
            starManagerProxy.SendStars(currentScene,stars);
        }
        if(currentPortal==1){
            uIManagerProxy.EnableUIStarPortalLvl1(false);
        }else if(currentPortal==2){
            uIManagerProxy.EnableUIStarPortalLvl2(false);
        }else if(currentPortal==3){
            uIManagerProxy.EnableUIStarPortalLvl3(false);
        }
    
        uIManagerProxy.ChangeVisibilityInteractUI(false);
        gameManagerProxy.StartGame(sceneLoad);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        
            totalStar = starManagerProxy.NbrStars();

            if(currentPortal==2 && totalStar < 1){
                uIManagerProxy.ChangeText(1);
            }else if(currentPortal==3 && totalStar < 4){
                uIManagerProxy.ChangeText(4- totalStar);
            }else {
                uIManagerProxy.ChangeText(0);
            }

            uIManagerProxy.ChangeVisibilityInteractUI(true);
            if(currentPortal==1){
                uIManagerProxy.EnableUIStarPortalLvl1(true);
            }else if(currentPortal==2){
                uIManagerProxy.EnableUIStarPortalLvl2(true);
            }else if(currentPortal==3){
                uIManagerProxy.EnableUIStarPortalLvl3(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            uIManagerProxy.ChangeVisibilityInteractUI(false);
            if(currentPortal==1){
                uIManagerProxy.EnableUIStarPortalLvl1(false);
            }else if(currentPortal==2){
                uIManagerProxy.EnableUIStarPortalLvl2(false);
            }else if(currentPortal==3){
                uIManagerProxy.EnableUIStarPortalLvl3(false);
            }
        }
    }

}
