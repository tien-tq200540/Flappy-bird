using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThemeSO", menuName = "Theme/ThemeSO")]
public class ThemeSO : ScriptableObject
{
    public Sprite background;
    public Sprite baseGround;
    public List<int> days = new();
    public List<int> months = new();
    public ThemeType type;
}
