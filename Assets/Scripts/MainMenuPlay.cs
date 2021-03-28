using UnityEngine;

public class MainMenuPlay : MonoBehaviour
{
    public void Play()
    {
        //Debug.Log("Hit play");
        EndScore.Instance.score = 0;
        SceneLoader.Load(SceneLoader.Scene.GameScene);
    }
}
