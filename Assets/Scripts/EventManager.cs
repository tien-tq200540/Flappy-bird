using System;

public static class EventManager
{
    public static event EventHandler OnPlayerDeath;
    public static void TriggerPlayerDeath(object sender, EventArgs e)
    {
        OnPlayerDeath?.Invoke(sender, e);
    }
}
