using UnityEngine;

public class PipeSpawner : Spawner
{
    private static PipeSpawner instance;
    public static PipeSpawner Instance => instance;

    protected override void Awake()
    {
        if (instance != null) Debug.LogError("Only 1 PipeSpawner allows to exist!");
        else instance = this;
        base.Awake();
    }

    [SerializeField] protected float xPos = 10f;
    [SerializeField] protected float minY = -3f;
    [SerializeField] protected float maxY = 3f;
    [SerializeField] protected float spawnTime = 1f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPipe), spawnTime, spawnTime);
    }

    public virtual void SpawnPipe()
    {
        this.Spawn("Pipe", new Vector3(xPos, Random.Range(minY, maxY), 0f));
    }
}
