public class HighScoreInGameOverUICtrl : ScoreConvertToSprites
{
    private void OnEnable()
    {
        UpdateScoreUI(SaveSystemUtilities.LoadHighScore());
    }
}
