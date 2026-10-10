using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThemeSO", menuName = "Theme/ThemeSO")]
public class ThemeSO : ScriptableObject
{
    public Sprite background;
    public Sprite baseGround;
    
    [Range(1, 31)] public List<int> days = new();
    [Range(1, 12)] public List<int> months = new();
    public ThemeType type;
}
