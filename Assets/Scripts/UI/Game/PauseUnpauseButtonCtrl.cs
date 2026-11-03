using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseUnpauseButtonCtrl : TienMonoBehaviour
{
    private static PauseUnpauseButtonCtrl instance;
    public static PauseUnpauseButtonCtrl Instance => instance;

    [SerializeField] protected Button pauseUnpauseButton;
    [SerializeField] protected Sprite pauseButtonIcon;
    [SerializeField] protected Sprite unpauseButtonIcon;

    protected override void Awake()
    {
        if (instance != null) Debug.LogError("Only 1 PauseUnpauseButtonCtrl allows to exist!");
        else instance = this;
        base.Awake();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPauseButtonIcon();
        LoadUnpauseButtonIcon();
        LoadPauseButton();
        gameObject.SetActive(true);
    }

    protected virtual void LoadUnpauseButtonIcon()
    {
        if (unpauseButtonIcon != null) return;
        unpauseButtonIcon = Resources.Load<Sprite>("Button/Unpause");
        Debug.Log($"{transform.name}: LoadUnpauseButtonIcon", this);
    }

    protected virtual void LoadPauseButtonIcon()
    {
        if (pauseButtonIcon != null) return;
        pauseButtonIcon = Resources.Load<Sprite>("Button/Pause");
        Debug.Log($"{transform.name}: LoadPauseButtonIcon", this);
    }

    protected virtual void LoadPauseButton()
    {
        if (pauseUnpauseButton != null) return;
        pauseUnpauseButton = GetComponent<Button>();
        Debug.Log($"{transform.name}: LoadPauseButton", this);
    }

    private void OnEnable()
    {
        pauseUnpauseButton.onClick.AddListener(PauseUnpauseOnClickListener);
    }

    private void Start()
    {
        pauseUnpauseButton.image.sprite = pauseButtonIcon;
    }

    private void OnDisable()
    {
        pauseUnpauseButton.onClick.RemoveAllListeners();
    }

    protected virtual void PauseUnpauseOnClickListener()
    {
        GameManager.Instance.TogglePause();
        if (Time.timeScale == 0f) pauseUnpauseButton.image.sprite = unpauseButtonIcon;
        else pauseUnpauseButton.image.sprite = pauseButtonIcon;
    }
}
