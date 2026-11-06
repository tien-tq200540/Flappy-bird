public class CurScoreInGameOverUICtrl : ScoreConvertToSprites
{
    private void OnEnable()
    {
        UpdateScoreUI(ScoreManager.Instance.CurScore);
    }
}
