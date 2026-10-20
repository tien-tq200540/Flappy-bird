public class HighScoreMenuCtrl : ScoreConvertToSprites
{
    private void OnEnable()
    {
        UpdateScoreUI(SaveSystemUtilities.LoadHighScore());
    }
}
