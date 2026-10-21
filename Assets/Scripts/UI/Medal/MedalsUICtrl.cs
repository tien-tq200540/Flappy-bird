using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedalsUICtrl : TienMonoBehaviour
{
    [SerializeField] protected List<MedalSO> medalsList = new();
    [SerializeField] protected Image medalImage;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMedalSprites();
        LoadMedalImage();
    }

    private void OnEnable()
    {
        MedalUIUpdate();
    }

    protected virtual void MedalUIUpdate()
    {
        int highScore = SaveSystemUtilities.LoadHighScore();
        foreach (var medal in medalsList)
        {
            if (highScore >= medal.minPointThreshold)
            {
                medalImage.sprite = medal.medalSprite;
                break;
            }
        }
    }

    protected virtual void LoadMedalImage()
    {
        if (medalImage != null) return;
        medalImage = GetComponentInChildren<Image>();
        Debug.Log($"{transform.name}: LoadMedalImage", this);
    }

    protected virtual void LoadMedalSprites()
    {
        if (medalsList.Count != 0) return;
        MedalSO[] sources = Resources.LoadAll<MedalSO>("SO/Medals");
        medalsList.AddRange(sources);
        medalsList.Sort((x, y) => y.minPointThreshold.CompareTo(x.minPointThreshold));
        Debug.Log($"{transform.name}: LoadMedalSprites", this);
    }
}
