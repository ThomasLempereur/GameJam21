using UnityEngine;

public class EnemyArea : MonoBehaviour
{

    [SerializeField] private PlayerDeathCountArea playerDeathCountArea;

    public void incrementCountDeathArea()
    {
        playerDeathCountArea.incrementCountDeathArea();
    }

    public void SetPlayerDeathCountArea(PlayerDeathCountArea _playerDeathCountArea)
    {
        playerDeathCountArea = _playerDeathCountArea;
    }
}
