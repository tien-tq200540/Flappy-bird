using UnityEngine;

[CreateAssetMenu(fileName = "ThemeSO", menuName = "Theme/ThemeSO")]
public class ThemeSO : ScriptableObject
{
    public Sprite background;
    public Sprite baseGround;
    public ThemeType type;
}
