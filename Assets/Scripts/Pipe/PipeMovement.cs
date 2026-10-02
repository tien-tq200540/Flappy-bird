using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : TienMonoBehaviour
{
    [SerializeField] protected float speed = 5f;

    private void Update()
    {
        Moving();
    }

    protected virtual void Moving()
    {
        transform.parent.Translate(speed * Vector2.left * Time.deltaTime);
    }
}
