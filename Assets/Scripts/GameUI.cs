using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public void ReturnToMain()
    {
        EndScore.Instance.score = 0;
        SceneLoader.Load(SceneLoader.Scene.MainMenu);
    }
}
