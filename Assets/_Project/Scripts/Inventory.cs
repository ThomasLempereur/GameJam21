using UnityEngine;
public class Inventory : MonoBehaviour
{

    [SerializeField] private DiamondManagerProxy proxy;

    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }

    public void AddDiamond(int count)
    {
        proxy.AddDiamond(count);
    }

}
