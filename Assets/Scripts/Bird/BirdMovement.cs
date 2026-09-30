using UnityEngine;
using UnityEngine.InputSystem;

public class BirdMovement : TienMonoBehaviour
{
    [SerializeField] protected float force = 4f;
    [SerializeField] protected Rigidbody2D birdRigidbody2D;

    protected override void LoadComponents()
    {
        LoadBirdRigidbody2D();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            birdRigidbody2D.velocity = Vector2.zero;
            birdRigidbody2D.AddForce(force * Vector2.up, ForceMode2D.Impulse);
        }
    }

    protected virtual void LoadBirdRigidbody2D()
    {
        if (birdRigidbody2D != null) return;
        birdRigidbody2D = GetComponentInParent<Rigidbody2D>();
        Debug.Log($"{transform.name}: LoadBirdRigidbody2D", this);
    }
}
