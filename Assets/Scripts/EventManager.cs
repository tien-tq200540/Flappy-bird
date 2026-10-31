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

    public static event EventHandler<UpdateScoreUIInGameEventArgs> OnUpdateScoreUIInGame;
    public static void TriggerUpdateScoreUIInGame(object sender, UpdateScoreUIInGameEventArgs e)
    {
        OnUpdateScoreUIInGame?.Invoke(sender, e);
    }

    public static event EventHandler OnPlayerGetHurt;
    public static void TriggerPlayerGetHurt(object sender, EventArgs e)
    {
        OnPlayerGetHurt?.Invoke(sender, e);
    }

    public static event EventHandler OnPlayerGetShield;
    public static void TriggerPlayerGetShield( object sender, EventArgs e)
    {
        OnPlayerGetShield?.Invoke(sender, e);
    }
}
