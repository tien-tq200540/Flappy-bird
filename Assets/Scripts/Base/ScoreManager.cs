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

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDefaultValue();
    }

    public virtual void AddScore(int addScore)
    {
        if (curScore >= maxScore) return;

        curScore += addScore;
        if (curScore > maxScore) curScore = maxScore;
        if (curScore > highScore) highScore = curScore;

        ScoreUICtrl.Instance.UpdateScoreUI(curScore);
    }

    private void AddTestScore()
    {
        AddScore(1);
    }

    protected virtual void LoadDefaultValue()
    {
        curScore = 96;
        highScore = 0;
        maxScore = 9999;
        AddScore(0);
        InvokeRepeating(nameof(AddTestScore), 2f, 2f);
    }
}
