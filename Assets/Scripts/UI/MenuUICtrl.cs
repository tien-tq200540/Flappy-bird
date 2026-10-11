using UnityEngine;
using UnityEngine.UI;

public class MenuUICtrl : TienMonoBehaviour
{
    [SerializeField] protected Button playButton;
    [SerializeField] protected Button highScoreButton;
    protected Color pressedColor = Color.yellow;
    protected Color selectedColor = Color.yellow;

    protected override void LoadComponents()
    {
        LoadPlayButton();
        LoadHighScoreButton();
    }

    private void OnEnable()
    {
        playButton.onClick.AddListener(PlayButtonListener);
        highScoreButton.onClick.AddListener(HighScoreButtonListener);
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveAllListeners();
        highScoreButton.onClick.RemoveAllListeners();
    }

    protected virtual void PlayButtonListener()
    {
        GameManager.Instance.PlayGame();
    }

    protected virtual void HighScoreButtonListener()
    {

    }

    protected virtual void LoadPlayButton()
    {
        if (playButton != null) return;
        playButton = transform.Find("PlayButton").GetComponent<Button>();
        ColorBlock playButtonColor = playButton.colors;
        playButtonColor.pressedColor = pressedColor;
        playButtonColor.selectedColor = selectedColor;
        playButton.colors = playButtonColor;
        Debug.Log($"{transform.name}: LoadPlayButton", this);
    }

    protected virtual void LoadHighScoreButton()
    {
        if (highScoreButton != null) return;
        highScoreButton = transform.Find("HighscoreButton").GetComponent<Button>();
        ColorBlock highScoreColor = highScoreButton.colors;
        highScoreColor.pressedColor = pressedColor;
        highScoreColor.selectedColor = selectedColor;
        highScoreButton.colors = highScoreColor;
        Debug.Log($"{transform.name}: LoadHighScoreButton", this);
    }
}
