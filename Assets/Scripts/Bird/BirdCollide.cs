using System;
using UnityEngine;

public class BirdCollide : TienMonoBehaviour
{
    [SerializeField] protected bool isImmortal = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PipeCollider pipeCollider))
        {
            if (isImmortal) return;
            EventManager.TriggerPlayerDeath(this, EventArgs.Empty);
            transform.parent.gameObject.SetActive(false);
            MusicManager.Instance.PlayAudioClip(AudioClipName.Die);
        } else if (collision.TryGetComponent(out PipeScoreZone pipeScoreZone))
        {
            EventManager.TriggerPlayerGetScore(this, new PlayerGetScoreEventArgs(pipeScoreZone.Score));
            MusicManager.Instance.PlayAudioClip(AudioClipName.Point);
        }
    }
}
