using UnityEngine;

[CreateAssetMenu(fileName = "MedalSO", menuName = "Medal")]
public class MedalSO : ScriptableObject
{
    public MedalType medalType;
    public Sprite medalSprite;
    public int minPointThreshold;
}
