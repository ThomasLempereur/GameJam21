using UnityEngine;

public class StarManagerProxy : MonoBehaviour, IStarManager
{
    public void SendStars(int scene, int nbrStars)
    {
        StarManager.instance.SendStars(scene, nbrStars);
    }

    public int NbrStars()
    {
        return StarManager.instance.NbrStars();
    }

}
