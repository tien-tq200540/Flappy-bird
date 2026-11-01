using System;
using UnityEngine;

public class BirdShieldUICtrl : TienMonoBehaviour
{
    [SerializeField] protected SpriteRenderer shieldRenderer;

    protected override void LoadComponents()
    {
        LoadShieldRenderer();
    }

    protected virtual void LoadShieldRenderer()
    {
        if (shieldRenderer != null) return;
        shieldRenderer = GetComponent<SpriteRenderer>();
        shieldRenderer.enabled = false;
        Debug.Log($"{transform.name}: LoadShieldRenderer", this);
    }

    private void OnEnable()
    {
        EventManager.OnPlayerGetShieldCompletely += OnPlayerGetShieldCompletely;
        EventManager.OnPlayerLoseShield += OnPlayerLoseShield;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerGetShieldCompletely -= OnPlayerGetShieldCompletely;
        EventManager.OnPlayerLoseShield -= OnPlayerLoseShield;
    }

    //FOR TESTING

    private void Start()
    {
        Invoke(nameof(this.ShieldTesting1), 5f);
        Invoke(nameof(this.ShieldTesting2), 10f);
    }

    private void ShieldTesting1()
    {
        EventManager.TriggerPlayerGetShield(this, EventArgs.Empty);
        Debug.Log("Shield getting");
    }

    private void ShieldTesting2()
    {
        EventManager.TriggerPlayerLoseShield(this, EventArgs.Empty);
        Debug.Log("Shield losing");
    }

    //FOR TESTING

    protected virtual void OnPlayerGetShieldCompletely(object sender, EventArgs e)
    {
        shieldRenderer.enabled = true;
    }

    protected virtual void OnPlayerLoseShield(object sender, EventArgs e)
    {
        shieldRenderer.enabled = false;
    }
}
