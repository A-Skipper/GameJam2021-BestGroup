using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    [SerializeField] private int Points;

    private DisplayScore displayScore;

    private void Awake()
    {
        displayScore = FindObjectOfType<DisplayScore>();
    }



}
