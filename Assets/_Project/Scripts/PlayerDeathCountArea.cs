using UnityEngine;

public class PlayerDeathCountArea : MonoBehaviour
{

    [SerializeField] private int numberEnemy;
    [SerializeField] private GameObject wall;
    private int countDeathArea;

    void Start()
    {
        countDeathArea = 0;
    }

    private void Update()
    {
        if (countDeathArea == numberEnemy)
        {
            wall.SetActive(false);
        }
    }

    public void incrementCountDeathArea()
    {
        countDeathArea++;
    }
}
