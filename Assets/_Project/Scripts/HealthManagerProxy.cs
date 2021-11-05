using UnityEngine;

public class HealthManagerProxy : MonoBehaviour, IHealthManager
{

    public void Reset()
    {
        HealthManager.instance.Reset();
    }

    public int IncreaseUp()
    {
        return HealthManager.instance.IncreaseUp();
    }

    public int DecreaseUp(int numberLostHearts)
    {
        return HealthManager.instance.DecreaseUp(numberLostHearts);
    }

    public int GetActualHearth()
    {
        return HealthManager.instance.GetActualHearth();
    }
}
