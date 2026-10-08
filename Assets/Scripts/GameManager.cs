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
        SceneManager.LoadScene("Home");
    }

    public virtual void RestartGame()
    {
        ResumeGame();
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

    public virtual void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
