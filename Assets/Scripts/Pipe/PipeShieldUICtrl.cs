using System;
using UnityEngine;

public class PipeShieldUICtrl : TienMonoBehaviour
{
    [SerializeField] protected SpriteRenderer pipeShieldSprite;

    protected override void LoadComponents()
    {
        LoadPipeShieldSprite();
    }

    protected virtual void LoadPipeShieldSprite()
    {
        if (pipeShieldSprite != null) return;
        pipeShieldSprite = transform.parent.Find("Model").Find("ShieldSprite").GetComponent<SpriteRenderer>();
        Debug.Log($"{transform.name}: LoadPipeShieldSprite", this);
    }

    private void OnEnable()
    {
        EventManager.OnPlayerGetShieldCompletely += OnPlayerGetShieldCompletely;
        pipeShieldSprite.enabled = true;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerGetShieldCompletely -= OnPlayerGetShieldCompletely;
    }

    protected virtual void OnPlayerGetShieldCompletely(object sender, EventArgs e)
    {
        pipeShieldSprite.enabled = false;
    }
}