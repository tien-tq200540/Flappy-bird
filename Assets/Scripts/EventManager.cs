using System;

public static class EventManager
{
    public static event EventHandler OnPlayerDeath;
    public static void TriggerPlayerDeath(object sender, EventArgs e)
    {
        OnPlayerDeath?.Invoke(sender, e);
    }

    public static event EventHandler<PlayerGetScoreEventArgs> OnPlayerGetScore;
    public static void TriggerPlayerGetScore(object sender, PlayerGetScoreEventArgs e)
    {
        OnPlayerGetScore?.Invoke(sender, e);
    }
}
