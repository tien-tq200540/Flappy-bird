using UnityEngine;
using UnityEngine.UI;

public class GameOverUICtrl : TienMonoBehaviour
{
    [SerializeField] protected GameObject background;
    [SerializeField] protected GameObject tittle;
    [SerializeField] protected Button okToRestartButton;
    [SerializeField] protected Button menuButton;
    [SerializeField] protected GameObject scoreInGameOverUI;

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
        LoadBackGround();
        LoadTittle();
        LoadOkToRestartButton();
        LoadMenuButton();
        LoadScoreInGameOverUI();
        SetGameOverUIState(false);
    }

    public virtual void SetGameOverUIState(bool state)
    {
        if (background != null) background.SetActive(state);
        if (tittle  != null) tittle.SetActive(state);
        if (okToRestartButton != null) okToRestartButton.gameObject.SetActive(state);
        if (menuButton != null) menuButton.gameObject.SetActive(state);
        if (scoreInGameOverUI != null) scoreInGameOverUI.SetActive(state);
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

    protected virtual void LoadOkToRestartButton()
    {
        if (okToRestartButton != null) return;
        okToRestartButton = transform.Find("OkToRestartButton").GetComponent<Button>();
        Debug.Log($"{transform.name}: LoadOkToRestartButton", this);
    }

    protected virtual void LoadMenuButton()
    {
        if (menuButton != null) return;
        menuButton = transform.Find("MenuButton").GetComponent<Button>();
        Debug.Log($"{transform.name}: LoadMenuButton", this);
    }

    protected virtual void LoadScoreInGameOverUI()
    {
        if (scoreInGameOverUI != null) return;
        scoreInGameOverUI = transform.Find("ScoreInGameOverUI").gameObject;
        Debug.Log($"{transform.name}: LoadScoreInGameOverUI", this);
    }

    private void OnEnable()
    {
        okToRestartButton.onClick.AddListener(OnOkToRestartButtonClick);
        menuButton.onClick.AddListener(OnMenuButtonClick);
    }

    private void OnDisable()
    {
        okToRestartButton.onClick.RemoveAllListeners();
        menuButton.onClick.RemoveAllListeners();
    }

    protected virtual void OnOkToRestartButtonClick()
    {
        GameManager.Instance.RestartGame();
    }

    protected virtual void OnMenuButtonClick()
    {
        GameManager.Instance.BackToMenu();
    }
}
