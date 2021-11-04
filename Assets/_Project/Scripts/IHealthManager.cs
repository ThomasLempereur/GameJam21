public interface IHealthManager
{
    void Reset();
    int IncreaseUp();
    int DecreaseUp(int numberLostHearts);
}