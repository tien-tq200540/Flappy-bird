using UnityEngine;

public class BirdCollide : TienMonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PipeCollider pipeCollider))
        {
            transform.parent.gameObject.SetActive(false);
            GameManager.Instance.GameOver();
        } else if (collision.TryGetComponent(out PipeScoreZone pipeScoreZone))
        {
            ScoreManager.Instance.AddScore(pipeScoreZone.Score);
        }
    }
}
