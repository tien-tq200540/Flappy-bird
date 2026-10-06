using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeManager : TienMonoBehaviour
{
    [SerializeField] protected SpriteRenderer background;
    [SerializeField] protected SpriteRenderer baseGround;

    [SerializeField] protected List<ThemeSO> themeLists = new();
    [SerializeField] protected ThemeSO curTheme;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBackGround();
        LoadBase();
    }

    private void OnEnable()
    {
        LoadCurThemeByTime();
    }

    protected virtual void LoadBase()
    {
        if (baseGround != null) return;
        baseGround = transform.Find("Base").GetComponent<SpriteRenderer>();
        Debug.Log($"{transform.name}: LoadBase", this);
    }

    protected virtual void LoadBackGround()
    {
        if (background != null) return;
        background = transform.Find("Background").GetComponent<SpriteRenderer>();
        Debug.Log($"{transform.name}: LoadBackGround", this);
    }

    protected virtual void SetTheme(ThemeSO themeSO)
    {
        this.background.sprite = themeSO.background;
        this.baseGround.sprite = themeSO.baseGround;
    }

    protected virtual void LoadCurThemeByTime()
    {
        if (themeLists.Count == 0) return;

        ThemeType curThemeType = FindTargetThemeType();
        foreach (var theme in themeLists)
        {
            if (theme.type == curThemeType)
            {
                curTheme = theme;
                break;
            }
        }

        if (curTheme != null) SetTheme(curTheme);
        else Debug.LogWarning($"{transform.name}: No theme found!", this);
    }

    protected virtual ThemeType FindTargetThemeType()
    {
        DateTime now = DateTime.Now;

        //special theme
        if (now.Day == 31 && now.Month == 10) return ThemeType.Halloween;

        //default theme
        int curHour = now.Hour;
        if (6 <= curHour && curHour < 18) return ThemeType.Day;
        else return ThemeType.Night;
    }
}
