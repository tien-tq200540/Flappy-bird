using System;
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
        LoadTodayTheme();
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
        if (background != null) background.sprite = themeSO.background;
        if (baseGround != null) baseGround.sprite = themeSO.baseGround;
    }

    protected virtual void LoadTodayTheme()
    {
        if (themeLists.Count == 0) return;
        curTheme = FindTodayTheme();
        if (curTheme != null) SetTheme(curTheme);
        else Debug.LogWarning($"{transform.name}: No theme found!", this);
    }

    protected virtual ThemeSO FindTodayTheme()
    {
        DateTime now = DateTime.Now;

        //if it's a special day
        foreach (var theme in themeLists)
        {
            if (theme.days.Contains(now.Day) && theme.months.Contains(now.Month)) return theme;
        }

        //if it's a normal day
        int curHour = now.Hour;
        foreach (var theme in themeLists)
        {
            if ((theme.type == ThemeType.Day && IsDay(curHour)) || (theme.type == ThemeType.Night && !IsDay(curHour))) return theme;
        }

        return null;
    }

    protected virtual bool IsDay(int hour) => 6 <= hour && hour < 18;
}
