using UnityEngine;

public class SaveSystemUtilities
{
    public static void SaveHighScore(int highscore)
    {
        PlayerPrefs.SetInt("Highscore", highscore);
    }

    public static int LoadHighScore()
    {
        if (!PlayerPrefs.HasKey("Highscore")) PlayerPrefs.SetInt("Highscore", 0);
        return PlayerPrefs.GetInt("Highscore");
    }
}
