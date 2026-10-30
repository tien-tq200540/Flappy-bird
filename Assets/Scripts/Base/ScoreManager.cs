using UnityEngine;

public class ScoreManager : TienMonoBehaviour
{
    [SerializeField] protected int curScore;
    [SerializeField] protected int highScore;
    [SerializeField] protected int maxScore;

    private void OnEnable()
    {
        EventManager.OnPlayerGetScore += AddScore;
        LoadDefaultValue();
    }

    private void OnDisable()
    {
        EventManager.OnPlayerGetScore -= AddScore;
    }

    protected virtual void AddScore(object sender, PlayerGetScoreEventArgs e)
    {
        if (curScore >= maxScore) return;

        curScore += e.Score;
        if (curScore > maxScore) curScore = maxScore;
        if (curScore > highScore)
        {
            highScore = curScore;
            SaveSystemUtilities.SaveHighScore(highScore);
        }

        EventManager.TriggerUpdateScoreUIInGame(this, new UpdateScoreUIInGameEventArgs(curScore));
    }

    protected virtual void LoadDefaultValue()
    {
        curScore = 0;
        highScore = SaveSystemUtilities.LoadHighScore();
        maxScore = 9999;
        EventManager.TriggerUpdateScoreUIInGame(this, new UpdateScoreUIInGameEventArgs(curScore));
    }
}
