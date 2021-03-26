using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public void ReturnToMain()
    {
        SceneLoader.Load(SceneLoader.Scene.MainMenu);
    }
}
