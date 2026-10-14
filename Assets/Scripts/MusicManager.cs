using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : TienMonoBehaviour
{
    private static MusicManager instance;
    public static MusicManager Instance => instance;

    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip demoAudioClip;

    protected override void Awake()
    {
        if (instance != null) Debug.LogError("Only 1 MusicManager allows to exist!");
        else instance = this;
        DontDestroyOnLoad(this);

        base.Awake();
    }

    protected override void LoadComponents()
    {
        LoadAudioSource();
    }

    private void Start()
    {
        //testing
        Invoke(nameof(this.PlayClipTest), 10f);
    }

    protected virtual void LoadAudioSource()
    {
        if (audioSource != null) return;
        audioSource = GetComponentInChildren<AudioSource>();
        Debug.Log($"{transform.name}: LoadAudioSource", this);
    }

    protected virtual void PlayClipTest()
    {
        PlayAudioClip(demoAudioClip);
    }

    protected virtual void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
        //audioSource.clip = audioClip;
        //audioSource.Play();
        Debug.Log($"Play {audioClip.name}");
        
    }
}
