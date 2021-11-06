using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

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
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject healthManager;
    [SerializeField] private UnityEvent OnEndGame;
    private bool upgrade = false;

    private void Update()
    {
        if (starCount == 9)
        {
            OnEndGame?.Invoke();
        }
    }

    public void ChangeVisibilityStarCounter(bool visibility)
    {
        starCountText.enabled = visibility;
    }

    public void Reset()
    {
        starsFromFirstLvl = 0;
        starsFromSecondLvl = 0;
        starsFromThirdLvl = 0;
        upgrade = false;
        NbrStars();
        starPortalLvl1.text = starsFromFirstLvl.ToString() + "/3";
        starPortalLvl2.text = starsFromSecondLvl.ToString() + "/3";
        starPortalLvl2.text = starsFromThirdLvl.ToString() + "/3";
        starCountText.text = starCount.ToString();
    }

    public int NbrStars()
    {
        starCount = starsFromFirstLvl + starsFromSecondLvl + starsFromThirdLvl;
        if (!upgrade && starCount >= 2)
        {
            upgrade = true;
            healthManager.GetComponent<HealthManager>().SetMaximumHearth(4);
        }
        return starCount;
    }

    public void SendStars(int scene, int nbrStars)
    {
        if (scene == 1 && nbrStars > starsFromFirstLvl)
        {
            starsFromFirstLvl = nbrStars;
            starPortalLvl1.text = starsFromFirstLvl.ToString() + "/3";
        }
        else if (scene == 2 && nbrStars > starsFromSecondLvl)
        {
            starsFromSecondLvl = nbrStars;
            starPortalLvl2.text = starsFromSecondLvl.ToString() + "/3";
        }
        else if (scene == 3 && nbrStars > starsFromThirdLvl)
        {
            starsFromThirdLvl = nbrStars;
            starPortalLvl2.text = starsFromThirdLvl.ToString() + "/3";
        }
        NbrStars();
        starCountText.text = starCount.ToString();
    }
}
