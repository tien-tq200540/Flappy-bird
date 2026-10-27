using System;
using UnityEngine;

public class GameManager : TienMonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    protected static bool isBooting = true;

    protected override void Awake()
    {
        if (instance != null) Debug.LogError("Only 1 GameManager allows to exist!");
        else instance = this;
        DontDestroyOnLoad(this);
        base.Awake();
        if (isBooting)
        {
            SceneLoader.LoadScene(Scene.Menu);
            isBooting = false;
        }
    }

    private void OnEnable()
    {
        EventManager.OnPlayerDeath += GameOver;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerDeath -= GameOver;
    }

    public virtual void BackToHome()
    {
        UnpauseGame();
        PauseUnpauseButtonCtrl.Instance.gameObject.SetActive(true);
        SceneLoader.LoadScene(Scene.Menu);
    }

    public virtual void RestartGame()
    {
        UnpauseGame();
        PauseUnpauseButtonCtrl.Instance.gameObject.SetActive(true);
        SceneLoader.LoadScene(Scene.Game);
    }

    protected virtual void GameOver(object sender, EventArgs eventArgs)
    {
        PauseGame();
        GameOverUICtrl.Instance.SetGameOverUIState(true);
        PauseUnpauseButtonCtrl.Instance.gameObject.SetActive(false);
    }

    public virtual void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public virtual void UnpauseGame()
    {
        Time.timeScale = 1f;
    }

    public virtual void PlayGame()
    {
        SceneLoader.LoadScene(Scene.Game);
    }

    public virtual void LoadHighscore()
    {

    }

    public virtual void TogglePause()
    {
        Time.timeScale = 1f - Time.timeScale;
    }
}
