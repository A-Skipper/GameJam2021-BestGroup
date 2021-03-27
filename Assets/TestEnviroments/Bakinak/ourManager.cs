using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ourManager : MonoBehaviour
{
    private DisplayScore displayScore;
    private void Awake()
    {
        displayScore = FindObjectOfType<DisplayScore>();
    }


    public void incrementScore(int points)
    {
        Debug.Log("Increase score, and probably spawn new creature");
        displayScore.addScore(points);
    }
}
