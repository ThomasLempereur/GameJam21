using UnityEngine;
using UnityEngine.UI;
public class DiamondManager : SingletonBehaviour<DiamondManager>, IDiamondManager
{

    [SerializeField] private int diamondsCount; 
    [SerializeField] private Text diamondsCountText; 

    public void Reset() {
        diamondsCount = 0; 
        diamondsCountText.text = diamondsCount.ToString(); 
    }

    public void ChangeVisibilityDiamondsCounter(bool visibility)
    {
        diamondsCountText.enabled = visibility;
    }

    public void AddDiamond(int count) {
        diamondsCount += count; 
        diamondsCountText.text = diamondsCount.ToString(); 
    }

    public int GetDiamond() {
        return diamondsCount; 
    }
}
