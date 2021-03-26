using System;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public enum Scene
    {
        MainMenu,
        Loading,
    }

    private static Action onLoaderCallback;

    public static void Load(Scene scene)
    {
        //Set loader callback to load target scene
        onLoaderCallback = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };
        //Load loading scene
        SceneManager.LoadScene(Scene.Loading.ToString());
    }

    public static void LoaderCallback()
    {
        //Triggers after the first update which lets the screen refresh
        //Execute the loader callback action which loads target scene
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }

}
