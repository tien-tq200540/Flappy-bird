using UnityEngine;

public class DespawnByTime : Despawner
{
    [SerializeField] protected float timeLimit = 5f;
    [SerializeField] protected float timeElapsed = 0f;

    private void OnEnable()
    {
        timeElapsed = 0f;
    }

    protected override bool CanDespawn()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeLimit) return true;
        return false;
    }
}
