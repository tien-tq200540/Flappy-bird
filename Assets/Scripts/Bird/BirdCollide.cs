using System;
using UnityEngine;

public class BirdCollide : TienMonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PipeCollider pipeCollider))
        {
            EventManager.TriggerPlayerGetHurt(this, EventArgs.Empty);
        } else if (collision.TryGetComponent(out Shield shield))
        {
            EventManager.TriggerPlayerGetShield(this, EventArgs.Empty);
        }
        else if (collision.TryGetComponent(out PipeScoreZone pipeScoreZone))
        {
            EventManager.TriggerPlayerGetScore(this, new PlayerGetScoreEventArgs(pipeScoreZone.Score));
            MusicManager.Instance.PlayAudioClip(AudioClipName.Point);
        }
    }
}
