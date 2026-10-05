using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUICtrl : TienMonoBehaviour
{
    private static ScoreUICtrl instance;
    public static ScoreUICtrl Instance => instance;

    [SerializeField] protected List<Sprite> numbersSprites = new();
    [SerializeField] protected int[] scoreCharacters = new int[4];
    [SerializeField] protected List<Image> scoreCharacterImageObjs = new();

    protected override void Awake()
    {
        if (instance != null) Debug.LogError("Only 1 ScoreUICtrl allows to exists!");
        else instance = this;
        base.Awake();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadScoreCharacterImageObjs();
    }

    protected virtual void LoadScoreCharacterImageObjs()
    {
        scoreCharacterImageObjs.Clear();
        foreach (Transform child in transform)
        {
            scoreCharacterImageObjs.Add(child.GetComponent<Image>());
        }

        foreach (var child in scoreCharacterImageObjs)
        {
            child.gameObject.SetActive(false);
        }
    }

    public virtual void UpdateScoreUI(int curScore)
    {

        for (int i = scoreCharacters.Length-1; i>=0; i--)
        {
            scoreCharacters[i] = curScore % 10;
            curScore /= 10;
        }

        bool canConvert = false;
        for (int i = 0; i < scoreCharacters.Length; i++)
        {
            if (scoreCharacters[i] != 0) canConvert = true;
            if (canConvert)
            {
                if (!scoreCharacterImageObjs[i].gameObject.activeInHierarchy) scoreCharacterImageObjs[i].gameObject.SetActive(true);
                scoreCharacterImageObjs[i].sprite = numbersSprites[scoreCharacters[i]];
            }
            
        }
    }
}
