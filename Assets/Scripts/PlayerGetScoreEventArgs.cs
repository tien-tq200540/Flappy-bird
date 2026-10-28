using System;

public class PlayerGetScoreEventArgs : EventArgs
{
    public int Score { get; private set; }

    public PlayerGetScoreEventArgs (int score)
    {
        Score = score;
    }
}