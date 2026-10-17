using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : TienMonoBehaviour
{
    private static MusicManager instance;
    public static MusicManager Instance => instance;

    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected Dictionary<AudioClipName, AudioClip> audiosList = new();

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
        LoadAudiosList();
    }

    protected virtual void LoadAudiosList()
    {
        audiosList.Clear();
        AudioClip[] sources = Resources.LoadAll<AudioClip>("Audio");

        foreach (AudioClip clip in sources)
        {
            for (int i = 0; i < 5; i++)
            {
                AudioClipName audioClipName = (AudioClipName)i;
                if (clip.name == audioClipName.ToString())
                {
                    audiosList.Add(audioClipName, clip);
                    break;
                }
            }
        }
        Debug.Log($"{transform.name}: LoadAudiosList", this);
    }

    protected virtual void LoadAudioSource()
    {
        if (audioSource != null) return;
        audioSource = GetComponentInChildren<AudioSource>();
        Debug.Log($"{transform.name}: LoadAudioSource", this);
    }

    public virtual void PlayAudioClip(AudioClipName audioClipName)
    {
        audioSource.PlayOneShot(audiosList[audioClipName]);
    }
}
