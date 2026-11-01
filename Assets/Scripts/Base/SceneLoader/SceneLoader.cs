using UnityEngine.SceneManagement;

public enum Scene
{
    Menu,
    Game
}

public static class SceneLoader
{
    public static void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
