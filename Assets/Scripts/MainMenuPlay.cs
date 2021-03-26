using UnityEngine;

public class MainMenuPlay : MonoBehaviour
{
    public void Play()
    {
        Debug.Log("Hit play");
        SceneLoader.Load(SceneLoader.Scene.MainMenu);
    }
}
