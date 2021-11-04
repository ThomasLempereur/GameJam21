using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>, IGameManager
{

    [SerializeField] private String scene;
    [SerializeField] private UnityEvent OnEndGame;
    [SerializeField] private UnityEvent OnStartgame;

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        StartCoroutine(SwitchScene(scene, () => OnStartgame?.Invoke()));
    }

    private IEnumerator SwitchScene(String newScene, Action callback = null)
    {
        if (SceneManager.sceneCount > 1)
        {
            var currentScene = SceneManager.GetActiveScene().name;
            yield return SceneManager.UnloadSceneAsync(currentScene);
        }
        yield return SceneManager.LoadSceneAsync(newScene, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(newScene));

        callback?.Invoke();
    }

    private void Start()
    {
        StartGame();
    }

    public void EndGame()
    {
        OnEndGame?.Invoke();
    }

}
