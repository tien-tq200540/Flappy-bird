public class ScoreUICtrl : ScoreConvertToSprites
{
    private void OnEnable()
    {
        EventManager.OnUpdateScoreUIInGame += OnUpdateScoreUIInGame;
    }

    private void OnDisable()
    {
        EventManager.OnUpdateScoreUIInGame -= OnUpdateScoreUIInGame;
    }

    protected virtual void OnUpdateScoreUIInGame(object sender, UpdateScoreUIInGameEventArgs e)
    {
        UpdateScoreUI(e.CurScore);   
    }
}
