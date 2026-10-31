using System;
using UnityEngine;

public class BirdLife : TienMonoBehaviour
{
    [SerializeField] protected int life;
    [SerializeField] protected int shield;
    [SerializeField] protected int maxShield;
    [SerializeField] protected int deductDefault;
    [SerializeField] protected bool isImmortal = false;

    private void OnEnable()
    {
        EventManager.OnPlayerGetHurt += GetHurt;
        EventManager.OnPlayerGetShield += AddShield;
        EventManager.OnPlayerDeath += Die;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerGetHurt -= GetHurt;
        EventManager.OnPlayerGetShield -= AddShield;
        EventManager.OnPlayerDeath -= Die;
    }

    private void Start()
    {
        LoadDefaultValue();
    }

    protected virtual void GetHurt(object sender, EventArgs e)
    {
        if (isImmortal) return;
        if (shield == 0)
        {
            life -= deductDefault;
            if (life == 0) EventManager.TriggerPlayerDeath(this, EventArgs.Empty);
        }
        else shield -= deductDefault;
    }

    protected virtual void AddShield(object sender, EventArgs e)
    {
        if (shield >= maxShield) return;
        shield++;
    }

    protected virtual void Die(object sender, EventArgs e)
    {
        transform.parent.gameObject.SetActive(false);
        MusicManager.Instance.PlayAudioClip(AudioClipName.Die);
    }

    protected virtual void LoadDefaultValue()
    {
        life = 1;
        shield = 0;
        maxShield = 1;
        deductDefault = 1;
    }
}
