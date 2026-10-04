using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDespawn : DespawnByTime
{
    protected override void DespawnObj()
    {
        PipeSpawner.Instance.Despawn(transform.parent);
    }
}
