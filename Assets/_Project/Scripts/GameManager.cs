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
    [SerializeField] private UnityEvent HideForLobby;
    private String currentScene = null;

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame(String _scene)
    {
        if (_scene != null)
        {
            currentScene = _scene;
            if (_scene == "Lobby")
            {
                StartCoroutine(SwitchScene(_scene, () => HideForLobby?.Invoke()));
            }
            else
            {
                StartCoroutine(SwitchScene(_scene, () => OnStartgame?.Invoke()));
            }
        }
        else
        {
            StartCoroutine(SwitchScene(scene, () => HideForLobby?.Invoke()));
        }
    }

    public void ReloadThisScene()
    {
        StartGame(currentScene);
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
        StartGame(null);
    }

    public void EndGame()
    {
        OnEndGame?.Invoke();
    }

}
