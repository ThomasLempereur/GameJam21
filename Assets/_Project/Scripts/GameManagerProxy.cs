using UnityEngine;

public class GameManagerProxy : MonoBehaviour, IGameManager
{
    public void Quit()
    {
        GameManager.instance.Quit();
    }

    public void StartGame(string _scene)
    {
        GameManager.instance.StartGame(_scene);
    }

    public void EndGame()
    {
        GameManager.instance.EndGame();
    }
}
