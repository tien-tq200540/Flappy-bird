using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : TienMonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    protected override void Awake()
    {
        if (instance != null) Debug.LogError("Only 1 GameManager allows to exist!");
        else instance = this; 
        base.Awake();
    }

    public virtual void BackToHome()
    {
        Debug.Log("Back To Home");
    }

    public virtual void RestartGame()
    {
        UnpauseGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public virtual void GameOver()
    {
        PauseGame();
        GameOverUICtrl.Instance.SetGameOverUIState(true);
    }

    public virtual void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public virtual void UnpauseGame()
    {
        Time.timeScale = 1f;
    }

    public virtual void Play()
    {

    }
}
