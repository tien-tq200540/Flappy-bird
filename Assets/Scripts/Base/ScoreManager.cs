using UnityEngine;

public class ScoreManager : TienMonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance => instance;

    [SerializeField] protected int curScore;
    [SerializeField] protected int highScore;
    [SerializeField] protected int maxScore;

    protected override void Awake()
    {
        if (instance != null) Debug.LogError("Only 1 ScoreManager allows to exists!");
        else instance = this;
        base.Awake();
    }

    private void OnEnable()
    {
        LoadDefaultValue();
    }

    public virtual void AddScore(int addScore)
    {
        if (curScore >= maxScore) return;

        curScore += addScore;
        if (curScore > maxScore) curScore = maxScore;
        if (curScore > highScore)
        {
            highScore = curScore;
            SaveSystemUtilities.SaveHighScore(highScore);
        }

        ScoreUICtrl.Instance.UpdateScoreUI(curScore);
    }

    protected virtual void LoadDefaultValue()
    {
        curScore = 0;
        highScore = SaveSystemUtilities.LoadHighScore();
        maxScore = 9999;
        AddScore(0);
    }
}
