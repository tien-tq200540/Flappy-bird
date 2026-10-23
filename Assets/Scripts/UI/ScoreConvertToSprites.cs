using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreConvertToSprites : TienMonoBehaviour
{
    [SerializeField] protected List<Sprite> numbersSprites = new();
    [SerializeField] protected int[] scoreCharacters = new int[4];
    [SerializeField] protected List<Image> scoreCharacterImageObjs = new();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadNumberSprites();
        LoadScoreCharacterImageObjs();
    }

    protected virtual void LoadNumberSprites()
    {
        if (numbersSprites.Count != 0) return;
        Sprite[] source = Resources.LoadAll<Sprite>("number");
        numbersSprites.AddRange(source);
        Debug.Log($"{transform.name}: LoadNumberSprites", this);
    }

    protected virtual void LoadScoreCharacterImageObjs()
    {
        if (scoreCharacterImageObjs.Count != 0) return;
        foreach (Transform child in transform)
        {
            scoreCharacterImageObjs.Add(child.GetComponent<Image>());
        }
    }

    public virtual void UpdateScoreUI(int curScore)
    {
        if (curScore == 0)
        {
            scoreCharacterImageObjs[scoreCharacters.Length - 1].gameObject.SetActive(true);
            scoreCharacterImageObjs[scoreCharacters.Length - 1].sprite = numbersSprites[curScore];
            return;
        }

        for (int i = scoreCharacters.Length - 1; i >= 0; i--)
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
