using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStarManager
{
    void SendStars(int scene, int nbrStars);
    int NbrStars();
}
