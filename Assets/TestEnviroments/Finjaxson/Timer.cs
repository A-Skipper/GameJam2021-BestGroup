using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float startTime;
    public TMP_Text timertext;
    public float timer;
    public bool StartTimer;

    [SerializeField] float MaxTime = 60;

    public void TimerStart()
    {
        StartTimer = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (StartTimer)
            timer += Time.deltaTime;

        string minutes = ((int)timer / 60).ToString();
        string seconds = ((int)timer % 60).ToString();

        timertext.text = minutes + " : " + seconds;

        if (timer >= MaxTime)
        {
            GoToEndScene();
        }
    }

    public void GoToEndScene()
    {
        //Debug.Log("Hit play");
        SceneLoader.Load(SceneLoader.Scene.EndScreen);
    }
}
