using UnityEngine;
using UnityEngine.UI;

public class MenuUICtrl : TienMonoBehaviour
{
    [SerializeField] protected Button playButton;
    [SerializeField] protected Color pressedColor = Color.yellow;

    protected override void LoadComponents()
    {
        LoadPlayButton();
    }

    private void OnEnable()
    {
        playButton.onClick.AddListener(PlayButtonListener);
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveAllListeners();
    }

    protected virtual void PlayButtonListener()
    {
        GameManager.Instance.PlayGame();
    }

    protected virtual void LoadPlayButton()
    {
        if (playButton != null) return;
        playButton = transform.Find("PlayButton").GetComponent<Button>();
        ColorBlock playButtonColor = playButton.colors;
        playButtonColor.pressedColor = pressedColor;
        playButton.colors = playButtonColor;
        Debug.Log($"{transform.name}: LoadPlayButton", this);
    }
}