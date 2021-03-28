using TMPro;
using UnityEngine;

public class DisplayEndScore : MonoBehaviour
{
    private TMP_Text scoreText;
    private int score; 
    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
        score = EndScore.Instance.score;
        scoreText.text = "Score: " + score.ToString();
    }
}
