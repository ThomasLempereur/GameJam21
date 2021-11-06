using UnityEngine;

public class DiamondManagerProxy : MonoBehaviour, IDiamondManager
{

    public void Reset()
    {
        DiamondManager.instance.Reset();
    }

    public void ChangeVisibilityDiamondsCounter(bool visibility)
    {
        DiamondManager.instance.ChangeVisibilityDiamondsCounter(visibility);
    }

    public void AddDiamond(int count)
    {
        DiamondManager.instance.AddDiamond(count);
    }

    public int GetDiamond()
    {
        return DiamondManager.instance.GetDiamond();
    }

}
