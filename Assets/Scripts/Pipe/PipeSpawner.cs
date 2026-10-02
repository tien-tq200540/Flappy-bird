using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : TienMonoBehaviour
{
    [SerializeField] protected Transform prefab;
    protected float xPos = 10f;
    protected float minY = -3f;
    protected float maxY = 3f;
    protected float spawnTime = 1f;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnTime, spawnTime);
    }
    
    protected virtual void Spawn()
    {
        Instantiate(prefab);
        prefab.SetPositionAndRotation(new Vector3(xPos, Random.Range(minY, maxY), 0f), Quaternion.identity);
    }
}
