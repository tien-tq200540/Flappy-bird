public class PlayerModelChangeStateEventArgs
{
    public BirdModelCtrl.BirdModelState State { get; private set; }

    public PlayerModelChangeStateEventArgs(BirdModelCtrl.BirdModelState state)
    {
        State = state;
    }
}