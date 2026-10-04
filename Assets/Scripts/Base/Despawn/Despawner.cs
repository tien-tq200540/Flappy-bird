public abstract class Despawner : TienMonoBehaviour
{
    protected abstract bool CanDespawn();

    private void Update()
    {
        if (CanDespawn()) DespawnObj();
    }

    protected virtual void DespawnObj()
    {
        Destroy(gameObject);
    }
}
