using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDiamondManager 
{

    void Reset();

    void ChangeVisibilityDiamondsCounter(bool visibility);

    void AddDiamond(int count);

    int GetDiamond(); 

}
