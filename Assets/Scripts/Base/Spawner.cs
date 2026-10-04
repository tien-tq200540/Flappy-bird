using System.Collections.Generic;
using UnityEngine;

public class Spawner : TienMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs = new();
    [SerializeField] protected List<Transform> poolObjs = new();
    [SerializeField] protected Transform holder;

    protected override void LoadComponents()
    {
        LoadHolder();
    }

    public virtual Transform Spawn(string prefabName, Vector2 position)
    {
        Transform prefab = GetPrefabByName(prefabName);
        if (prefab != null) Spawn(prefab, position);
        return null;
    }

    protected virtual Transform Spawn(Transform prefab, Vector2 position)
    {
        Transform spawnObj = GetObjFromPool(prefab);
        if (spawnObj == null)
        {
            spawnObj = Instantiate(prefab);
            spawnObj.name = prefab.name;
        }
        spawnObj.SetPositionAndRotation(position, Quaternion.identity);
        spawnObj.SetParent(holder);
        spawnObj.gameObject.SetActive(true);
        return spawnObj;
    }

    protected virtual Transform GetObjFromPool(Transform prefab)
    {
        foreach (Transform child in poolObjs)
        {
            if (child.name.Equals(prefab.name))
            {
                poolObjs.Remove(child);
                return child;
            }
        }
        return null;
    }

    protected virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform child in prefabs)
        {
            if (child.name.Equals(prefabName)) return child;
        }
        return null;
    }

    public virtual void Despawn(Transform obj)
    {
        poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }

    protected virtual void LoadHolder()
    {
        if (holder != null) return;
        holder = transform.Find("Holder");
        Debug.Log($"{transform.name}: LoadHolder", this);
    }
}
