using UnityEngine;
using UnityEngine.UI;

public class PauseButtonCtrl : TienMonoBehaviour
{
    [SerializeField] protected Button pauseUnpauseButton;
    [SerializeField] protected Sprite pauseButtonIcon;
    [SerializeField] protected Sprite unpauseButtonIcon;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPauseButton();
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
