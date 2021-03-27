using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ourManager : MonoBehaviour
{
    private DisplayScore displayScore;
    private float startTime;
    //public Text timertext; 
    private void Awake()
    {
        displayScore = FindObjectOfType<DisplayScore>();
    }

    public void incrementScore(int points)
    {
        Debug.Log("Increase score, and probably spawn new creature");
        displayScore.addScore(points);
    }

    void Update()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString();

        
    }
}
