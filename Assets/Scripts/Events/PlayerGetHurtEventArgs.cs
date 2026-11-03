public class PlayerGetHurtEventArgs
{
    public int Damage { get; private set; }

    public PlayerGetHurtEventArgs(int damage)
    {
        Damage = damage;
    }
}