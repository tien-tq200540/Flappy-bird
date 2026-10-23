using UnityEngine;

public class ScoreUICtrl : ScoreConvertToSprites
{
    private static ScoreUICtrl instance;
    public static ScoreUICtrl Instance => instance;

    protected override void Awake()
    {
        if (instance != null) Debug.LogError("Only 1 ScoreUICtrl allows to exists!");
        else instance = this;
        base.Awake();
    }
}
