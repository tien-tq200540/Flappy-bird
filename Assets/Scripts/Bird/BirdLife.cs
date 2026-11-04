using System;
using UnityEngine;

public class BirdLife : TienMonoBehaviour
{
    [SerializeField] protected int life;
    [SerializeField] protected int shield;
    [SerializeField] protected int maxShield;
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

    protected virtual void GetHurt(object sender, PlayerGetHurtEventArgs e)
    {
        if (shield == 0)
        {
            life -= e.Damage;
            if (life <= 0)
            {
                life = 0;
                EventManager.TriggerPlayerDeath(this, EventArgs.Empty);
            }
        } else
        {
            shield -= e.Damage;
            if (shield < 0)
            {
                life = 0;
                shield = 0;
                EventManager.TriggerPlayerDeath(this, EventArgs.Empty);
            } else
            {
                EventManager.TriggerPlayerLoseShield(this, EventArgs.Empty);
                MusicManager.Instance.PlayAudioClip(AudioClipName.Hit);
            }
        }
    }

    protected virtual void AddShield(object sender, EventArgs e)
    {
        if (shield >= maxShield) return;
        shield++;
        EventManager.TriggerPlayerGetShieldCompletely(sender, e);
    }

    protected virtual void Die(object sender, EventArgs e)
    {
        if (isImmortal && shield >= 0) return;
        transform.parent.gameObject.SetActive(false);
        MusicManager.Instance.PlayAudioClip(AudioClipName.Die);
    }

    protected virtual void LoadDefaultValue()
    {
        life = 1;
        shield = 0;
        maxShield = 1;
    }
}
