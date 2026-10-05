using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollide : TienMonoBehaviour
{

    private void OnEnable()
    {
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PipeCollider pipeCollider))
        {
            transform.parent.gameObject.SetActive(false);
            Time.timeScale = 0f;
        } else if (collision.TryGetComponent(out PipeScoreZone pipeScoreZone))
        {
            ScoreManager.Instance.AddScore(pipeScoreZone.Score);
        }
    }
}
