using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : SingletonBehaviour<StarManager>, IStarManager
{

    [SerializeField] private Text starCountText; 
    [SerializeField] private Text starPortalLvl1;
    [SerializeField] private Text starPortalLvl2;
    [SerializeField] private Text starPortalLvl3;
    [SerializeField] private int starCount; 
    [SerializeField] private int starsFromFirstLvl = 0;
    [SerializeField] private int starsFromSecondLvl = 0; 
    [SerializeField] private int starsFromThirdLvl = 0;
    
    public void ChangeVisibilityStarCounter(bool visibility)
    {
        starCountText.enabled = visibility;
    }

    public int NbrStars() {
        starCount = starsFromFirstLvl + starsFromSecondLvl + starsFromThirdLvl;
        return starCount;
    }

    public void SendStars(int scene, int nbrStars){
        if(scene == 1 && nbrStars > starsFromFirstLvl){
            starsFromFirstLvl = nbrStars;
            starPortalLvl1.text = starsFromFirstLvl.ToString() + "/3";
        }
        else if(scene == 2 && nbrStars > starsFromSecondLvl){
            starsFromSecondLvl = nbrStars;
            starPortalLvl2.text = starsFromSecondLvl.ToString() + "/3";
        }
        else if(scene == 3 && nbrStars > starsFromThirdLvl){
            starsFromThirdLvl = nbrStars;
            starPortalLvl2.text = starsFromThirdLvl.ToString() + "/3";
        }
        NbrStars();
        starCountText.text = starCount.ToString();
    }
}
