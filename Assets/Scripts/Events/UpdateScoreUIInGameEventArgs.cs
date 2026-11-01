public class UpdateScoreUIInGameEventArgs
{
    public int CurScore {get; private set;}

    public UpdateScoreUIInGameEventArgs(int curScore)
    {
        CurScore = curScore;
    }
}