using UnityEngine;
using UnityEngine.UI;

public class GameOverUICtrl : TienMonoBehaviour
{
    [SerializeField] protected GameObject background;
    [SerializeField] protected GameObject tittle;
    [SerializeField] protected Button restartButton;
    [SerializeField] protected Button homeButton;

    private static GameOverUICtrl instance;
    public static GameOverUICtrl Instance => instance;

    protected override void Awake()
    {
        if (instance != null) Debug.LogError("Only 1 GameOverUICtrl allows to exist!");
        else instance = this;
        base.Awake();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBackGround();
        LoadTittle();
        LoadRestartButton();
        LoadHomeButton();
        SetGameOverUIState(false);
    }

    public virtual void SetGameOverUIState(bool state)
    {
        if (background != null) background.SetActive(state);
        if (tittle  != null) tittle.SetActive(state);
        if (restartButton != null) restartButton.gameObject.SetActive(state);
        if (homeButton != null) homeButton.gameObject.SetActive(state);
    }

    protected virtual void LoadBackGround()
    {
        if (background != null) return;
        background = transform.Find("Background").gameObject;
        Debug.Log($"{transform.name}: LoadBackGround", this);
    }

    protected virtual void LoadTittle()
    {
        if (tittle != null) return;
        tittle = transform.Find("Title").gameObject;
        Debug.Log($"{transform.name}: LoadTittle", this);
    }

    protected virtual void LoadHomeButton()
    {
        if (homeButton != null) return;
        homeButton = transform.Find("HomeButton").GetComponent<Button>();
        Debug.Log($"{transform.name}: LoadHomeButton", this);
    }

    protected virtual void LoadRestartButton()
    {
        if (restartButton != null) return;
        restartButton = transform.Find("RestartButton").GetComponent<Button>();
        Debug.Log($"{transform.name}: LoadRestartButton", this);
    }

    private void OnEnable()
    {
        restartButton.onClick.AddListener(OnRestartButtonClick);
        homeButton.onClick.AddListener(OnHomeButtonClick);
    }

    private void OnDisable()
    {
        restartButton.onClick.RemoveListener(OnRestartButtonClick);
        homeButton.onClick.RemoveListener(OnHomeButtonClick);
    }

    protected virtual void OnRestartButtonClick()
    {
        GameManager.Instance.RestartGame();
    }

    protected virtual void OnHomeButtonClick()
    {
        GameManager.Instance.BackToHome();
    }
}
