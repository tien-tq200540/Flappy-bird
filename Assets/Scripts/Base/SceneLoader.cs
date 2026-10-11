using UnityEngine.SceneManagement;

public enum Scene
{
    Home,
    Game
}

public static class SceneLoader
{
    public static void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
